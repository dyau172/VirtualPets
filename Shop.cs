using System;
using System.Collections.Generic;

namespace virtualpets {
    public class Shop {
        //List of toys avaiable
        public List<Toys> toysForSale = new List<Toys> ();
        List<Medicine> medsForSale = new List<Medicine>();
        Inventory bag = Dependancy.CreateInventory ();
        Toys ball = Dependancy.CreateBall ();
        Toys slipper = Dependancy.CreateSlipper ();
        Medicine cheapMeds = Dependancy.CreateCheapMeds();
        Medicine expMeds = Dependancy.CreateExpMedicine();

       

        

        public Shop () {

            toysForSale.Add(ball);
            toysForSale.Add(slipper);
            medsForSale.Add(cheapMeds);
            medsForSale.Add(expMeds);
        }
        public string DisplayToys () {
            //Print list of toys to purchase
            string toylist = "";
            Console.SetCursorPosition(2,14);
            foreach (Toys toy in toysForSale) {
                toylist += $"{toy.Name}\n  ";
            };
            return toylist;
        }
        public string DisplayMeds(){
           string medlist = "";
            Console.SetCursorPosition(2,16);
            foreach (Medicine meds in medsForSale) {
                medlist += $"{meds.Name}\n  ";
            };
            return medlist; 
        }
    
    }
}