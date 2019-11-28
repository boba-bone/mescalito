using System;
using System.Threading;

namespace Game_machine
{

    class CarMovement
    {
        private class DrawingCar
        {
            public void DrawCar(int left, int top)
            {
                Console.SetCursorPosition(left, top);

                Console.BackgroundColor = ConsoleColor.DarkRed;

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 6; j++)
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

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                    top++;
                    Console.SetCursorPosition(left, top);
                }
            }
        }

        static int left = 40, top = 30, speedThread = 400, speedCar = 10  ; 
        object locker;

        public int Left { get { return left; } }
        public int Top { get { return top; } }
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
            ConsoleKeyInfo button;
            Console.CursorVisible = false;
            while(true)
            {
                DrawingCar car = new DrawingCar();
                button = Console.ReadKey(true);

                if (button.Key == ConsoleKey.LeftArrow)
                {
                    lock (locker)
                    {
                        car.WashCar(left, top);

                        if (left-1 == 30)
                            left = 31;
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

                        if (left+1 == 60)
                            left = 59;
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

                        if (top-1== 0)
                            top = 1;
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

                        if (top+1 == 40)
                            top = 39;
                        else
                            top++;

                        car.DrawCar(left, top);
                    }
                }
                else if (button.Key == ConsoleKey.W)
                {
                    lock (locker)
                    {
                        if (speedThread - 10 == 0)
                            speedThread = 10;
                        else
                        {
                            speedThread -= 10;
                            speedCar += 5;
                        }
                    }
                }
                else if (button.Key == ConsoleKey.S)
                {
                    lock (locker)
                    {
                        if (SpeedThread + 10 == 420)
                            speedThread = 410;
                        else
                        {
                            speedThread += 10;
                            speedCar -= 5;
                        }
                    }
                }
            }
        }
    }
}
