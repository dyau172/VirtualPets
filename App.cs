using System;
using System.Threading;

namespace virtualpets {

    public enum AppState {
        Running,
        Help,
        Paused,
        Exiting,
        Shop,
        Feed

    }

    class App : RealTimeComponent {
        //private bool appRunning = true;
        AppState appState = AppState.Running;
        Counter counter = new Counter (1000);
        Shop shop = Dependancy.CreateShop ();

        public int startTemp = new Random ().Next (5, 40);
        int currentTemp;

        Pet pet = new Dog("Bob", true, 50, 50, 24);
        

        public App () {

        }

        public void Run () {

            
            
            Initialise ();

            do {
                CheckKeyInput ();

                switch (appState) {
                    case AppState.Running:
                        Update();
                        Draw();                      

                        break;
                    case AppState.Paused:
                        break;
                    case AppState.Help:
                        DisplayHelp ();
                        break;
                    case AppState.Shop:
                        shop.DisplayToys ();
                        shop.PurchaseToys ();
                        break;
                    case AppState.Feed:

                        pet.Update ();
                        break;
                    default:
                        break;
                }

                Thread.Sleep (1000 / 10);
            } while (appState != AppState.Exiting);
        }

        public void DisplayHelp () {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear ();
            Console.WriteLine ("Help");
            Console.WriteLine ("\n\nPress Any key to Continue \nHopefully this is helpful");
            Console.ReadKey (true);
            appState = AppState.Running;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear ();
        }

        public void Initialise () {
            Console.CursorVisible = false;
            Console.Clear ();
            counter.Initialise ();
            
        }

        public void CheckKeyInput () {
            if (Console.KeyAvailable) {
                ConsoleKey keyPressed = Console.ReadKey (true).Key;

                if (keyPressed == ConsoleKey.Escape) {
                    appState = AppState.Exiting;
                }

                if (keyPressed == ConsoleKey.UpArrow) {
                    counter.TickSpeed++;
                }

                if (keyPressed == ConsoleKey.DownArrow) {
                    counter.TickSpeed--;
                }

                if (keyPressed == ConsoleKey.R) {
                    counter.Initialise ();
                }

                if (keyPressed == ConsoleKey.H) {
                    appState = AppState.Help;
                }

                if (keyPressed == ConsoleKey.W) {
                 Console.WriteLine("Cow");
                }

               

                if (keyPressed == ConsoleKey.P) {
                    if (appState != AppState.Paused) {
                        appState = AppState.Paused;
                    } else if (appState == AppState.Paused) {
                        appState = AppState.Running;
                    }

                }
            }
        }

        public void Update () {
            counter.Update ();
        }

        public void Display () {
            Console.Clear ();
            counter.Display ();
        }

        

        public void SelectPet () {
            Console.WriteLine ("Select a pet");
            Console.WriteLine ("1. Snake");
            Console.WriteLine ("2. Penguin");
            int selection = Convert.ToInt32 (Console.ReadLine ());

            if (selection == 1) {
                Console.WriteLine ("Snakey! I choose you!");
                pet = Dependancy.CreateSnake ();
                
                
            } else if (selection == 2) {
                Console.WriteLine ("Pengu! I choose you!");
                pet = Dependancy.CreatePenguin ();
                
                
            } else {
                Console.WriteLine ("Invalid Choice");
                Console.WriteLine ("You're a terrible person and don't deserve a pet. Good bye");
                appState = AppState.Exiting;
                
            }
        }
        
        

        public void DisplayMenu () {

        }

        public void Draw () {
            if (pet.Hunger > 0){
            Console.WriteLine (" ╔════════════════╗   ╔════════════════════════════════════════════════╗  ╔══════════════════════════════════╗");
            Console.WriteLine (" ║    Menu        ║   ║      Pet Stats                                 ║  ║                                  ║");
            Console.WriteLine ($"║    S - Shop    ║   ║      Name: {pet.Name}                          ║  ║ Key                              ║");
            Console.WriteLine ($"║    F - Feed    ║   ║      Healthy: {pet.Healthy}                    ║  ║                                  ║");
            Console.WriteLine ($"║    P - Play    ║   ║      Happiness: {pet.Happiness}                ║  ║ 0 - not happy / 100 - very happy ║");
            Console.WriteLine ($"║    E - Exit    ║   ║      Hunger: {pet.Hunger}                      ║  ║ 0 - starving / 100 full          ║");
            Console.WriteLine ($"║                ║   ║      Ideal Temperature: {pet.IdealTemperature} ║  ║                                  ║");
            Console.WriteLine ($"║                ║   ║      Current Temperature: {currentTemp}        ║  ║                                  ║");
            Console.WriteLine (" ╚════════════════╝   ╚════════════════════════════════════════════════╝  ╚══════════════════════════════════╝");

            
            appState = AppState.Running;
            Console.ReadKey (true);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear ();


            }else{
                Console.WriteLine("Pet has died");
                Console.ReadKey(true);
                Environment.Exit(0);
            }

           
        }

       
    }
}