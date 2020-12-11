using System;

namespace virtualpets {
    public class Medicine {

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

        
    }
}