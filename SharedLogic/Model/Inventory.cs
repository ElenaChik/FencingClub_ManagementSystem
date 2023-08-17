using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLogic.Model
{
    internal class Inventory
    {
        public int idInventory {get;set;}
        public string name { get;set;} 

        public string description { get;set;}

        public string gender { get; set; }
        public string size { get;set;}
        public double price { get;set;}
        public int quantity { get;set;} 


        public Inventory() { }
    }
}
