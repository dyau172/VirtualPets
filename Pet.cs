using System;

namespace virtualpets {
    public abstract class Pet {
        public string Name {get; set;}
        public bool Healthy { get; set; }
        
        public double Happiness { get; set; }
        
        /*
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
        */
        public double Hunger {get; set;}

        
        public double IdealTemperature { get; set; }
        public Pet (string name, bool healthy, double happiness, double hunger, double idealTemp) {
           healthy = true;

        }

    
        /*

        public virtual void DisplayPetStats(){
            Console.WriteLine($"Healthy: {Healthy}");
            Console.WriteLine($"Happiness: {Happiness}");
            Console.WriteLine($"Healthy: {Hunger}");
            Console.WriteLine($"Ideal Temperature: {IdealTemperature}");
        }

        */
    }
}