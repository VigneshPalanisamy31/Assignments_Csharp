﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Banking_System
{
    internal class Validator
    {
        /// <summary>
        /// Function to validate user-entered amount.
        /// </summary>
        /// <returns></returns>
        public static double GetValidAmount()
        {
            while (true)
            {
                string value = Console.ReadLine();
                if (!Regex.IsMatch(value, @"^\d+(\.\d{1,2})?$"))

                {
                    Console.WriteLine("Please enter a valid amount: [Rupees and paise]");

                }
                else
                {
                    double.TryParse(value, out double amount);
                    return amount;
                }
                

            }
            
        }
       
    }
}
