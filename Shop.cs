using System;
using System.Collections.Generic;

namespace virtualpets {
    public class Shop {
        //List of toys avaiable
        
        Inventory bag = Dependancy.CreateInventory ();
        Toys ball = Dependancy.CreateBall ();
        Toys slipper = Dependancy.CreateSlipper ();

        public List<Toys> toysForSale = new List<Toys> ();

        

        public Shop () {

            toysForSale.Add(ball);
            toysForSale.Add(slipper);
        }
        public string DisplayToys () {
            //Print list of toys to purchase
            string toylist = "";
            Console.SetCursorPosition(2,14);
            foreach (Toys toy in toysForSale) {
                toylist += $"{toy.Name}\n";
            };
            return toylist;
        }
    /*
        public void SelectToy(){
            
            

           int key = Convert.ToInt32(Console.ReadLine());
            if (key == 1){
               // bag.PurchaseToys(Dependancy.CreateBall());

                Console.WriteLine("Ball added to bag");
            } else if (key == 2){
              //  bag.PurchaseToys(Dependancy.CreateSlipper());
                Console.WriteLine("Slipper added to bag");
            }else
            Console.WriteLine("Ya did nuffin");
        }

        
        public void UpdateCoin () {
            if (bag.Coins > )

        }
*/
    }
}