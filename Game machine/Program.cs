using System;

namespace Game_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(95,50);
            Object locker = new Object();

            CarMovement car = new CarMovement(locker);
            Road road = new Road(locker);
            GameInterface @interface = new GameInterface(locker);

            @interface.StartThreadInterface();
            car.StartThreadCar();
            road.StartThreadRoad();
            
            Console.ReadKey();
        }
    }
}
