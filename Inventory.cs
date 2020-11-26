using System;
using System.Collections.Generic;

namespace virtualpets {
    public class Inventory {
        List<Toys> toysPurchased = new List<Toys> ();

        public int Coins;
        public int Medicine;

        public Inventory () {

        }

        public string DisplayToys () {
            //Print list of toys to purchase
            string toysp = "";
            foreach(Toys toy in toysPurchased){
                toysp += $"{toy.Name}\n";
            };
            return toysp;
        }
        
       
        public void UpdateInventory () {
            //Display inventory with new purchased toy
        }

    }

}