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
        Inventory

    }

    class App : RealTimeComponent {
        //private bool appRunning = true;
        AppState appState = AppState.Running;
        Counter counter = new Counter (1000);
        Room room = new Room ();
        Shop shop; 
        Inventory bag;
        Draw borders = new Draw ();

        Toys toy;
        Medicine meds;

        public App () {
            
            this.bag = Dependancy.CreateInventory(room);
            this.shop = Dependancy.CreateShop (bag);
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
                        CheckPetHunger ();
                        CheckPetHappiness ();
                        room.CheckTemp ();
                        room.UpdateTemp ();
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

        public void Back () {
            appState = AppState.Running;
            DrawMenu ();
        }
        public void CheckKeyInput () {
            if (Console.KeyAvailable) {
                ConsoleKey keyPressed = Console.ReadKey (true).Key;

                if (keyPressed == ConsoleKey.Escape) {
                    appState = AppState.Exiting;
                }
                if (keyPressed == ConsoleKey.E) {
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
                if (keyPressed == ConsoleKey.F) {
                    room.pet.FeedPet ();
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
            Console.WriteLine ($"    T - Bag              Happiness: {room.pet.Happiness.ToString("0.00")}                                  0 - not happy / 100 - very happy");
            Console.WriteLine ($"    E - Exit             Hunger: {room.pet.Hunger.ToString("0.00")}                                     0 - starving / 100 full        ");
            Console.WriteLine ($"                         Ideal Temperature: {room.pet.IdealTemperature}                               coins in bag: {bag.Coins.ToString()}");
            Console.WriteLine ($"    B - Back             Current Temperature: {room.CurrentTemp.ToString("0.00")}                     ");
        }
        public void DrawShop () {
            Console.Clear ();
            appState = AppState.Paused;
            DrawMenu ();
            borders.DrawShopBorder ();
            Console.SetCursorPosition (2, 11);
            Console.WriteLine ("    Shop               ");
            Console.SetCursorPosition (2, 12);
            Console.WriteLine ($"{shop.DisplayToys()}");
            Console.WriteLine ($"{shop.DisplayMeds()}");
            Console.WriteLine ($"                       ");
            Console.SetCursorPosition (2, 19);
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
            Console.WriteLine ($"║   Key 3 - Cheap Medicine            ║");
            Console.SetCursorPosition (40, 16);
            Console.WriteLine ($"║   Key 4 - Expensive Medicine        ║");
            Console.SetCursorPosition (40, 18);
            Console.WriteLine ($"╚═════════════════════════════════════╝");
            Console.SetCursorPosition (40, 19);
            Console.WriteLine ("We sell stuff");
            shop.BuyStuff (toy, meds);
            appState = AppState.Running;
            DrawMenu ();
        }
        public void DrawInventory () {
            Console.Clear ();
            appState = AppState.Paused;
            DrawMenu ();
            borders.DrawShopBorder ();
            Console.SetCursorPosition (4, 11);
            Console.WriteLine ("   Inventory                        ");
            Console.WriteLine ($"                                   ");
            Console.WriteLine ($"   {bag.DisplayToys()}             ");
            Console.WriteLine ($"   {bag.DisplayMeds()}             ");
            //play.PlayToy (item);

            //play.DisplayList ();

            Console.WriteLine ("Do you want to use your stuff? y/n");
            char input = Console.ReadKey ().KeyChar;
            if (input == 'y') {
                DrawUse ();
            } else {
                appState = AppState.Running;
                DrawMenu ();
            }
        }
        public void DrawUse () {
            Console.SetCursorPosition (40, 10);
            Console.WriteLine (" ╔═════════════════════════════════════╗");
            Console.SetCursorPosition (40, 11);
            Console.WriteLine (" ║    Use                              ║");
            Console.SetCursorPosition (40, 12);
            Console.WriteLine ($"║                                     ║");
            Console.SetCursorPosition (40, 13);
            Console.WriteLine ($"║   Key 1 - Play with toys            ║");
            Console.SetCursorPosition (40, 14);
            Console.WriteLine ($"║   Key 2 - Use medicine              ║");
            Console.SetCursorPosition (40, 15);
            Console.WriteLine ($"╚═════════════════════════════════════╝");
            Console.SetCursorPosition (40, 16);
            int input = Convert.ToInt32 (Console.ReadLine ());
            switch (input) {
                case 1:
                    bag.PlayToy (bag);
                    appState = AppState.Running;
                    break;
                case 2:
                    bag.UseMeds (bag);
                    appState = AppState.Running;
                    break;
                default:
                    appState = AppState.Running;
                    DrawMenu ();
                    break;
            }
        }
        public void CheckPetHunger () {

            if (room.pet.Hunger < 0) {
                Console.SetCursorPosition (2, 9);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine ($"{room.pet.Name} doesn't like you anymore");
                appState = AppState.Exiting;
            } else if (room.pet.Hunger < 20) {
                Console.SetCursorPosition (2, 9);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine ($"{room.pet.Name} is hungry");
                room.pet.Happiness -= 1;
                room.pet.Healthy = false;
                
            } else {
                
                Console.ForegroundColor = ConsoleColor.Gray;
            }

        }

        public void CheckPetHappiness () {
            if (room.pet.Happiness < 0) {
                Console.SetCursorPosition (2, 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine ($"{room.pet.Name} has left the room");
                appState = AppState.Exiting;
            } else if (room.pet.Happiness < 20) {
                Console.SetCursorPosition (2, 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine ($"{room.pet.Name} is unhappy, go play something");
                
            } else {
            
                Console.ForegroundColor = ConsoleColor.Gray;
            }

        }

        public void Objectives(){
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Welcome to my virtual pets game");
            Console.WriteLine("The game rule are simple.");
            Console.WriteLine("Keep your pet happy and fed..");
            Console.WriteLine("If the hunger and happiness level reach zero, it's game over");
            Console.WriteLine("The health and temperature of the room will affect the pets hunger and happiness");
            Console.ReadKey(true);

        }

    }
}