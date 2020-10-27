using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Personnr_01
{
    class Program
    {
        static void Main()
        {
            string personalnr;
            string gender = "";
            //User input 
            UserInput();
            personalnr = Console.ReadLine();
            //Run user input through following methodes to check if it is valid
            try
            {
                //1753-2020
                ValidateYear(personalnr.Substring(0, 4));
                //Check if month is valid
                ValidateMonth(personalnr.Substring(4, 2));
                ////Check if day is valid for month
                ValidateDay(personalnr.Substring(4, 2), personalnr.Substring(6, 2), personalnr.Substring(0, 4));
                ////YYYYMMDDnnnc check if nnn is 000-999 
                ValidateLastFour(personalnr.Substring(8, 3));
                //Check gender
                gender = GenderCheck(personalnr.Substring(10, 1));
                //Luhn-algorithm
                LuhnAlgo(personalnr.Substring(2, 9), personalnr.Substring(11, 1));
            }
            //If user input is incorrect, catch and write error, also rerun Main();
            catch(Exception e)
            {
                Console.WriteLine(e);
                Main();
            }
            
            //Print if personal number is correct and gender 
            Console.WriteLine("{0} är godkänt personnummer och personen är en {1}", personalnr, gender);
            Console.ReadKey();
        }
        #region My methodes for every calculation of personal number
        //Personal number question
        static void UserInput()
        {
            Console.Write("Ange ditt personnummer: ");
        }
        //Check if 1753-2020
        static void ValidateYear(string yyyy)
        {
             int validYear = int.Parse(yyyy);
             if (validYear > 2020 || validYear < 1753)
             {
                 throw new ArgumentException("Date is not valid: " + validYear);
             }
            
            
           
        }
        //Validate month
        static void ValidateMonth(string mm)
        {
            int validMonth = int.Parse(mm);
            if (validMonth > 12 || validMonth < 1)
            {
                throw new ArgumentException("Date is not valid: " + validMonth);
            }
        }
        //Validate day
        static void ValidateDay(string mm, string dd, string yyyy)
        {
            int year = int.Parse(yyyy);
            if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0))
            {
                int[] leapYearMaxDays = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                int monthDays = leapYearMaxDays[int.Parse(mm) - 1];
                int dayOfMonth = int.Parse(dd);

                if (dayOfMonth < 1 || dayOfMonth > monthDays)
                {
                    throw new ArgumentException("Date is not valid: " + dayOfMonth);
                }

            }
            else
            {
                int[] normalYearMaxDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                int monthDays = normalYearMaxDays[int.Parse(mm) - 1];
                int dayOfMonth = int.Parse(dd);

                if (dayOfMonth < 1 || dayOfMonth > monthDays)
                {
                    throw new ArgumentException("Date is not valid: " + dayOfMonth);
                }

            }
            

        }
        //Check if nnn is 000-999 
        static void ValidateLastFour(string nnn)
        {
            double validateLastFour = double.Parse(nnn);
            if (validateLastFour > 999 || validateLastFour < 0)
            {
                throw new ArgumentException("Date is not valid: " + validateLastFour);
            }
        }
        //Validate Gender
        static string GenderCheck(string gender)
        {

            if (int.Parse(gender) == 0)
            {
                return "Kvinna";
            }
            if (int.Parse(gender) % 2 == 0)
            {
                return "Kvinna";
            }
            return "Man";
          
        }
        //Run personal number through Luhn-algorithm
        static void LuhnAlgo(string personalnr, string controlNumber)
        {
            //Sum to calculate if valid or not
            int sum = 0;
            //Calculation of the 9 digits
            for (int i = 0; i < personalnr.Length; i++)
            {
                //Value of every index in personalnr
                int value = int.Parse(personalnr.Substring(i, 1));
                //Every digit time 2, else time 1 and wont need any calculation
                if (i % 2 == 0)
                {

                    int doubledValue = value * 2;
                    if (doubledValue > 9)
                    {
                        sum += doubledValue - 9;
                    }
                    else 
                    {
                        sum += doubledValue;
                    }
                    
                }
                else
                { 
                    sum += value;
                }
                
            }            
            double year = double.Parse(personalnr);
            double lastDigit = double.Parse(controlNumber);
            //Luhn Algrorithm
            if (!((10 - ( sum % 10)) % 10 == lastDigit))
            {
                throw new ArgumentException("Date is not valid: " + year);
            }
            
        }
        #endregion


    }
}
