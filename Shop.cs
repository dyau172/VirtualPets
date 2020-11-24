using System;
using System.Collections.Generic;

namespace virtualpets {
    public class Shop {
        //List of toys avaiable
         List<Toys> toylist = new List<Toys> ();

        public Shop(){
            Toys ball = Dependancy.CreateBall() ;
            Toys slipper = Dependancy.CreateSlipper();

            toylist.Add(ball);
            toylist.Add(slipper);
        }

        
        
        public void DisplayToys () {
            //Print list of toys to purchase
            foreach(Toys toy in toylist){
                Console.WriteLine(toy);
            };
        }

        public void PurchaseToys () {
            //add toy from list from purchase list
            

        }

        public void UpdateCoin () {
            //deduct payment

        }

        public void UpdateInventory () {
            //Display inventory with new purchased toy
        }
    }
}