using System;

namespace virtualpets {
    class Snake : Pet {
        
        public Snake (string name, bool healthy, int hunger, int happiness, double idealTemp)
        :base(name, healthy, hunger, happiness, idealTemp)
        {
            Name = name;
            
            healthy = true;
            Hunger = hunger;
            Happiness = happiness;
            IdealTemperature = idealTemp;


        

        }

        public override void Update(){
            Console.WriteLine("Do something");
        }
    }
}