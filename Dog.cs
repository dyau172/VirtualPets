using System;

namespace virtualpets {
    class Dog : Pet {
        
        public Dog (string name, bool healthy, int hunger, int happiness, int idealTemp)
        :base(name, healthy, hunger, happiness, idealTemp)
        {
            Name = name;
            Healthy = healthy;
            healthy = true;
            Hunger = hunger;
            Happiness = happiness;
            IdealTemperature = idealTemp;


        

        }

    }
}