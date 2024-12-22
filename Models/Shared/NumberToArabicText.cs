namespace aspcore.Models.Shared
{
    public class NumberToArabicText
    {
        private static readonly string[] unitsMap = { "", "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة" };
        private static readonly string[] tensMap = { "", "عشرة", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون" };
        private static readonly string[] hundredsMap = { "", "مائة", "مائتان", "ثلاثمائة", "أربعمائة", "خمسمائة", "ستمائة", "سبعمائة", "ثمانمائة", "تسعمائة" };

        public static string ConvertToArabicText(long number)
        {
            if (number == 0)
                return "صفر";

            string result = "";

            if (number >= 1000000)
            {
                long millions = number / 1000000;
                result += GetArabicNumber(millions) + " مليون";
                number %= 1000000;
                if (number > 0)
                    result += " و";
            }

            if (number >= 1000)
            {
                long thousands = number / 1000;
                result += GetArabicNumber(thousands) + " ألف";
                number %= 1000;
                if (number > 0)
                    result += " و";
            }

            if (number > 0)
            {
                result += GetArabicNumber(number);
            }

            return result;
        }

        private static string GetArabicNumber(long number)
        {
            if (number < 10)
                return unitsMap[number];
            else if (number < 100)
                return GetArabicTens(number);
            else if (number < 1000)
                return GetArabicHundreds(number);

            return "";
        }

        private static string GetArabicTens(long number)
        {
            if (number < 20)
            {
                if (number == 10)
                    return tensMap[1];
                else
                    return unitsMap[number % 10] + " " + tensMap[1];
            }
            else
            {
                long units = number % 10;
                string result = tensMap[number / 10];
                if (units > 0)
                    result = unitsMap[units] + " و" + result;
                return result;
            }
        }

        private static string GetArabicHundreds(long number)
        {
            long hundreds = number / 100;
            long remainder = number % 100;

            string result = hundredsMap[hundreds];
            if (remainder > 0)
                result += " و" + GetArabicTens(remainder);

            return result;
        }


    }

}
