using System;
using System.Collections.Generic;
using System.Text;

namespace _01_ProgramZaIzdavanjeRacuna
{
    class Product
    {
        #region Product properties
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        #endregion

        #region Product methods
        public decimal TotalPrice()
        {
            return Amount * Price;
        } 
        #endregion
    }
}
