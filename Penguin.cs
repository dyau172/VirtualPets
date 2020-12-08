using System;

namespace virtualpets {
    class Penguin : Pet {
        

        public Penguin (string name, bool healthy, double happiness, double hunger, double idealTemp) : base (name, healthy, happiness, hunger, idealTemp) {
            Name = name;
            Healthy = healthy;
            Happiness = happiness;
            Hunger = hunger;
            IdealTemperature = idealTemp;

        }

    
        public override void FeedPet(){
            Hunger += 50;
        }

    }

}