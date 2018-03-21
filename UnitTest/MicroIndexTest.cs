using System;
using System.IO;
using Test;
using Xunit;

namespace UnitTest
{
    public class MicroIndexTest
    {
        private IMicroIndex microIndex;
        private string testDirectoryPath;

        public MicroIndexTest()
        {
            testDirectoryPath = Environment.CurrentDirectory;
        }

        [Theory]
        [InlineData(@"Data\SearchData.txt", "a", "b", 4, 4, 19, 29, 41, 50)]
        public void Search_ValidInput_ReturnsMatchingResult(
            string filePath, 
            string x, 
            string y, 
            int numberOfWordsMatching,
            int positionsCount,
            string position1,
            string position2,
            string position3,
            string position4)
        {
            //arrange
            string absolutePath = GetAbsoluteFilePath(filePath);
            microIndex = new MicroIndex(absolutePath);

            //act
            SearchResult result = microIndex.Search(x, y);

            //assert
            Assert.Equal(numberOfWordsMatching, result.NumberOfWordsMatching);
            Assert.Equal(positionsCount, result.Positions.Count);
            Assert.Equal(position1, result.Positions[0]);
            Assert.Equal(position2, result.Positions[1]);
            Assert.Equal(position3, result.Positions[2]);
            Assert.Equal(position4, result.Positions[3]);
        }

        [Theory]
        [InlineData(@"Data\SearchData.txt", "a1", "b1", 0, 0)]
        [InlineData("", default(string), default(string), 0, 0)]
        public void Search_ValidInput_ReturnsNotFoundMatchingResult(
            string filePath,
            string x,
            string y,
            int numberOfWordsMatching,
            int positionsCount)
        {
            //arrange
            string absolutePath = GetAbsoluteFilePath(filePath);
            microIndex = new MicroIndex(absolutePath);

            //act
            SearchResult result = microIndex.Search(x, y);

            //assert
            Assert.Equal(numberOfWordsMatching, result.NumberOfWordsMatching);
            Assert.Equal(positionsCount, result.Positions.Count);
        }

        private string GetAbsoluteFilePath(string filePath)
        {
            return Path.Combine(testDirectoryPath, filePath);
        }
    }
}
