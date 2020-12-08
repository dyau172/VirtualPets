using System;

namespace virtualpets {
    public abstract class Pet {
        public string Name {get; set;}
        public bool Healthy { get; set; }
        
        //public double Happiness { get; set; }
          double happiness;
        public double Happiness{
            get{return happiness;}
            set{
                if (value >= 100){
                    happiness = 100;
                }else {
                    happiness = value;
                }
            }
        } 
        double hunger;
        public double Hunger{
            get{return hunger;}
            set{
                if (value >= 100){
                    hunger = 100;
                }else {
                    hunger = value;
                }
            }
        } 
        
        //public double Hunger {get; set;}

        
        public double IdealTemperature { get; set; }
        public Pet (string name, bool healthy, double happiness, double hunger, double idealTemp) {
           healthy = true;

        }

        public  virtual void FeedPet(){
           
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