using System;
using System.Threading;

namespace Game_machine
{
    class Road
    {
        object locker;

        public Road( Object Locker)
        {
            locker = Locker;
        }
        public void StartThreadRoad()
        {
            Thread road = new Thread(RoadDrow);
            road.Start();
        }
        private void RoadDrow()
        {
            while (true)
            {
                lock (locker)
                {                   
                    for (int c = 0; c < 3; c++)
                    {
                        Console.CursorVisible = false;
                        int top = c;
                        // Очистка старой полосы
                        for (int j = 0; j < 45; j++)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;

                            Console.SetCursorPosition(30, j);     
                            Console.Write(" ");

                            Console.SetCursorPosition(30 + 35, j); 
                            Console.Write(" ");

                            Console.SetCursorPosition(30 + 36, j);
                            Console.Write(" ");
                        }
                        // Рисование новой полосы
                        for (int k = 0; k < 15; k++)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;

                            Console.SetCursorPosition(30, top);        
                            Console.Write(" ");

                            Console.SetCursorPosition(30 + 35, top);   
                            Console.Write(" ");

                            top = top + 3;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        Thread.Sleep(CarMovement.SpeedThread);
                    } 
                } 
            }
        }
    }
}
