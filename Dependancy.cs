using System;
using System.Collections.Generic;

namespace virtualpets {
    public class Dependancy {
        public static Pet CreateSnake () {
            return new Snake ("Tom", true, 25, 50, 26);
        }

        public static Pet CreatePenguin () {
            return new Penguin ("John", true, 20, 10, 16);
        }

        public static Shop CreateShop () {
            return new Shop (); 
        }

        public static Inventory CreateInventory () {
            return new Inventory ();
        }


        public static Toys CreateBall () {
            return new Toys ("Ball", 10, 10);
        }

        public static Toys CreateSlipper () {
            return new Toys ("Slipper", 2, 10);
        }

        public static Medicine CreateCheapMeds(){
            return new Medicine("Cheap Medicine", 10, -10, -10);
        }

        public static Medicine CreateExpMedicine(){
            return new Medicine("Expensive Medicine", 50, 20, 20);
        }


    }
}