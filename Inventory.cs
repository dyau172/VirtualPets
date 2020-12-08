using System;
using System.Collections.Generic;

namespace virtualpets {
    public class Inventory {
        public List<Toys> toysPurchased = new List<Toys> ();

        List<Medicine> MedicineList = new List<Medicine> ();

        public int Coins;
        //Room room = new Room ();

        public Inventory () {

        }

        public string DisplayToys () {
            //Print list of toys to purchase 

            /*
            int index = 0;
            string toysp = "";
            foreach (Toys toy in toysPurchased) {
                index++;
                toysp += $"{toy.Name}\n";
            };
            return index.ToString() + toysp;
            */

           /*  string toysp = "";
            for (int i = 0; i < toysPurchased.Count; i++) {

                foreach (Toys toy in toysPurchased) {

                    toysp += $"{i} , {toy.Name}\n";
                };
            }
            return toysp; */

            string toysp = "";
            foreach (Toys toy in toysPurchased) {

                toysp += $"{toy.Name}\n   ";
            };
            return toysp;

        }

        public string DisplayMeds () {
            string medlist = "";
            Console.SetCursorPosition (2, 16);
            foreach (Medicine meds in MedicineList) {
                medlist += $"{meds.Name}\n  ";
            };
            return medlist;

        }
        public void PurchaseToys (Toys item) {
            //add toy from list from purchase list
            Console.WriteLine ("You want to purchase toys. Key 1 for ball/Key 2 for Slippers");

            int key = Convert.ToInt32 (Console.ReadLine ());

            if (key == 1) {
                item = Dependancy.CreateBall ();
                UpdateCoin (item);
                toysPurchased.Add (item);
                Console.WriteLine ("Ball added to bag");
                //Coins = Coins - item.Cost;

            } else if (key == 2) {
                item = Dependancy.CreateSlipper ();
                UpdateCoin (item);
                toysPurchased.Add (item);
                Console.WriteLine ("Slipper added to bag");

            } else
                Console.WriteLine ("Ya did nuffin");

        }

        public void PurchaseMedcine (Medicine item) {
            //add toy from list from purchase list
            Console.WriteLine ("You want to purchase medicine. Key 3 for Cheapo Meds/Key 4 for the Expensive stuff");
            int key = Convert.ToInt32 (Console.ReadLine ());

            if (key == 3) {
                item = Dependancy.CreateCheapMeds ();
                UpdateCoinMeds (item);
                MedicineList.Add (item);
                Console.WriteLine ("Cheap Medicine added to bag");
                //Coins = Coins - item.Cost;

            } else if (key == 4) {
                item = Dependancy.CreateExpMedicine ();
                UpdateCoinMeds (item);
                MedicineList.Add (item);
                Console.WriteLine ("Expensive Medicine added to bag");

            } else
                Console.WriteLine ("Ya did nuffin");

        }
        public void UpdateCoin (Toys item) {
            if (Coins > item.Cost) {
                Coins = Coins - item.Cost;
            } else {
                Console.WriteLine ("You don't have enough coins");
                Console.ReadKey (true);

            }

        }
        public void UpdateCoinMeds (Medicine item) {
            if (Coins > item.Cost) {
                Coins = Coins - item.Cost;
            } else {
                Console.WriteLine ("You don't have enough coins");
                Console.ReadKey (true);

            }

        }

    }
}