using System;

namespace virtualpets
{
    class Counter : RealTimeComponent
    {
        int startCount;
        int count;
        bool active = true;
        public int TickSpeed { get; set; }

        public Counter(int startValue)
        {
            startCount = startValue;
        }

        public void Display()
        {
            if (active)
            {
                Console.SetCursorPosition(5, 4);
                Console.Write(TickSpeed);
                Console.SetCursorPosition(5, 5);
                Console.Write(count);
            }else{
                Console.WriteLine("Pet has died");
                Console.ReadKey(true);
                Environment.Exit(0);
            }
        }

        public void Initialise()
        {
            TickSpeed = 1;
            count = startCount;
        }

        public void Update()
        {
            if (count > 0)
            {
                count -= TickSpeed;
            }
            else
            {
                active = false;
            }
        }
    }
}