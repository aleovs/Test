using System;
using System.Linq;
using Xunit;
using Test;

namespace StringSumTest
{
    public class StringSumTest
    {
        private const string MaxValue = "79228162514264337593543950335";
        private const string NotDigit = "a1b";
        private const string NotDigitWithWhiteSpace = " aa  ";

        private IStringSum stringSum;
        

        public StringSumTest()
        {
            stringSum = new StringSum();
        }

        [Theory]
        [InlineData("-1", "0", "-1", true)]
        [InlineData("0", "-1", "-1", true)]
        [InlineData("0", "0", "0", true)]
        [InlineData("0", "1", "1", true)]
        [InlineData("1", "0", "1", true)]
        [InlineData("1", "2", "3", true)]
        [InlineData("12345678901234567890", "23232323232323232324", "35578002133557800214", true)]
        [InlineData(MaxValue, "0", MaxValue, true)]
        [InlineData("0", MaxValue, MaxValue, true)]
        public void GetSum_ValidXAndValidY_ReturnsSum(string x, string y, string sum, bool success)
        {
            string result = stringSum.TryGetSum(x, y, out success);
            Assert.Equal(sum, result);
            Assert.True(success);
        }

        [Theory]
        [InlineData(default(string), default(string), default(string), default(bool))]
        [InlineData(default(string), "1", default(string), default(bool))]
        [InlineData("1", default(string), default(string), default(bool))]
        [InlineData(NotDigit, default(string), default(string), default(bool))]
        [InlineData(default(string), NotDigit, default(string), default(bool))]
        [InlineData(NotDigit, NotDigit, default(string), default(bool))]
        [InlineData("", "", default(string), default(bool))]
        [InlineData(" ", " ", default(string), default(bool))]
        [InlineData(NotDigitWithWhiteSpace, "", default(string), default(bool))]
        [InlineData("", NotDigitWithWhiteSpace, default(string), default(bool))]
        [InlineData(MaxValue, 1, default(string), default(bool))]
        [InlineData(1, MaxValue, default(string), default(bool))]
        public void GetSum_InValidXValidY_ReturnsNull(string x, string y, string sum, bool success)
        {
            string result = stringSum.TryGetSum(x, y, out success);
            Assert.Equal(sum, result);
            Assert.False(success);
        }
    }
}
