using System;

namespace virtualpets {
    public class Toys {

        public string Name { get; set; }
        public int Cost { get; set; }
        public int HappyValue {get; set;}

        Room room;
        Inventory bag;

        public Toys (string name, int cost, int happyValue) {
            Name = name;
            Cost = cost;
            HappyValue = happyValue;

            
        }

       /*  public void PlayToy (Toys item) {
            //Select toy from list 
            Console.SetCursorPosition(0, 20);
                 
            Console.WriteLine ("Do you want to play with a toy? y/n");
            char input = Console.ReadKey ().KeyChar;
            
            if (input == 'y') {
                Console.WriteLine ("Which toy do you want to use?");
                int index = Convert.ToInt32 (Console.ReadLine ());
                index -= 1;

                bag.toysPurchased.RemoveAt (index);
                Console.WriteLine("room.pet.");
                   
                room.pet.Happiness = room.pet.Happiness + item.HappyValue;

            }else if(input =='n'){
                 Console.WriteLine("play.playtoy no");
            }
             else {
                Console.WriteLine("play.playtoy else");
            }
          
        } */

      
                
    }
}