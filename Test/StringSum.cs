using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class StringSum : IStringSum
    {
        public string TryGetSum(string x, string y, out bool success)
        {
            success = default(bool);
            string sum = default(string);
            if (string.IsNullOrWhiteSpace(x) || string.IsNullOrWhiteSpace(y)) return sum;

            decimal decimalX;
            decimal decimalY;
            bool validX = GetDecimal(x, out decimalX);
            bool validY = GetDecimal(y, out decimalY);

            if (AreDecimalsValid(validX, validY)) return sum;
            if (IsMaxValueExceeded(decimalX, decimalY)) return sum;
            if (IsSumExceededMaxValue(decimalX, decimalY)) return sum;
            if (IsSumExceededMaxValue(decimalY, decimalX)) return sum;

            try
            {
                decimal result = decimalX + decimalY;
                sum = result.ToString();
                success = true;
            }
            catch
            {
                return sum;
            }

            return sum;
        }

        private bool GetDecimal(string argument, out decimal result)
        {
            return decimal.TryParse(argument.Trim(), out result);
        }

        private bool IsMaxValueExceeded(decimal x, decimal y)
        {
            return x > decimal.MaxValue || y > decimal.MaxValue;
        }

        private bool IsSumExceededMaxValue(decimal x, decimal y)
        {
            return x == decimal.MaxValue && y > 0;
        }

        private bool AreDecimalsValid(bool x, bool y)
        {
            return !x || !y;
        }
    }
}
