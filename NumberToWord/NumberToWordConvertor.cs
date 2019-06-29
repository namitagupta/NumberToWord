using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWord
{
   public static class NumberToWordConvertor
    {

        static Dictionary<char, string> TenthDictionary = new Dictionary<char, string>
        {
            {'0', "zeroth" },
            {'1', "Ten"},
            {'2', "Twenty"},
            {'3', "Thirty"},
            {'4', "Forty"},
            {'5', "Fifty"},
            {'6', "Sixty"},
            {'7', "Seventy"},
            {'8',"Eighty" },
            {'9',"Ninty" }
        };

        static Dictionary<char, string> OnesDictionary = new Dictionary<char, string>
        {
            {'0', "Zero"},
            {'1', "one"},
            {'2', "Two"},
            {'3', "Three"},
            {'4', "Four"},
            {'5', "Five"},
            {'6', "Six"},
            {'7',"Seven" },
            {'8',"Eight" },
            {'9', "Nine" }
        };

        static Dictionary<string, string> ElevenNinteen = new Dictionary<string, string>
        {
            {"11", "Eleven"},
            {"12", "Twelve"},
            {"13", "Thirteen"},
            {"14", "Fourteen"},
            {"15", "Fifteen"},
            {"16", "Sixten"},
            {"17", "Seventeen"},
            {"18","Eighteen" },
            {"19","Nineteen" }
        };

        public static string NumberToWordConvertorUptoLength3(string num)
        {
            int numLength = num.Length;
            if(numLength > 3)
            {
                throw new Exception("Invalid NumberLenght");
            }

            if(numLength == 3)
            {
                return hundrethConversion(num[0], num[1], num[2]);

            }
            else if(numLength == 2)
            {
                return TensConversion(num[0], num[1]);

            }
             else if(numLength == 1)
            {
                return OnesConversion(num[0]);
            }
            return string.Empty;
        
        }
        private static string hundrethConversion(char hundreth, char tenthNum, char onesNum)
        {
            string combinedString = string.Empty;
            string hundrethSrting = OnesConversion(hundreth) + " Hundred";
            string tenthString = TensConversion(tenthNum, onesNum);
            combinedString = hundrethSrting + " " + tenthString;
            return combinedString;
        }
        private static string TensConversion(char tenthNum, char onesNum)
        {
            string combinedString = string.Empty;
            string tenthString = TenthDictionary[tenthNum];
            if (onesNum != '0')
            {
                string onesString = OnesConversion(onesNum);
                combinedString = tenthString + " " + onesString;
            }
            else
            {
                combinedString = tenthString;
            }
            if (tenthNum == '1' && onesNum != '0')
            {
                combinedString = ElevenNinteen[tenthNum.ToString() + onesNum.ToString()];
            }
            if(tenthNum == '0')
            {
                combinedString = OnesConversion(onesNum);
            }
            return combinedString;
        }
        private  static string OnesConversion(char num)
        {           
            if(num == '0')
            {
                return string.Empty;
            }
            return OnesDictionary[num];
        }
        public static string NumberToWordConvertorProgram(string number)
        {
            string result = string.Empty;
            string[] numberList = number.Split(',');
            if(numberList.Length >= 1)
            {
                string hundredsWord = NumberToWordConvertorUptoLength3(numberList[numberList.Length-1]);
                result = hundredsWord;
            }
            if (numberList.Length >= 2)
            {
                string thousandWord = NumberToWordConvertorUptoLength3(numberList[numberList.Length - 2]);
                result = thousandWord + " Thousands "  + result;
            }
            if (numberList.Length >= 3)
            {
                string millionsWord = NumberToWordConvertorUptoLength3(numberList[numberList.Length - 3]);
                result = " " + millionsWord + " Millions " + result;
            }
            return result;
        }
    }
}
