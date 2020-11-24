using System;
using System.Collections.Generic;

namespace virtualpets {
    public class Dependancy {
        public static Pet CreateSnake () {
            return new Snake ("Tom", true, 80, 50, 26);
        }

        public static Pet CreatePenguin () {
            return new Penguin ("John", false, 20, 10, 16);
        }

        public static Shop CreateShop () {
            return new Shop (); 
        }

        public static Inventory CreateInventory () {
            return new Inventory ();
        }


        public static Toys CreateBall () {
            return new Toys ("Ball", 30, 20);
        }

        public static Toys CreateSlipper () {
            return new Toys ("Slipper", 2, 3);
        }

    }
}