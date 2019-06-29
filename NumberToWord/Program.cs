using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NumberToWord
{
    class Program
    {
        /*
         * Expects the converted to work with comma seperated values
         */
        static void Main(string[] args)
        {
            string finalresult = NumberToWordConvertor.NumberToWordConvertorProgram("137,115");
            Console.WriteLine(finalresult);
            Console.ReadLine();
        }
        
    }
}
