using System;

namespace virtualpets {
    class Penguin : Pet {
        

        public Penguin (string name, bool healthy, int happiness, int hunger, int idealTemp) : base (name, healthy, happiness, hunger, idealTemp) {
            Name = name;
            Healthy = healthy;
            Happiness = happiness;
            Hunger = hunger;
            IdealTemperature = idealTemp;

        }

         public override void Update(){
            Console.WriteLine("Do something");
        }

        /*
        public override void DisplayPetStats () {
            Console.WriteLine ($"Name: {Name}");
            Console.WriteLine ($"Healthy: {Healthy}");
            Console.WriteLine ($"Happiness: {Happiness}");
            //Console.WriteLine ($"Healthy: {Hunger}");
            Console.WriteLine ($"Ideal Temperature: {IdealTemperature}");
        }
        */

    }

}