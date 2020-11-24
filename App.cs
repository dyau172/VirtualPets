using System;
using System.Threading;

namespace virtualpets
{

    public enum AppState
    {
        Running,
        Help,
        Paused,
        Exiting,
        Shop,
        Feed

    }

    class App : RealTimeComponent
    {
        //private bool appRunning = true;
        AppState appState = AppState.Running;
        Counter counter = new Counter(1000);

        public int startTemp = new Random().Next(5,30);
        Pet pet;

        public App()
        {
            
        }

        public void Run()
        {
            Initialise();

            do
            {
                CheckKeyInput();

                switch (appState)
                {
                    case AppState.Running:
                        Update();
                        Display();
                        
                        break;
                    case AppState.Paused:
                        break;
                    case AppState.Help:
                        DisplayHelp();
                        break;
                        case AppState.Shop:
                        DisplayHelp();
                        break;
                        case AppState.Feed:
                        pet.Update();
                        break;
                    default:
                        break;
                }
                
                
                Thread.Sleep(1000/10);
            } while (appState != AppState.Exiting);
        }

        public void DisplayHelp()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("Help");
            Console.WriteLine("\n\nPress Any key to Continue \nHopefully this is helpful");
            Console.ReadKey(true);
            appState = AppState.Running;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
        }

        public void Initialise()
        {
            Console.CursorVisible = false;
            Console.Clear();
            counter.Initialise();
        }

        public void CheckKeyInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey keyPressed = Console.ReadKey(true).Key;

                if (keyPressed == ConsoleKey.Escape)
                {
                    appState = AppState.Exiting;
                }

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    counter.TickSpeed++;
                }

                if (keyPressed == ConsoleKey.DownArrow)
                {
                    counter.TickSpeed--;
                }

                if (keyPressed == ConsoleKey.R)
                {
                    counter.Initialise();
                }

                if (keyPressed == ConsoleKey.H)
                {
                    appState = AppState.Help;
                }

                  if (keyPressed == ConsoleKey.S)
                {
                    appState = AppState.Shop;
                }

                  if (keyPressed == ConsoleKey.F)
                {
                    appState = AppState.Feed;
                }



                if (keyPressed == ConsoleKey.P)
                {
                    if (appState != AppState.Paused)
                    {
                        appState = AppState.Paused;
                    }
                    else if (appState == AppState.Paused)
                    {
                        appState = AppState.Running;
                    }

                }
            }
        }

        public void Update()
        {
            counter.Update();
        }

        public void Display()
        {
            Console.Clear();
            counter.Display();
        }

        public Pet SelectPet(){
            Console.WriteLine("Select a pet");
            Console.WriteLine("1. Snake");
            Console.WriteLine("2. Penguin");
            int selection = Convert.ToInt32(Console.ReadLine());

            switch (selection){
                case 1: 
                return Dependancy.CreateSnake();
                Console.WriteLine("Snakey! I choose you!");
                break;

                case 2: 
                return Dependancy.CreatePenguin();
                Console.WriteLine("Pengu! I choose you!");
                break;
                
                default:
                Console.WriteLine("Invalid Choice");
                Console.WriteLine("You're a terrible person and don't deserve a pet. Good bye");
                return null;
                
                
            }
        }

        public void DisplayMenu(){

        }
    }
}
