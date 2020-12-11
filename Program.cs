using System;

namespace virtualpets {
    class Program {
        static void Main (string[] args) {

            App app = new App ();
            bool r = true;
            while (r)
            try {
                app.SelectPet ();
                r = false;
            } catch (FormatException) {
                r = true;
            }
            app.Objectives();
            app.Run ();
        }
    }
}