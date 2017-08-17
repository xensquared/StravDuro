using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravDuro.Common
{
    public class Class1
    {
        public static string paddedString(string input, int sentenceLength)
        {
            var test = input.SafeSubstring(10, 1000);
            test = recurseSentencePadParse(input, sentenceLength, 0);
            return test;
        }

        private static string recurseSentencePadParse(string input, int sentenceLength, int startPosition)
        {
            var nextSentenceSet = input.ToArray()
                 .Select((i, j) => i == ' ' ? j : -1)
                 .Where(x => x > -1)
                 .Select(x => new paragraphIndex() { index = x, sentenceOrdinal = x / sentenceLength });

            if (nextSentenceSet.Count()>0) { 
                 var nextSentenceBreak = nextSentenceSet
                 .GroupBy(r => r.sentenceOrdinal)
                 .FirstOrDefault()
                 .Max(i => i.index)+1;

                 var toPad = input.SafeSubstring(startPosition, nextSentenceBreak).TrimEnd();
                 var padded = pad(toPad, sentenceLength); 
                 var remaining = input.SafeSubstring(nextSentenceBreak, input.Length);
                    
                 var recursePad = recurseSentencePadParse(remaining, sentenceLength, 0);

                 return toPad + "\n" + recursePad;
            }

            return input;
        }

        private static string pad(string input, int sentenceLength)
        {
            var strings = input.Split(' ');
            var spacesRemaining = sentenceLength - input.Length + strings.Length - 1;
            var output = "";

            for (int i = 0; i < strings.Length; i++)
            {
                int curSpaces = computeNextSpaces(strings, spacesRemaining, i);
                output += strings[i] + new string(' ', curSpaces);
                spacesRemaining -= curSpaces;
            }


            return output;
        }

        private static int computeNextSpaces(string[] strings, int spacesRemaining, int i)
        {
            var validDivide = (strings.Length - i - 1)> 0;
            return validDivide?(int)Math.Ceiling((1.0 * spacesRemaining) / (strings.Length - i - 1)):spacesRemaining;
        }

    }

    

    public static class extensionMethods
    {
        public static string SafeSubstring (this string target, int start, int length)
        {
            var safeLength = start + length >= target.Length ? target.Length - start : length;
            return target.Substring(start,safeLength);
        }
        
    }

    public class paragraphIndex
    {
        public int index { get; set; }
        public int sentenceOrdinal { get; set; }
    }
}
