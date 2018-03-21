using System;
using System.Linq;
using Xunit;
using Test;

namespace StringSumTest
{
    public class StringSumTest
    {
        private const string MaxValue = "79228162514264337593543950335";
        private const string MinValue = "-79228162514264337593543950335";
        private const string NotDigit = "a1b";
        private const string NotDigitWithWhiteSpace = " aa  ";

        private IStringSum stringSum;
        
        public StringSumTest()
        {
            stringSum = new StringSum();
        }

        [Theory]
        [InlineData("-1", "-1", "-2")]
        [InlineData("-1", "0", "-1")]
        [InlineData("0", "-1", "-1")]
        [InlineData("0", "0", "0")]
        [InlineData("0", "1", "1")]
        [InlineData("1", "0", "1")]
        [InlineData("1", "2", "3")]
        [InlineData("12345678901234567890", "23232323232323232324", "35578002133557800214")]
        [InlineData(MaxValue, "0", MaxValue)]
        [InlineData("0", MaxValue, MaxValue)]
        [InlineData(MinValue, "0", MinValue)]
        [InlineData("0", MinValue, MinValue)]
        public void GetSum_ValidXAndValidY_ReturnsSum(string x, string y, string sum)
        {
            //arrange
            bool success;

            //act
            string result = stringSum.TryGetSum(x, y, out success);

            //assert
            Assert.Equal(sum, result);
            Assert.True(success);
        }

        [Theory]
        [InlineData(default(string), default(string), default(string))]
        [InlineData(default(string), "1", default(string))]
        [InlineData("1", default(string), default(string))]
        [InlineData(NotDigit, default(string), default(string))]
        [InlineData(default(string), NotDigit, default(string))]
        [InlineData(NotDigit, NotDigit, default(string))]
        [InlineData("", "", default(string))]
        [InlineData(" ", " ", default(string))]
        [InlineData(NotDigitWithWhiteSpace, "", default(string))]
        [InlineData("", NotDigitWithWhiteSpace, default(string))]
        [InlineData(MaxValue, 1, default(string))]
        [InlineData(1, MaxValue, default(string))]
        [InlineData(MinValue, -1, default(string))]
        [InlineData(-1, MinValue, default(string))]
        public void GetSum_InValidXValidY_ReturnsNull(string x, string y, string sum)
        {
            //arrange
            bool success;

            //act
            string result = stringSum.TryGetSum(x, y, out success);

            //assert
            Assert.Equal(sum, result);
            Assert.False(success);
        }
    }
}
