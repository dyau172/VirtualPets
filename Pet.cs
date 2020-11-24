using System;

namespace virtualpets {
    public abstract class Pet {

        public bool Healthy { get; set; }
        public int Happiness { get; set; }
        public int Hunger{
            get{return Hunger;}
            set{
                if (value <= 0){
                    Hunger = 0;
                }else {
                    Hunger = value;
                }
            }
        }
        public int IdealTemperature { get; set; }
        public Pet (bool healthy, int happiness, int hunger, int idealTemp) {
           

        }

        public virtual void Update(){

        }

        public virtual void DisplayPetStats(){
            Console.WriteLine($"Healthy: {Healthy}");
            Console.WriteLine($"Happiness: {Happiness}");
            Console.WriteLine($"Healthy: {Hunger}");
            Console.WriteLine($"Ideal Temperature: {IdealTemperature}");
        }
    }
}