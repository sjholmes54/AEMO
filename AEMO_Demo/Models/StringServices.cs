using System;
using System.Collections.Generic;

namespace AEMO_Demo.Models
{
    public class StringServices
    {
        //Return list of start indexes where 'subtext' matches 'text'
        public IList<int> ReturnMatchingIndexes(string text, string subtext)
        {
            IList<int> returnList = new List<int>();
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(subtext))
            {
                return returnList;
            }

            for (int i = 0; i + subtext.Length <= text.Length; i++)
            {
                if (string.Equals(text.Substring(i, subtext.Length), subtext, StringComparison.OrdinalIgnoreCase))
                {
                    returnList.Add(i);
                }
            }
            return returnList;
        }
    }
}
