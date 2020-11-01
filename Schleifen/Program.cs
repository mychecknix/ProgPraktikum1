using System;

namespace Schleifen
{
    class Program
    {
        static void Main(string[] args)
        {
            // START task a)
            int inNumber;    // integer variable for entered number
            bool numCheck = false; // flag for input number status

            do
            {
                Console.Write("Geben Sie eine Zahl größer gleich 10 und kleiner als 10000 ein: ");
                inNumber = Convert.ToInt32(Console.ReadLine());
                // check the number and set a flag
                if (inNumber < 10 || inNumber >= 10000)
                {
                    Console.WriteLine("Ungültige Eingabe, bitte wiederholen.");
                } else
                {
                    numCheck = true;
                }
                Console.WriteLine();    // empty line to separate output
            } while (!numCheck);    // loop will run unt
            // END task a)

            // START task b)
            if (inNumber < 1000)
            {
                Console.WriteLine($"50-er kleiner als {inNumber}:");
                if (inNumber <= 50)
                {
                    Console.WriteLine($"Es gibt keine 50-er kleiner als {inNumber}");
                }
                else
                {
                    // subtract 1 from the number if it is exactly divisible by 50 or 500
                    // this corrects the counter variable i by 1, because we only want numbers lower than 50 or 500
                    // (inNumber - 1) / 50 to find the biggest "50-er" and than count down
                    for (int i = (inNumber - 1) / 50; i > 0; i--)
                    {
                        Console.WriteLine(i*50);
                    }
                }
                
            } else
            {
                Console.WriteLine($"500-er kleiner als {inNumber}:");
                for (int i = (inNumber - 1) / 500; i > 0; i--)
                {
                    Console.WriteLine(i * 500);
                }
            }
            Console.WriteLine();    // empty line to separate output
            // END task b)

            // START task c)
            int sumDivider = 0;
            Console.WriteLine($"Teier von {inNumber}:");
            // find all divider from inNumber-1 to 2
            for (int i = (inNumber-1); i >= 2; i--)
            {
                // it is a real divider if rest of the modulo operation is zero
                if(inNumber % i == 0)
                {
                    Console.WriteLine(inNumber / i);
                    sumDivider += inNumber / i; // add divider to the sum of dividers
                }
            }
            Console.WriteLine($"Die Summe aller echten Teiler von {inNumber} ist {sumDivider}.");
            Console.WriteLine();
            // END task c)

            // START task d)
            int countEven = 0;
            int countOdd = 0;
            // check every number for even or odd until counter is bigger than 10 times the number
            for (int i = 10; i <= (inNumber * 10);  i *= 10)
            {
                // get rest of current position and the position after it and divide it by 10^(n-1) to get only the current position
                if(((inNumber % i) / (i / 10)) % 2 == 0)
                {
                    countEven++;    // add one to this counter if it is even
                } else
                {
                    countOdd++;     // add one to this counter if it is odd 
                }
            }
            Console.WriteLine($"Die Zahl {inNumber} hat {countEven} gerade und {countOdd} ungerade Ziffern.");
            Console.WriteLine();
            // END task d)

            // START task e)
            int firstDigit = -1, lastDigit = -1;    // control number -1, which should not be on the output
            lastDigit = inNumber % 10;
            for (int i = 10; i <= (inNumber * 10); i *= 10)
            {
                firstDigit = (inNumber % i) / (i / 10);
            }
            Console.WriteLine($"Das Produkt der ersten und letzten Ziffer von {inNumber} ist {firstDigit}*{lastDigit}={firstDigit*lastDigit}.");
            // END task e)

            // ask for any key to exit program
            Console.WriteLine($"\n");
            Console.Write("Press any key to exit!");
            Console.ReadKey();
        }
    }
}
