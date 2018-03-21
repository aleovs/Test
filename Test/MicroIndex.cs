﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test
{
    public class MicroIndex : IMicroIndex
    {
        private string filePath;

        public MicroIndex(string filePath)
        {
            this.filePath = filePath;
        }

        public SearchResult Search(string x, string y)
        {
            SearchResult searchResult = new SearchResult();
            if (string.IsNullOrWhiteSpace(x) || string.IsNullOrWhiteSpace(y)) return searchResult;

            string fileContent = GetFileContent(filePath);
            if (string.IsNullOrWhiteSpace(fileContent)) return searchResult;

            string argumentX = x.Trim();
            string agrumentY = y.Trim();
            string pattern = $"{argumentX}[ ]{{1,}}{agrumentY}|{agrumentY}[ ]{{1,}}{argumentX}";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            var matches = regex.Matches(fileContent);
            if (matches.Count > 0)
            {
                foreach (Match match in regex.Matches(fileContent))
                {
                    searchResult.Positions.Add(match.Index.ToString());
                }
                searchResult.NumberOfWordsMatching = matches.Count;
            }
                                 
            return searchResult;
        }

        private string GetFileContent(string filePath)
        {
            string fileContent = default(string);

            if (string.IsNullOrWhiteSpace(filePath)) return fileContent;
            if (!File.Exists(filePath)) return fileContent;

            try
            {
                fileContent = File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                Console.WriteLine("An exception has been occurred");
            }
            
            return fileContent;
        }
    }
}
