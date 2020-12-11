using System;

namespace virtualpets {
    class Draw {
        
        public void DrawMenuBorder () {
            Console.Clear ();
            Console.SetCursorPosition (0, 0);
            Console.WriteLine ( "╔════════════════╗   ╔════════════════════════════════════════════════╗  ╔══════════════════════════════════╗");
            Console.WriteLine ( "║                ║   ║                                                ║  ║                                  ║");
            Console.WriteLine ($"║                ║   ║                                                ║  ║                                  ║");
            Console.WriteLine ($"║                ║   ║                                                ║  ║                                  ║");
            Console.WriteLine ($"║                ║   ║                                                ║  ║                                  ║");
            Console.WriteLine ($"║                ║   ║                                                ║  ║                                  ║");
            Console.WriteLine ($"║                ║   ║                                                ║  ║                                  ║");
            Console.WriteLine ($"║                ║   ║                                                ║  ║                                  ║");
            Console.WriteLine ( "╚════════════════╝   ╚════════════════════════════════════════════════╝  ╚══════════════════════════════════╝");
        }

        public void DrawShopBorder () {
          
            Console.SetCursorPosition (0, 9);
            Console.WriteLine ("");
            Console.WriteLine ( "╔═════════════════════════════════════╗");
            Console.WriteLine ( "║                                     ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"╚═════════════════════════════════════╝");
            
        }

        public void DrawInventoryBorder(){
             Console.SetCursorPosition (0, 9);
            Console.WriteLine ( "╔═════════════════════════════════════╗");
            Console.WriteLine ( "║                                     ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"╚═════════════════════════════════════╝");
        }

        


    }
}