using System;
using System.Threading;

namespace Game_machine
{

    class CarMovement
    {
        private class DrawingCar
        {
            int widthCar, longCar;

            public DrawingCar(int widthCar, int longCar)
            {
                this.widthCar = widthCar;
                this.longCar = longCar;
            }

            public void DrawCar(int left, int top)
            {
                Console.SetCursorPosition(left, top);

                Console.BackgroundColor = ConsoleColor.DarkRed;

                for (int i = 0; i < widthCar; i++)
                {
                    for (int j = 0; j < longCar; j++)
                    {
                        Console.Write(" ");
                    }
                    top++;
                    Console.SetCursorPosition(left, top);
                }
                Console.BackgroundColor = ConsoleColor.Black;
            }
            public void WashCar(int left, int top)
            {
                Console.SetCursorPosition(left, top);

                for (int i = 0; i < widthCar; i++)
                {
                    for (int j = 0; j < longCar; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                    top++;
                    Console.SetCursorPosition(left, top);
                }
            }
        }

        static int speedThread = 400, speedCar = 10  ; 
        object locker;

        public static int SpeedThread { get { return speedThread; } }
        public static int SpeedCar { get { return speedCar; } }

        public CarMovement(Object Locker)
        {
            locker = Locker;
        }

        public void StartThreadCar()
        {
            Thread car = new Thread(MoveCar);
            car.Start();
        }

        private void MoveCar()
        {
            Road road = new Road(locker);

            int left = 40, top = 30, widthCar = 5, longCar = 6, step = 1;
            int longRoad = 45, stepThreadSpeed = 10, stepCarSpeed = 5, maxThreadSpeed = 420 ;

            ConsoleKeyInfo button;
            Console.CursorVisible = false;
            while(true)
            {
                DrawingCar car = new DrawingCar(widthCar, longCar);
                button = Console.ReadKey(true);

                if (button.Key == ConsoleKey.LeftArrow)
                {
                    lock (locker)
                    {
                        car.WashCar(left, top);

                        if (left - step == road.LeftLane)
                            left = road.LeftLane+step;
                        else
                            left--;

                        car.DrawCar(left, top);
                    }
                }

                else if (button.Key == ConsoleKey.RightArrow)
                {
                    lock (locker)
                    {
                        car.WashCar(left, top);

                        if (left + widthCar + step == road.RightLane)
                            left = road.RightLane - widthCar - step;
                        else
                            left++;

                        car.DrawCar(left, top);
                    }
                }

                else if (button.Key == ConsoleKey.UpArrow)
                {
                    lock (locker)
                    {
                        car.WashCar(left, top);

                        if (top - step == 0)
                            top = step;
                        else
                            top--;

                        car.DrawCar(left, top);
                    }
                }

                else if (button.Key == ConsoleKey.DownArrow)
                {
                    lock (locker)
                    {
                        car.WashCar(left, top);

                        if (top + longCar + step == longRoad )
                            top = longRoad - longCar - step;
                        else
                            top++;

                        car.DrawCar(left, top);
                    }
                }
                else if (button.Key == ConsoleKey.W)
                {
                    lock (locker)
                    {
                        if (speedThread - stepThreadSpeed == 0)
                            speedThread = stepThreadSpeed;
                        else
                        {
                            speedThread -= stepThreadSpeed;
                            speedCar += stepCarSpeed;
                        }
                    }
                }
                else if (button.Key == ConsoleKey.S)
                {
                    lock (locker)
                    {
                        if (SpeedThread + stepThreadSpeed == maxThreadSpeed)
                            speedThread = maxThreadSpeed - stepThreadSpeed;
                        else
                        {
                            speedThread += stepThreadSpeed;
                            speedCar -= stepCarSpeed;
                        }
                    }
                }
            }
        }
    }
}
