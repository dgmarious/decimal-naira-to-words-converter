using System;
using System.Globalization;

namespace DecimalToWord.Converter
{
  public  static class DecimalToWordExtension
    {
        public static string ToWordString(this decimal amount)
        {
            if(amount == 0)
            {
                throw new InvalidOperationException("Amount must be greater than zero");
            }
            if (amount % 1 != 0)
            {
                var splits = amount.ToString(CultureInfo.InvariantCulture).Split('.');
                var result = DecimalToWord.GetAmountInWords(Convert.ToDecimal(splits[0]));

                if (!string.IsNullOrEmpty(result))
                {
                    result += " naira,  ";


                }
                result += DecimalToWord.GetKobo(Convert.ToInt32(splits[1])) + " only";


                return result.ToUpper();
            }

            var r = DecimalToWord.GetAmountInWords(amount) + " naira only";

            return r.ToUpper();
        }
    }
}