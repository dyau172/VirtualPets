using System;
using System.Collections.Generic;

namespace virtualpets {
    public class Shop {
        //List of toys avaiable
        List<Toys> toysForSale = new List<Toys> ();
        List<Medicine> medsForSale = new List<Medicine> ();
        Inventory bag;
        Toys ball = Dependancy.CreateBall ();
        Toys slipper = Dependancy.CreateSlipper ();
        Medicine cheapMeds = Dependancy.CreateCheapMeds ();
        Medicine expMeds = Dependancy.CreateExpMedicine ();

        public Shop (Inventory bag) {
            this.bag = bag;
            toysForSale.Add (ball);
            toysForSale.Add (slipper);
            medsForSale.Add (cheapMeds);
            medsForSale.Add (expMeds);
        }
        public string DisplayToys () {
            //Print list of toys to purchase
            string toylist = "";
            Console.SetCursorPosition (2, 14);
            foreach (Toys toy in toysForSale) {
                toylist += $"{toy.Name}\n  ";
            };
            return toylist;
        }
        public string DisplayMeds () {
            string medlist = "";
            Console.SetCursorPosition (2, 16);
            foreach (Medicine meds in medsForSale) {
                medlist += $"{meds.Name}\n  ";
            };
            return medlist;
        }

      
        public void BuyStuff (Toys toy, Medicine meds) {
            Console.WriteLine ("Buy things");

            int key = Convert.ToInt32 (Console.ReadLine ());

            if (key == 1) {
                toy = Dependancy.CreateBall ();
                UpdateCoin (toy);
                bag.toysPurchased.Add (toy);

            } else if (key == 2) {
                toy = Dependancy.CreateSlipper ();
                UpdateCoin (toy);
                bag.toysPurchased.Add (toy);

            } else if (key == 3) {
                meds = Dependancy.CreateCheapMeds ();
                UpdateCoinMeds (meds);
                bag.medicineList.Add (meds);

            } else if (key == 4) {
                meds = Dependancy.CreateExpMedicine ();
                UpdateCoinMeds (meds);
                bag.medicineList.Add (meds);

            } else
                Console.WriteLine ("Ya did nuffin");
                
        }

        public void UpdateCoin (Toys toy) {
             if (bag.Coins >= toy.Cost) {
                bag.Coins = bag.Coins - toy.Cost;
                Console.WriteLine ("Toy added to bag");
                Console.ReadKey(true);
            } else {
                Console.WriteLine ("You don't have enough coins for this toy");
                Console.ReadKey (true);

            }
 
        }
        public void UpdateCoinMeds (Medicine meds) {
            if (bag.Coins >= meds.Cost) {
                bag.Coins = bag.Coins - meds.Cost;
                Console.WriteLine ("Medicine added to bag");
                Console.ReadKey(true);
            } else {
                Console.WriteLine ("You don't have enough coins for the meds");
                Console.ReadKey (true);
            }

        }


    }
}