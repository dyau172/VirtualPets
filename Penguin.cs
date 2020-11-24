using System;

namespace virtualpets
{
    class Penguin : Pet
    {
        public string Name {get; set;} 

        public Penguin(string name, bool healthy, int happiness, int hunger, int idealTemp):base(healthy, happiness, hunger, idealTemp){
            Name = name;
        

        }
        
    }


  
}
