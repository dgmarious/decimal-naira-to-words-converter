namespace DecimalToWord.Converter
{
    public static partial class DecimalToWord
    {
        public static string GetKobo(int number)
        {
            string words = "";
            if (number/100 >=1)
            {
                words = GetAmountInWords(number / 100);

                words += " naira, "+ GetKobo(number % 100);
                return words;


            }
           

           

            var units = new[]
            {
                " ", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve",
                "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
            };
            var tens = new[]
                { " ", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20)
                words += units[number];
            else
            {
                words += tens[number / 10];

                if (number % 10 > 0)
                {
                    words += "-";

                    words += units[number % 10];
                }
            }

            return words + " kobo";
        }
    }
}
