﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mantecado
{
    class Item
    {
        
        public string itemName;
        public double itemPrice;
        public string itemCategory;
        public List<AddOns> ItemAddons = new List<AddOns>();
        public System.Windows.Controls.TextBox T;

    }

    class AddOns
    {
        public string addonName;
        public double addonPrice;
    }

    class Order
    {
        const double TAX_RATE = 0.07;
        double AddedTax = 0;
        double TotalPrice = 0;
        public List<Item> OrderItems = new List<Item>();
       
        double SubTotal = 0;

        public void AddItem(Item item)
        {

            OrderItems.Add(item);
            SubTotal += item.itemPrice;
            AddedTax += item.itemPrice * TAX_RATE;
            TotalPrice = SubTotal + AddedTax;

        }

        public void RemoveItem(Item item)
        {
            OrderItems.Remove(item);
            SubTotal -= item.itemPrice;
            AddedTax -= item.itemPrice * TAX_RATE;
            TotalPrice -= SubTotal + AddedTax;

        }

        public void AddAddon(Item item, AddOns add)
        {
            item.ItemAddons.Add(add);
            SubTotal += add.addonPrice;
            AddedTax += add.addonPrice * TAX_RATE;
            TotalPrice += SubTotal + AddedTax;

        }


        public double GetTotalPrice()
        {
            return Math.Round(TotalPrice, 2);
        }

        public double GetTax()
        {
            return Math.Round(AddedTax, 2);
        }

        public double GetSubtotal()
        {
            return Math.Round(SubTotal, 2);
        }

     

        public override string ToString()
        {
            string fullOrder = "";
            foreach(Item i in OrderItems)
            {
                fullOrder += i.itemName + "\t\t$" + i.itemPrice + '\n';
                foreach (AddOns a in i.ItemAddons)
                {
                    fullOrder += "\t" + a.addonName + "\t\t$" + a.addonPrice + '\n';
                }
                fullOrder += '\n';
            }
            fullOrder += "Total Price: " + "$" + (Math.Round(this.SubTotal, 2));

            return String.Format("{0:0.00}", fullOrder);
        }
    }
}
