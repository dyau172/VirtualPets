using System;

namespace virtualpets {
    class Snake : Pet {
        public string Name { get; set; }
        public Snake (string name, bool healthy, int hunger, int happiness, int idealTemp)
        :base(healthy, hunger, happiness, idealTemp)
        {
            Name = name;
            healthy = true;


        

        }

        public void TestMethod(){
            Console.WriteLine("Do something");
        }
    }
}