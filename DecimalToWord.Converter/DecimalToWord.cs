using System;
using System.Globalization;

#region (c) Dominic Marius

/// <summary>
/// Get the decimal naira amount specified in word format
/// </summary>
#endregion
namespace DecimalToWord.Converter
{
   
    public static partial class DecimalToWord
    {
       public static string GetAmountInWords(decimal amount)
        { 
            string words = "";

            if (amount == 0)
                return words;


            object[,] values =
            {
                { 1000000000000 ,  " trillion " },
                { 1000000000 ,  " billion " },
                { 1000000 ,  " million " },
                { 1000 ,  " thousand " },
                { 100 , " hundred " },

            };

            for (int v = 0; v < values.GetLength(0); v++)
            {
                int i = 1;
                
                    var t = Convert.ToDecimal(values[v, 0]);
                    var s = values[v, i];
                    if (amount / t >= 1)
                    {
                        words += GetAmountInWords(amount / t) + s;
                        amount %= t;
                    }
                
            }
        
     
            switch (amount >= 1)
            {
                case true:
                {
                        if (words != "")
                            words += " and ";

                        var units = new[]
                    {
                        "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven",
                        "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
                    };
                    var tens = new[]
                        { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                    switch (amount < 20)
                    {
                        case true:
                            words += units[(int)amount];
                            break;
                        default:
                        {
                            words += tens[(int)amount / 10];
                            switch ((amount % 10) > 0)
                            {
                               
                                case true:
                                    words += "-" + units[(int)amount % 10];
                                    break;
                            }

                            break;
                        }
                    }

                    break;
                }
            }


            return words ;
        }

       
    }

   
}