using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public partial class WebPage
    {
        private void CreateKeywordList(List<IgnoreList> ignoreList)
        {
            Dictionary<string, int> frequencies = new Dictionary<string, int>();

            List<string> list = ignoreList.Select(i => i.Value).ToList();



            foreach (string word in this.TextAsList)
            {
                if (!list.Contains(word))
                {
                    int freq;
                    frequencies.TryGetValue(word.ToLower(), out freq);
                    freq += 1;

                    frequencies[word] = freq;
                }
            }

            this.Keywords = frequencies.OrderByDescending(f => f.Value).ToDictionary(v => v.Key, v => v.Value);
        }
    }
}
