using System;

namespace virtualpets {
    class Snake : Pet {

        public Snake (string name, bool healthy, double hunger, double happiness, double idealTemp) : base (name, healthy, hunger, happiness, idealTemp) {
            Name = name;

            Healthy = healthy;
            Hunger = hunger;
            Happiness = happiness;
            IdealTemperature = idealTemp;

        }

        public override void FeedPet(){
            Hunger += 10;
        }


    }
}