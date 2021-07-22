using System;
using System.Threading;

namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = Thread.CurrentThread;
            Console.WriteLine($"Имя потока: {t.Name}");
            t.Name = "Метод Main";
            Console.WriteLine($"Имя потока: {t.Name}");
            Console.WriteLine($"Запущен ли поток: {t.IsAlive}");
            Console.WriteLine($"Приоритет потока: {t.Priority}");
            Console.WriteLine($"Статус потока: {t.ThreadState}");
            Console.WriteLine($"Домен приложения: {Thread.GetDomain().FriendlyName}");

            Thread t2 = new Thread(new ThreadStart(Count));  // В делегат ThreadStart передаём метом для исполнения в потоке
            t2.Start();

            for(int i = 1; i <= 20; i++)
            {
                Console.WriteLine($"Основной поток. i={i}");
                Thread.Sleep(400);
            }

            //Console.WriteLine("Hello World!");
        }

        public static void Count()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Второй поток. i ={i}");
                Thread.Sleep(1000);
            }
        } 
    }
}
