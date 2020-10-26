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

            try
            {
                //1753-2020
                ValidateYear(personalnr.Substring(0, 4));
                //Check if month is valid
                ValidateMonth(personalnr.Substring(4, 2));
                ////Check if day is valid for month
                //ValidateYear(personalnr.Substring(6, 2));
                ////YYYYMMDDnnnc check if nnn is 000-999 
                //ValidateYear(personalnr.Substring(8, 3));
                //Check gender
                gender = GenderCheck(personalnr.Substring(10, 1));
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Main();
            }
            
            //Print if personal number is correct and gender 
            Console.WriteLine("{0} är godkänt personnummer och personen är en {1}", personalnr, gender);
            Console.ReadKey();
        }
        
        static void UserInput()
        {
            Console.Write("Ange ditt personnummer: ");
        }
        //Check if 1753-2020 [method]
        static void ValidateYear(string yyyy)
        {

             int validYear;
             validYear = int.Parse(yyyy);
             if (validYear > 2020 || validYear < 1753)
             {
                 throw new ArgumentException("Date is not valid: " + validYear);
             }
            
            
           
        }
        //Validate month
        static void ValidateMonth(string mm)
        {
            int validMonth;
            validMonth = int.Parse(mm);
            if (validMonth > 12 || validMonth < 1)
            {
                throw new ArgumentException("Date is not valid: " + validMonth);
            }
        }
        //Validate day
        static void ValidateDay(string dd)
        {
            //Gonna need array for this
            int validDay31;            
            validDay31 = int.Parse(dd);
            if (validDay31 > 31 || validDay31 < 1)
            {
                throw new ArgumentException("Date is not valid: " + validDay31);
            }
            int validDay30;
            validDay30 = int.Parse(dd);
            if (validDay30 > 30 || validDay30 < 1)
            {
                throw new ArgumentException("Date is not valid: " + validDay30);
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
    }
}
