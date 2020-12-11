using System;
using System.Collections.Generic;

namespace virtualpets {
    public class Inventory {
        public List<Toys> toysPurchased = new List<Toys> ();

        public List<Medicine> medicineList = new List<Medicine> ();

        public int Coins { get; set; }
        Room room;
        Medicine meds;
        Toys toy;

        public Inventory (Room room) {
            this.room = room;
            
        }
        public string DisplayToys () {
      
            string toysp = "";
            int index = 1;
            foreach (Toys toy in toysPurchased) {

                toysp += $"{index} {toy.Name}\n   ";
                index++;
            };
            return toysp;
        }
        public string DisplayMeds () {
            string medlist = "";
            int index = 1;
            
            foreach (Medicine meds in medicineList) {
                medlist += $"{index} {meds.Name}\n   ";
                index++;
            };
            return medlist;
        }
        public void PlayToy (Inventory bag) {
            //Select toy from list 
            Console.SetCursorPosition (40, 16);

            Console.WriteLine ("Do you want to play with a toy? y/n");
            char input = Console.ReadKey ().KeyChar;

            if (input == 'y') {
                Console.SetCursorPosition (40, 17);
                Console.WriteLine ("Which toy do you want to use?");
                Console.SetCursorPosition (40, 18);
                int index = Convert.ToInt32 (Console.ReadLine ());
                index -= 1;
                this.toy = bag.toysPurchased[index];

                bag.toysPurchased.RemoveAt (index);
  
                room.pet.Happiness = room.pet.Happiness + toy.HappyValue;

            } else {
                Console.WriteLine ("");
            }

        }
        public void UseMeds (Inventory bag) {
            //Select toy from list 
            Console.SetCursorPosition (40, 16);

            Console.WriteLine ("Do you want to cure world fish? y/n");
            char input = Console.ReadKey ().KeyChar;

            if (input == 'y') {
                Console.SetCursorPosition (40, 18);
                Console.WriteLine ("Which medicine do you want to use?");
                int index = Convert.ToInt32 (Console.ReadLine ());
                index -= 1;
                 this.meds = bag.medicineList[index];

                medicineList.RemoveAt (index);
                Console.WriteLine ("room.pet.");

                room.pet.Happiness = room.pet.Happiness + meds.ChangeHappiness;
                room.pet.Hunger = room.pet.Hunger + meds.ChangeHunger;
                room.pet.Healthy = true;

            } else {
                Console.WriteLine ("");
            }
        }

    }
}