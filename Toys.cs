using System;

namespace virtualpets {
    public class Toys {

        public string Name { get; set; }
        public int Cost { get; set; }
        public int HappyValue {get; set;}

        public Toys (string name, int cost, int happyValue) {
            Name = name;
            Cost = cost;
            HappyValue = happyValue;

        }

                
    }
}