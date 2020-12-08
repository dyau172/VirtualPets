using System;
using System.Collections.Generic;
namespace virtualpets {
    class Play {
        Inventory bag;
        Toys item;
        Room room;
     

        public void DisplayList()
        {
            
            Console.WriteLine("play.displaylist");
            
            foreach (Toys item in bag.toysPurchased)
            {
                Console.WriteLine(item);
            }
        }
         public void PlayToy (Toys item) {
            //Select toy from list 
           Console.SetCursorPosition (40, 16);
                 
            Console.WriteLine ("Do you want to play with a toy? y/n");
            char input = Console.ReadKey ().KeyChar;
            
            if (input == 'y') {
                Console.SetCursorPosition (40, 17);
                Console.WriteLine ("Which toy do you want to use?");
                Console.SetCursorPosition (40, 18);
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
          
        }
     
    }

}