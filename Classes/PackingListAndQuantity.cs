﻿using System.Collections.Generic;
using System.Linq;

namespace OPGSysm7TravelPalHT2023.Classes;

public class PackingListAndQuantity
{
    public class PackingListItem : IPackingListItem
    {
        public string Passport { get; }
        public Dictionary<string, int> Quantities { get; set; } // skapa en dicitonary för att hålla en string/item och quantity

        public PackingListItem(string name)
        {
            Passport = name;
            Quantities = new Dictionary<string, int>();
        }

        public string GetInfo()
        {
            string quantityInfo = string.Join(", ", Quantities.Select(kv => $"{kv.Key}: {kv.Value}"));  // skriver ut infon läsbart
            return $"Item: {Passport}, Quantities: {quantityInfo}";
        }
    }

    public class OtherItem : IPackingListItem
    {
        public int Quantity { get; set; }
        public string ItemName { get; }
        public string Passport { get; set; }

        public OtherItem(string name, int quantity)
        {
            ItemName = name;
            Quantity = quantity;
        }

        public string GetInfo()
        {
            return $"Item: {ItemName}, Quantity: {Quantity}";
        }
    }
}
