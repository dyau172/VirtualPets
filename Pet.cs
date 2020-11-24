using System;

namespace virtualpets {
    public abstract class Pet {

        public bool Healthy { get; set; }
        public int Happiness { get; set; }
        public int Hunger { get; set; }
        public int IdealTemperature { get; set; }
        public Pet (bool healthy, int happiness, int hunger, int idealTemp) {
            Healthy = healthy;
            Happiness = happiness;
            Hunger = hunger;
            IdealTemperature = idealTemp;

        }
    }
}