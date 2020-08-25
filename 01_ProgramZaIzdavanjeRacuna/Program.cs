using System;
using System.Collections.Generic;

namespace _01_ProgramZaIzdavanjeRacuna
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("__________________ RECEIPT HEADING ____________________________");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine();

            Receipt receipt = new Receipt();

            // Receipt heading input, heading stays the same
            Console.WriteLine("Enter customer full name:");
            receipt.CustomerName = Console.ReadLine();
            Console.WriteLine("Enter employee full name:");
            receipt.EmployeeName = Console.ReadLine();
            Console.WriteLine("Enter receipt number:");
            receipt.ReceiptNumber = Console.ReadLine();
            Console.WriteLine("---------------------------------------------------------------");

            // Products input, more of them
            bool input = true;
            do
            {
                Product product = new Product();
                Console.WriteLine("_____________________________________________________________");
                Console.WriteLine("Enter product name:");
                product.ProductName = Console.ReadLine();
                Console.WriteLine("Enter amount:");
                product.Amount = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter price:");
                product.Price = int.Parse(Console.ReadLine());

                receipt.Products.Add(product);
                Console.WriteLine("_____________________________________________________________");
                Console.WriteLine("Do you want to add more products (y/n)?");
                string odabir = Console.ReadLine();
                if (odabir.ToLower() == "n")
                {
                    input = false;
                }
            } while (input);

            decimal totalPrice = 0;

            foreach (Product product1 in receipt.Products)
            {
                totalPrice += product1.TotalPrice();
            }

            // Console output of receipt and products
            Console.WriteLine("---------------------RECEIPT---------------------------");
            Console.WriteLine("Customer: {0}", receipt.CustomerName);
            Console.WriteLine("Employee: {0}", receipt.EmployeeName);
            Console.WriteLine("Date: {0}", receipt.Date);
            Console.WriteLine("Receipt number: {0}", receipt.ReceiptNumber);
            Console.WriteLine("_____________________PRODUCTS__________________________");
            ProductsOutput(receipt);

            Console.WriteLine("Receipt total price: {0} kn.", totalPrice);

            // Saving to file
            receipt.SaveToFile(receipt);



            Console.ReadLine();

        }

        private static void ProductsOutput(Receipt receipt)
        {
            foreach (Product product1 in receipt.Products)
            {
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Products: |{0}| |{1}| |{2}|", product1.ProductName, product1.Price, product1.Amount);
            }
        }
    }
}
