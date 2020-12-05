using System;

namespace virtualpets
{
    class Program
    {
        static void Main(string[] args)
        {
         
            App app = new App();
            app.SelectPet();
            app.Run();
        }
    }
}
