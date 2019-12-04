using System;
using System.Threading;

namespace Game_machine
{
    class Road
    {
        object locker;

        static int leftLane = 30, rightLane = 60;

        public int LeftLane { get { return leftLane; } }
        public int RightLane { get { return rightLane; } }


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
            int stepDrowRoad = 3, numberOfRenderings = 15, roadLong = stepDrowRoad * numberOfRenderings;
            while (true)
            {
                lock (locker)
                {                  
                    for (int c = 0; c < stepDrowRoad; c++)
                    {
                        Console.CursorVisible = false;
                        int top = c;
                        // Очистка старой полосы
                        for (int j = 0; j < roadLong; j++)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;

                            Console.SetCursorPosition(leftLane, j);     
                            Console.Write(" ");

                            Console.SetCursorPosition(rightLane, j); 
                            Console.Write(" ");
                        }
                        // Рисование новой полосы
                        for (int k = 0; k < numberOfRenderings; k++)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;

                            Console.SetCursorPosition(leftLane, top);        
                            Console.Write(" ");

                            Console.SetCursorPosition(rightLane, top);   
                            Console.Write(" ");

                            top = top + stepDrowRoad;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        Thread.Sleep(CarMovement.SpeedThread);
                    } 
                } 
            }
        }
    }
}
