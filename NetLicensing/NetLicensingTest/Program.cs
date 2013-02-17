using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetLicensing;
using System.IO;

namespace NetLicensingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "NetLicensing Test";

            Console.WriteLine("NetLicensing Test...");
            Console.WriteLine();

            Encryption enc = new Encryption();
            Networking net = new Networking();
            Validation val = new Validation();
            License lic = new License();

            string key1 = "1234567890123456";
            string key2 = "12345678901234567890123456789012";

            string[] keys = new String[] { "111-111-111", "222-222-222", "333-333-333" };

            string userkey;

            if (File.Exists("license.lli") == true)
            {
                Console.WriteLine("Found License File...");

                if (val.validateLicenseArray("license.lli", key1, key2, keys) == true)
                {
                    Console.WriteLine("Valid License!");
                }
                else
                {
                    Console.WriteLine("Invalid License!");
                }
            }
            else
            {
                Console.WriteLine("You need to license this product!");
                Console.WriteLine();
                Console.Write("Enter your product key: ");
                userkey = Console.ReadLine();

                if (val.validateKeyArray(userkey, keys) == true)
                {
                    lic.createLicenseFile("license.lli", userkey, key1, key2);
                    Console.WriteLine("Product licensed!");
                }
                else
                {
                    Console.WriteLine("Invalid Product Key!");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press a key to exit...");
            Console.ReadKey();




        }
    }
}
