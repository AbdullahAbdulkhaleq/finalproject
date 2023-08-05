using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using finelproject;
using ConsoleTables;

namespace finelproject
{
    class Product: category
    {
        internal const string cur = "$ ";

        int procode;
        decimal price;
        decimal dis;
        public string Name { get; set; }


        public int Procode
        {
            get { return procode; }
            set { procode = value; }
        }
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public void add()
        {

            
            Console.WriteLine("\n\n\t\t\t------------------Add New Product------------------");
            procode=Validator.Convert<int>("Product code of The Product ");
            Name   = Utility.GetUserInput("Name of The Product");
            price  = Validator.Convert<decimal>("Price of The product ");
            CategoryId = Validator.Convert<int>("Category Id of The product ");
            CategoryName = Utility.GetUserInput("Category Name of The product ");
            dis    = Validator.Convert<decimal>("Discount of The Product ");

            try
            {
                File.AppendAllText("Product.txt", this.procode + ";" + this.Name + ";" + this.CategoryId + ";" + this.CategoryName + ";" + this.price + ";" + this.dis + "\n");
                Utility.PrintMessage("A column has been added", true);
            }
            catch (Exception)
            {
                Utility.PrintMessage("Not added", true);
            }
        }

        public void remove()
        {
            int key = Validator.Convert<int>("ID");
            bool removed = false;

            try
            {
                string[] list = File.ReadAllLines("Product.txt");

                foreach (string line in list)
                {
                    string[] n = line.Split(';');

                    if (int.Parse(n[0]) != key)
                        File.AppendAllText("temp.txt", n[0] + ";" + n[1] + ";" + n[2] + ";" + n[3] + ";" + n[4] + ";" + n[5] + "\n");
                    else
                        removed= true;

                }

                File.Delete("Product.txt");
                File.Move("temp.txt", "Product.txt");
                File.Delete("temp.txt");

            }
            catch (Exception a)
            {
                Console.WriteLine(a.Message);
            }
            if(removed)
                Utility.PrintMessage("Deleted successfully", true);
            else
                Utility.PrintMessage("not fund", false);

        }
        public void ListProduct()
        {
            Console.Clear();
            try
            {
                string[] list = File.ReadAllLines("Product.txt");
                var table = new ConsoleTable("Product Id", "Product Name", "category Id", "category Name", "Price", "Discount");
                foreach (string line in list)
                {
                    string[] n = line.Split(';');

                    table.AddRow(n[0], n[1], n[2], n[3], cur + n[4], n[5]);
                }
                table.Write();
                Console.ReadLine();
            }
            catch (Exception a)
            {

                Console.WriteLine(a.Message);
            }
            
        }
        public void pulBuyer()
        {
            Console.Clear();
            ListProduct();
            bool falid = true;
            Console.WriteLine("Enter 0 to exit ");
            do
            {
                int key = Validator.Convert<int>("Product Id to Purchase ");
                if (key == 0)
                    falid = false;
                try
                {

                    string[] list = File.ReadAllLines("Product.txt");
                    foreach (string line in list)
                    {
                        string[] n = line.Split(';');
                        if (key==int.Parse(n[0]))
                            File.AppendAllText("Purchase.txt", n[0] + ";" + n[1] + ";" + n[2] + ";" + n[3] + ";" + n[4] + ";" + n[5] + "\n");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("you dont hav any Purchase");
                    Console.ReadKey();
                }

            } while (falid); 
        }

        public void Purchase()
        {

            Console.Clear();
            try
            {

                string[] list = File.ReadAllLines("Purchase.txt");

                var table = new ConsoleTable("Product Id", "Product Name", "category Id", "category Nam", "Price", "Discount");
                decimal totalprice = 0;
                foreach (string line in list)
                {
                    string[] n = line.Split(';');
                    totalprice += Convert.ToDecimal(n[4]);
                    table.AddRow(n[0], n[1], n[2], n[3], cur + n[4], n[5]);
                }
                table.Write();
                Utility.PrintMessage($"The Total Value Of Your Purchase {cur+totalprice}");
                File.Delete("Purchase.txt");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("you dont hav any Purchase");
                Console.ReadKey();
            }

        }
    }
}
