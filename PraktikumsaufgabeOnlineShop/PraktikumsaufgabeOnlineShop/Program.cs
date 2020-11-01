using System;
using System.Dynamic;

namespace PraktikumsaufgabeOnlineShop
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * shop rules:
             * minimum order value >= 10.00€
             * free shipping: order value >= 30.00€
             * included tax for total order value 16%
             * shipping fee 3.90€
             */

            // all variables:
            // variable for spices of the shop
            const double pricePepper = 5.10, pricePaprika = 3.90, priceCurry = 4.50;
            // variable for tax
            const double tax = 0.16;
            // variable for shipping fee
            double shippingFee = 3.90;
            // variable for quantity ordered spices
            int quantityPepper = 0, quantityPaprika = 0, quantityCurry = 0;
            // variable for total amount of the order
            double totalAmount = 0.0,
                totalAmountWithShipping = 0.0,
                totalTax = 0.0,
                totalPepper = 0.0,
                totalPaprika = 0.0,
                totalCurry = 0.0;
            // variable for adding product; default value "nein" to avoid errors
            string yesNo = "nein";

            // output shop text
            Console.WriteLine("Herzlich Willkommen bei Scharfe Küche!\n");
            Console.WriteLine("Wie viele Gewürze möchten Sie käufen?");
            Console.Write($"{"Pfeffer",-10}(à {pricePepper,4:f2}€):   ");
            // input amount of each spice
            quantityPepper = Convert.ToInt32(Console.ReadLine());
            Console.Write($"{"Paprika",-10}(à {pricePaprika,4:f2}€):   ");
            quantityPaprika = Convert.ToInt32(Console.ReadLine());
            Console.Write($"{"Curry",-10}(à {priceCurry,4:f2}€):   ");
            quantityCurry = Convert.ToInt32(Console.ReadLine());

            // calculate values for order confirmation
            totalPepper = quantityPepper * pricePepper;
            totalPaprika = quantityPaprika * pricePaprika;
            totalCurry = quantityCurry * priceCurry;
            totalAmount = totalPepper + totalPaprika + totalCurry;

            // check if mimimum order value 
            if (totalAmount < 10.0) // check if total amount is lower than €10.00
            {
                Console.WriteLine("\nIhre Bestellung erreicht nicht den Mindestbestellwert von 10,00 Euro.");
            }
            else
            {
                if (totalAmount >= 25.0 && totalAmount < 30.0) // check for free shipping
                {
                    // show client that only a can pepper spice is needed for free shipping
                    Console.WriteLine($"\nIhnen fehlen noch {30 - totalAmount,4:f2} Euro bis zum kostenfreien Versand!");
                    Console.WriteLine("Wollen Sie noch eine Dose Pfeffer mehr bestellen und den Versand");
                    Console.WriteLine("sparen (ja|nein) ?"); // manual line break for better readability
                    yesNo = Convert.ToString(Console.ReadLine());

                    // check answer; all other answers are the same as "nein"
                    if (yesNo == "ja" || yesNo == "Ja" || yesNo == "JA" || yesNo == "jA")
                    {
                        quantityPepper += 1;
                        totalPepper += pricePepper;
                        totalAmount += pricePepper;
                    }
                }

                if (totalAmount >= 30.0) // set shipping fee to zero if total amount is equal or bigger than 30.0
                {
                    shippingFee = 0.0;
                }

                totalTax = totalAmount / (1 + tax) * tax;
                totalAmountWithShipping = totalAmount + shippingFee;

                // formated output oder confirmation
                Console.WriteLine("\nBestellbestätigung durch Scharfe Küche:");
                Console.WriteLine($"{"Pfeffer",-30}{quantityPepper,3} x {pricePepper,4:f2}{totalPepper,13:f2} EUR");
                Console.WriteLine($"{"Paprika",-30}{quantityPaprika,3} x {pricePaprika,4:f2}{totalPaprika,13:f2} EUR");
                Console.WriteLine($"{"Cury",-30}{quantityCurry,3} x {priceCurry,4:f2}{totalCurry,13:f2} EUR");
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine($"{"Zwischensumme",-45}{totalAmount,8:f2} EUR");
                Console.WriteLine($"{"Enthaltene MwST (16%)",-45}{totalTax,8:f2} EUR");
                Console.WriteLine($"{"Versandpauschale",-45}{shippingFee,8:f2} EUR");
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine($"{"Summe",-45}{totalAmountWithShipping,8:f2} EUR");

                // ask for any key to exit program
                Console.WriteLine($"\n");
                Console.Write("Press any key to exit!");
                Console.ReadKey();
            }
        }
    }
}
