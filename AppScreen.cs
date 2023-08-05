using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finelproject
{
    class AppScreen : ILogin
    {
        public void menu()
        {
            Console.Clear();
            //sets the title of the console window
            Console.Title = "Supermarket";
            //sets the text color or foreground color to white
            Console.ForegroundColor = ConsoleColor.White;

            int option;
            string email;
            string pswwword;
            do
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\t\t--------------------------------------------------------");
                Console.WriteLine("\t\t\t|                                                       |");
                Console.WriteLine("\t\t\t|                     Wecome                            |");
                Console.WriteLine("\t\t\t|                                                       |");
                Console.WriteLine("\t\t\t--------------------------------------------------------");
                Console.WriteLine("\t\t\t\t\t|  1)- Administrator       |");
                Console.WriteLine("\t\t\t\t\t|  2)- Buyer               |");
                Console.WriteLine("\t\t\t\t\t|  3)- Exit                |");
                option = Validator.Convert<int>("Pleas select! ");
                switch (option)
                {
                    case 1:
                        login();
                        break;
                    case 2:
                        buyer();
                        break;
                    case 3:
                        Environment.Exit(0);
                        LogoutProgress();
                        break;
                    default:
                        Utility.PrintMessage("Please Select from the ginven options", false);
                        break;
                }
            } while (true);

        }
        void buyer()
        {
            Product prodect = new Product();
            do
            {
                Console.Clear();
                int option;
                Console.WriteLine("\n\n\t\t\t------------------------------------------------------");
                Console.WriteLine("\t\t\t|               Buyer menu                           |");
                Console.WriteLine("\t\t\t------------------------------------------------------");
                Console.WriteLine("\t\t\t\t\t|  1)- Buyer             |");
                Console.WriteLine("\t\t\t\t\t|                        |");
                Console.WriteLine("\t\t\t\t\t|  2)- Purchase          |");
                Console.WriteLine("\t\t\t\t\t|                        |");
                Console.WriteLine("\t\t\t\t\t|  3)- GO back           |");
                Console.WriteLine("\t\t\t\t\t|                        |");
                option = Validator.Convert<int>(" your choice");
                switch (option)
                {
                    case 1:
                        prodect.pulBuyer();

                        break;

                    case 2:
                        prodect.Purchase();
                        break;

                    case 3:
                        return;

                        break;

                    default:
                        Utility.PrintMessage("Please Select from the ginven options", false);
                        break;
                }
            } while (true);

        }
        void administrator()
        {

            Product prodect = new Product();
            do
            {
                Console.Clear();
                int option;
                Console.WriteLine("\t\t\t------------------------------------------------------");
                Console.WriteLine("\t\t\t|             Administrator menu                      |");
                Console.WriteLine("\t\t\t------------------------------------------------------");
                Console.WriteLine("\t\t\t\t\t| 1) Add the product     |");
                Console.WriteLine("\t\t\t\t\t|                        |");
                Console.WriteLine("\t\t\t\t\t| 2) Delete the product  |");
                Console.WriteLine("\t\t\t\t\t|                        |");
                Console.WriteLine("\t\t\t\t\t| 3) List  Product       |");
                Console.WriteLine("\t\t\t\t\t|                        |");
                Console.WriteLine("\t\t\t\t\t| 4) Back to Main menu   |");
                option = Validator.Convert<int>("Enter your choice");
                switch (option)
                {
                    case 1:
                        prodect.add();
                        break;

                    case 2:
                        prodect.remove();
                        break;

                    case 3:
                        prodect.ListProduct();
                        break;

                    case 4:
                        return;

                        break;

                    default:
                        Utility.PrintMessage("Please Select from the ginven options", false);
                        break;
                }
            } while (true);


        }

        static void LogoutProgress()
        {
            Console.WriteLine("Thank you for your Shopping from our store .");
            Utility.PrintDotAnimation();
            Console.Clear();
        }

        void LoginProgress()
        {
            Console.WriteLine("\nChecking Email  and Password...");
            Utility.PrintDotAnimation();
        }

        public void login()
        {
            Utility.PrintMessage("\t\t\tPlease login");
            string enmail = Utility.GetUserInput("Your Email Please");
            string password = Utility.GetSecretInput("Your password Please");
            LoginProgress();
            /*Abdullah@gmail.com*/
            if (Equals(enmail, "") && Equals(password, "123456"))
            {
                administrator();
            }
            else
            {
                Utility.PrintMessage("Invalid Eail or Password", false);
            }
        }
    }
}
