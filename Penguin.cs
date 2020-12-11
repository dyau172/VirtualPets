using System;

namespace virtualpets {
    class Penguin : Pet, ISwim {
        

        public Penguin (string name, bool healthy, double happiness, double hunger, double idealTemp) : base (name, healthy, happiness, hunger, idealTemp) {
            Name = name;
            Healthy = healthy;
            Happiness = happiness;
            Hunger = hunger;
            IdealTemperature = idealTemp;

        } 
        public override void FeedPet(){
            Hunger += 20;
        }

        
        public void Swim (){
            Console.WriteLine("Swimming like a fish");
        }

    }

}