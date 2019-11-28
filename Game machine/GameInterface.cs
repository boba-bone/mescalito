using System;
using System.Text;
using System.Threading;

namespace Game_machine
{
    class GameInterface
    {
        object locker;

        public GameInterface(Object Locker)
        {
            locker = Locker;
        }
        public void StartThreadInterface()
        {
            Thread thread = new Thread(DrawInterface);
            thread.Start();
        }
        private void DrawInterface()
        {           
            while (true)
            {
                lock (locker)
                {
                    Console.CursorVisible = false;
                    Console.SetCursorPosition(1, 1);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.OutputEncoding = Encoding.UTF8;

                    Console.WriteLine("Скорость - {0} км/ч", CarMovement.SpeedCar);                    
                    Console.WriteLine("\n Управление: \n Газ - W, Тормоз - S");
                    Console.WriteLine(" Движение влево  - {0}\n Движение вправо - {1}\n Движение вверх  - {2}\n Движение вниз   - {3}",(char)8592,(char)8594,(char)8593,(char)8595);
                }
            }
        }
    }
}
