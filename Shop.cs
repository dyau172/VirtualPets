using System;
using System.Collections.Generic;

namespace virtualpets {
    public class Shop {
        //List of toys avaiable
         public List<Toys> toysForSale = new List<Toys> ();
         Inventory bag = Dependancy.CreateInventory();

        public Shop(){
            Toys ball = Dependancy.CreateBall() ;
            Toys slipper = Dependancy.CreateSlipper();

            toysForSale.Add(ball);
            toysForSale.Add(slipper);
        }

        
        
        public string DisplayToys () {
            //Print list of toys to purchase
            string toylist = "";
            foreach(Toys toy in toysForSale){
                toylist += $"{toy.Name}\n";
            };
            return toylist;
        }

        public void PurchaseToys (Toys toy) {
            //add toy from list from purchase list
            toysForSale.Add(toy);
           
            

        }
         public void UpdateCoin () {
            //deduct payment

        }


        

        

        
    }
}