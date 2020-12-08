using System;

namespace virtualpets {
    public class Medicine {
        Inventory bag;
        Room room;
        public string Name { get; set; }
        public int Cost { get; set; }
        public double ChangeHappiness { get; set; }
        public double ChangeHunger { get; set; }

        public Medicine (string name, int cost, double changeHappy, double changeHunger) {
            Name = name;
            Cost = cost;
            ChangeHappiness = changeHappy;
            ChangeHunger = changeHunger;

        }

        public void UseMeds (Medicine meds) {
            //Select toy from list 
            Console.SetCursorPosition (0, 20);

            Console.WriteLine ("Do you want to cure world fish? y/n");
            char input = Console.ReadKey ().KeyChar;

            if (input == 'y') {
                Console.WriteLine ("Which medicine do you want to use?");
                int index = Convert.ToInt32 (Console.ReadLine ());
                index -= 1;

                bag.toysPurchased.RemoveAt (index);
                Console.WriteLine ("room.pet.");

                room.pet.Happiness = room.pet.Happiness + meds.ChangeHappiness;
                room.pet.Hunger = room.pet.Hunger + meds.ChangeHunger;
                room.pet.Healthy = true;

            } else if (input == 'n') {
                Console.WriteLine ("medicine.useMeds no");
            } else {
                Console.WriteLine ("medicine.useMeds else");
            }

        }

    }
}