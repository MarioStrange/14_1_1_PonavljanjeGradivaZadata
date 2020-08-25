using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _01_ProgramZaIzdavanjeRacuna
{
    class Receipt : Product
    {
        #region Receipt constructor
        public Receipt()
        {
            Products = new List<Product>();
        } 
        #endregion

        #region Receipt properties
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public DateTime Date
        {
            get { return DateTime.Today; }
        }
        public string ReceiptNumber { get; set; }
        public List<Product> Products { get; }
        #endregion

        #region Receipt methods
        public void SaveToFile(Receipt receiptInput)
        {
            string file = @"C:\Users\malja\Desktop\Learning\HomeLearning\CSharp_HomeLearning\CSharp_ZbirkaZadataka\programReceipt.txt";

            FileStream stream = new FileStream(file, FileMode.Create);
            StreamWriter writer = new StreamWriter(stream);

            decimal totalPrice = 0;

            foreach (Product product in receiptInput.Products)
            {
                totalPrice += product.TotalPrice();
            }

            writer.WriteLine("---------------------RECEIPT---------------------------");
            writer.WriteLine("Customer: {0}", receiptInput.CustomerName);
            writer.WriteLine("Employee: {0}", receiptInput.EmployeeName);
            writer.WriteLine("Date: {0}", receiptInput.Date);
            writer.WriteLine("Receipt number: {0}", receiptInput.ReceiptNumber);
            writer.WriteLine("_____________________PRODUCTS__________________________");
            foreach (Product product in receiptInput.Products)
            {
                writer.WriteLine("------------------------------------------------");
                writer.WriteLine("Products: |{0}| |{1}| |{2}|", product.ProductName, product.Price, product.Amount);
            }

            writer.WriteLine("Receipt total price: {0} kn.", totalPrice);


            writer.Close();
        } 
        #endregion
    }
}
