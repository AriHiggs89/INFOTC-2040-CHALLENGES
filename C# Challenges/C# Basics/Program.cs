using System;

namespace CSharp_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            const byte sample1 = 0x3A;
            byte sample2 = 58;
            int heartRate = 85;
            double deposits = 135002796D;
            float acceleration = 9.800F;
            float mass = 14.6F;
            double distance = 129.763001D;
            bool lost = true;
            bool expensive = true;
            int choice = 2;
            char integral = '\u222B';
            string greeting = "Hello ";
            string name = "Karen";

            //sample equivalency condition
            if (sample1 == sample2)
            {
                Console.WriteLine("The samples are equal");  //output True
            }
            else
            {
                Console.WriteLine("The samples are not equal"); //output False
            }

            //heart rate condition
            if (heartRate >= 40 && heartRate <= 80)
            {
                Console.WriteLine("Heart rate is normal");
            }
            else
            {
                Console.WriteLine("Heart rate is not normal");
            }

            //wealth condition
            if (deposits >= 1000000000)
            {
                Console.WriteLine("You are exceedingly wealth");
            }
            else
            {
                Console.WriteLine("Sorry, you are so poor!");
            }

            //operator 
            float force = (mass * acceleration);
            Console.WriteLine("Force = " + force);

            //display distance
            Console.WriteLine(distance + " is the distance");

            //bool
            if (lost == expensive)
            {
                Console.WriteLine("I am really sorry! I will get the manager.");
            }
            else
            {
                Console.WriteLine("Here is a coupon for 10% off");
            }

            //switch case
            switch (choice)
            {
                case 1:
                    Console.WriteLine("You chose 1");
                    break;
                case 2:
                    Console.WriteLine("You chose 2");
                    break;
                case 3:
                    Console.WriteLine("You chose 3");
                    break;
                default:
                    Console.WriteLine("You made an unknown choice");
                    break;
            }

            //char constant
            Console.WriteLine(integral + " is an integral");

            //for loop
            for (int i = 5; i < 11; i++)
            {
                Console.WriteLine("i = " + i);
            }

            //while loop
            int age = 0;
            while (age < 6)
            {
                Console.WriteLine("age = " + age);
                age++;
            }

            //greeting string
            Console.WriteLine(greeting + name);
        }
    }
}
