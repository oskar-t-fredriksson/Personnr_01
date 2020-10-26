using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnr_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int personalnr;
            //User input ["method"]
            UserInput();
            userInput = Console.ReadLine();
            personalnr = int.Parse(userInput);            
            //1753-2020 [method]

            //Check if month is valid [method]

            //Check if day is valid for month [method]

            //YYYYMMDDnnnc check if nnn is 000-999 [method]

            //Check gender [method]

            //Print if personal number is correct and gender [method]
            Console.ReadKey();
        }
        
        static void UserInput()
        {
            Console.Write("Ange ditt personnummer: ");
        }
    }
}
