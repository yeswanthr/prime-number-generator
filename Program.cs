using System;
using System.Threading;

namespace PrimeNumber
{
    class Program
    {
        static int number = 0;  //To store prime number.
        static int count = 0;   //To check whether the time is 10 seconds

        /// <summary>
        /// Start point of application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Starting timer will check prime number for every 1 second.");

                //Intiate timer to run every second
                Timer timer = new Timer(callback, number, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));

                //To get the 10 prime numbers          
                WorkThreadFunction();

                Console.Read();
            }
            catch(Exception ex)
            {
                Console.WriteLine("'" + ex.Message + "' error occured");
                Console.Read();
            }
            
        }
        /// <summary>
        /// Get the prime number at particular second
        /// </summary>
        public static void WorkThreadFunction()
        {
            try
            {
                bool check = false;
                int n = 1;
                while (count < 10)
                {
                    check = IsPrime(n);
                    if (check)
                    {
                        number = n;
                    }
                    n++;
                }                                    
            }
            
            catch (Exception ex)
            {
                Console.WriteLine("'"+ex.Message + "' error occured");
            }
        }
        /// <summary>
        /// Print prime numbers for every callback
        /// </summary>
        /// <param name="state">message send by the main method</param>
        private static void callback(object state)
        {
            count++;
            if (count < 11)
            {
                Console.WriteLine("Prime number : " + number);
            }
            else
            {
                Console.Read();
            }
        }
        /// <summary>
        /// To check whether the number is prime or not
        /// </summary>
        /// <param name="number">number to check</param>
        /// <returns>returns bool whether prime or not</returns>
        public static bool IsPrime(long number)
        {
            try
            {
                if (number <= 1)
                    return false;
                else if (number % 2 == 0)
                    return number == 2;

                long N = (long)(Math.Sqrt(number) + 0.5);

                for (int i = 3; i <= N; i += 2)
                    if (number % i == 0)
                        return false;

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("'" + ex.Message + "' error occured");
                return false;
            }
        }
    }
}
