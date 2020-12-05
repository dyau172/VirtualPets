using System;
using System.Threading;
using ConsoleTables;
using static System.ConsoleColor;

namespace virtualpets {

    public enum AppState {
        Running,
        Help,
        Paused,
        Exiting,
        Shop,
        Feed,
        Inventory

    }

    public class App : RealTimeComponent {
        //private bool appRunning = true;
        AppState appState = AppState.Running;
        Counter counter = new Counter (1000);
        Shop shop = Dependancy.CreateShop ();
        Inventory bag = Dependancy.CreateInventory ();
        Draw borders = new Draw ();
        Room room = new Room ();
        //double temp = new Random().Next(5,30);
        Toys item;
        Play play = new Play ();

        public App () {

        }

        public void Run () {

            Initialise ();

            do {
                CheckKeyInput ();

                switch (appState) {
                    case AppState.Running:
                        room.pet.Happiness -= 0.1;
                        room.pet.Hunger -= 0.3;
                        bag.Coins += 2;
                        DrawMenu ();
                        break;
                    case AppState.Paused:
                        break;
                    case AppState.Help:
                        DisplayHelp ();
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

        public void Exit () {
            appState = AppState.Exiting;
        }

        public void Back () {
            appState = AppState.Running;
            DrawMenu();
        }

        public void CheckKeyInput () {
            if (Console.KeyAvailable) {
                ConsoleKey keyPressed = Console.ReadKey (true).Key;

                if (keyPressed == ConsoleKey.Escape) {
                    appState = AppState.Exiting;
                }

                if (keyPressed == ConsoleKey.R) {
                    counter.Initialise ();
                }

                if (keyPressed == ConsoleKey.H) {
                    appState = AppState.Help;
                }

                if (keyPressed == ConsoleKey.S) {
                    DrawShop ();
                }
                if (keyPressed == ConsoleKey.B) {
                    appState = AppState.Running;
                }
                if (keyPressed == ConsoleKey.T) {
                    DrawInventory ();
                }

                if (keyPressed == ConsoleKey.UpArrow) {
                    room.IncreaseTemp ();
                }
                if (keyPressed == ConsoleKey.DownArrow) {
                    room.DecreaseTemp ();
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
            Pet pet;
            Console.WriteLine ("Select a pet");
            Console.WriteLine ("1. Snake");
            Console.WriteLine ("2. Penguin");
            int selection = Convert.ToInt32 (Console.ReadLine ());

            if (selection == 1) {
                Console.WriteLine ("Snakey! I choose you!");
                pet = Dependancy.CreateSnake ();
                AddPetToRoom (pet);
                Console.ReadKey (true);

            } else if (selection == 2) {
                Console.WriteLine ("Pengu! I choose you!");
                pet = Dependancy.CreatePenguin ();
                AddPetToRoom (pet);
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

        public void AddPetToRoom (Pet pet) {
            room.PetInRoom (pet);
        }

        public void DrawMenu () {
            Console.Clear ();
            borders.DrawMenuBorder ();
            Console.SetCursorPosition (2, 1);
            Console.WriteLine ("       Menu                 Pet Stats                                                                     ");
            Console.WriteLine ($"    S - Shop             Name: {room.pet.Name}                                         Key                              ");
            Console.WriteLine ($"    F - Feed             Healthy: {room.pet.Healthy}                                                             ");
            Console.WriteLine ($"    T - Play             Happiness: {room.pet.Happiness.ToString("0.00")}                                  0 - not happy / 100 - very happy");
            Console.WriteLine ($"    E - Exit             Hunger: {room.pet.Hunger.ToString("0.00")}                                      0 - starving / 100 full        ");
            Console.WriteLine ($"                         Ideal Temperature: {room.pet.IdealTemperature}                               coins in bag: {bag.Coins.ToString()}");
            Console.WriteLine ($"    B - Back             Current Temperature: {room.CurrentTemp}                     ");

        }

        public void DrawShop () {
            Console.Clear ();
            appState = AppState.Paused;
            DrawMenu ();
            borders.DrawShopBorder ();
            Console.SetCursorPosition (2, 12);

            Console.WriteLine ("    Shop               ");
            Console.WriteLine ($"                      ");
            Console.WriteLine ($"{shop.DisplayToys()}");
            Console.WriteLine ($"                       ");

            Console.SetCursorPosition (2, 17);
            Console.WriteLine ("Do you want to buy anything? y/n");
            char input = Console.ReadKey ().KeyChar;
            if (input == 'y') {
                DrawBuy ();
            } else {
                appState = AppState.Running;
                DrawMenu ();
            }

        }
        public void DrawBuy () {

            //int x = 10;

            Console.SetCursorPosition (40, 10);

            Console.WriteLine (" ╔═════════════════════════════════════╗");
            Console.SetCursorPosition (40, 11);
            Console.WriteLine (" ║    Buy                              ║");
            Console.SetCursorPosition (40, 12);
            Console.WriteLine ($"║                                     ║");
            Console.SetCursorPosition (40, 13);
            Console.WriteLine ($"║   Key 1 - Ball                      ║");
            Console.SetCursorPosition (40, 14);
            Console.WriteLine ($"║   Key 2 - Slipper                   ║");
            Console.SetCursorPosition (40, 15);
            Console.WriteLine ($"║                                     ║");
            Console.SetCursorPosition (40, 16);
            Console.WriteLine ($"║     B - Back                        ║");
            Console.SetCursorPosition (40, 17);
            Console.WriteLine ($"║                                     ║");
            Console.SetCursorPosition (40, 18);
            Console.WriteLine ($"╚═════════════════════════════════════╝");

            bag.PurchaseToys (item);

            Console.WriteLine (item);
            appState = AppState.Running;
            DrawMenu ();

        }

        public void DrawInventory () {
            Console.Clear ();
            appState = AppState.Paused;
            DrawMenu ();

            borders.DrawShopBorder ();
            Console.SetCursorPosition (2, 12);
            Console.WriteLine ("");
            Console.WriteLine ("   Inventory                        ");
            Console.WriteLine ($"                                   ");
           // Console.WriteLine ($"   {bag.DisplayToys()}             ");

            //play.PlayToy (item);
             play.DisplayList();

        }

    }
}