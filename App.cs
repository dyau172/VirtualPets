using System;
using System.Threading;

namespace virtualpets {

    public enum AppState {
        Running,
        Help,
        Paused,
        Exiting,
        Shop,
        Feed,
        Inventory,
        PurchaseBall,
        PurchaseSlipper

    }

    public class App : RealTimeComponent {
        //private bool appRunning = true;
        AppState appState = AppState.Running;
        Counter counter = new Counter (1000);
        Shop shop = Dependancy.CreateShop ();
        Inventory bag = Dependancy.CreateInventory ();
        Pet pet;

        public int startTemp = new Random ().Next (5, 40);
        int currentTemp;

        public App () {

        }

        public void Run () {

            Initialise ();

            do {
                CheckKeyInput ();

                switch (appState) {
                    case AppState.Running:
                        pet.Happiness -= 1;
                        bag.Coins += 1;
                        Draw ();

                        break;
                    case AppState.Paused:
                        break;
                    case AppState.Help:
                        DisplayHelp ();
                        break;
                    case AppState.Shop:
                        DrawShop ();
                        break;
                    case AppState.Feed:
                        pet.Update ();
                        break;
                    case AppState.Inventory:
                        DrawInventory ();
                        break;
                    case AppState.PurchaseBall:
                        DrawShop ();
                        //shop.PurchaseToys();
                        break;
                    case AppState.PurchaseSlipper:
                        DrawShop ();
                        break;
                    default:
                        break;
                }

                Thread.Sleep (1000 / 2);
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

                if (keyPressed == ConsoleKey.S) {
                    appState = AppState.Shop;
                }
                if (keyPressed == ConsoleKey.B) {
                    appState = AppState.Running;
                }
                if (keyPressed == ConsoleKey.T) {
                    appState = AppState.Inventory;
                }
                if (keyPressed == ConsoleKey.NumPad1) {
                    appState = AppState.PurchaseBall;
                }
                if (keyPressed == ConsoleKey.NumPad2) {
                    appState = AppState.PurchaseSlipper;
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
                Console.ReadKey (true);

            } else if (selection == 2) {
                Console.WriteLine ("Pengu! I choose you!");
                pet = Dependancy.CreatePenguin ();
                Console.ReadKey (true);

            } else if (selection == 3) {
                pet = Dependancy.CreateDog ();
            } else {
                Console.WriteLine ("Invalid Choice");
                Console.WriteLine ("You're a terrible person and don't deserve a pet. Good bye");
                Console.ReadKey (true);
                appState = AppState.Exiting;

            }
        }

        public void Draw () {
            Console.Clear ();

            Console.WriteLine ("╔════════════════╗   ╔════════════════════════════════════════════════╗  ╔══════════════════════════════════╗");
            Console.WriteLine ("║    Menu        ║   ║      Pet Stats                                 ║  ║                                  ║");
            Console.WriteLine ($"║    S - Shop    ║   ║      Name: {pet.Name}                                 ║  ║ Key                              ║");
            Console.WriteLine ($"║    F - Feed    ║   ║      Healthy: {pet.Healthy}                            ║  ║                                  ║");
            Console.WriteLine ($"║    T - Play    ║   ║      Happiness: {pet.Happiness}                             ║  ║ 0 - not happy / 100 - very happy ║");
            Console.WriteLine ($"║    E - Exit    ║   ║      Hunger: {pet.Hunger}                                ║  ║ 0 - starving / 100 full          ║");
            Console.WriteLine ($"║                ║   ║      Ideal Temperature: {pet.IdealTemperature}                     ║  ║                                  ║");
            Console.WriteLine ($"║    B - Back    ║   ║      Current Temperature: {currentTemp}                    ║  ║                                  ║");
            Console.WriteLine ("╚════════════════╝   ╚════════════════════════════════════════════════╝  ╚══════════════════════════════════╝");

        }

        public void DrawShop () {
            Console.Clear ();
            appState = AppState.Paused;
            Draw ();
            Console.WriteLine ();
            Console.WriteLine ("");
            Console.WriteLine ("╔═════════════════════════════════════╗");
            Console.WriteLine ("║    Shop                             ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║   {shop.DisplayToys()}              ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║    Coins in bag: {bag.Coins.ToString()}           ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"╚═════════════════════════════════════╝");

            Console.WriteLine ("");
            Console.WriteLine (" ╔═════════════════════════════════════╗");
            Console.WriteLine (" ║    Buy                              ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║   Key 1 - Ball                      ║");
            Console.WriteLine ($"║   Key 2 - Slipper                   ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"╚═════════════════════════════════════╝");
        }

        public void DrawInventory () {
            Console.Clear ();
            appState = AppState.Paused;
            Draw ();
            Console.WriteLine ();
            Console.WriteLine ("");
            Console.WriteLine ("╔═════════════════════════════════════╗");
            Console.WriteLine ("║    Inventory                             ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║   {bag.DisplayToys()}              ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"║                                     ║");
            Console.WriteLine ($"╚═════════════════════════════════════╝");
        }

    }
}