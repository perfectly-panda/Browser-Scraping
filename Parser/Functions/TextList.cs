using DataAccess.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parser.Functions
{
    public static class TextList
    {
        public static Dictionary<string, int>  CreateKeywordList(List<string> text, List<IgnoreList> ignoreList)
        {
            Dictionary<string, int> frequencies = new Dictionary<string, int>();

            List<string> list = ignoreList.Select(i => i.Value).ToList();



            foreach (string word in text)
            {
                if (!list.Contains(word))
                {
                    int freq;
                    frequencies.TryGetValue(word.ToLower(), out freq);
                    freq += 1;

                    frequencies[word] = freq;
                }
            }

            return frequencies.OrderByDescending(f => f.Value).ToDictionary(v => v.Key, v => v.Value);
        }

        public static List<string> CreateTextList(HtmlDocument document)
        {
            List<string> text = new List<string>();

            var check = new Regex("[a-zA-Z0-9]");

            var pattern = @"[\w]+";

            var elements = document.DocumentNode.ChildNodes.Where(n => n.Name == "html").First().ChildNodes.Where(h => h.Name == "body").First().Descendants();

            var nameIgnore = new List<string>() { "script", "style" };

            foreach (var element in elements
                .Where(e => e.NodeType == HtmlNodeType.Element && !nameIgnore.Contains(e.Name) && e.HasChildNodes)
                .SelectMany(el => el.ChildNodes).Where(elem => elem.NodeType == HtmlNodeType.Text))
            {
                if (!string.IsNullOrWhiteSpace(element.InnerText))
                {

                    text.AddRange(Regex.Matches(element.InnerText, pattern).Cast<Match>().Select(m => m.Value.ToLower().Trim()).Where(v => v.Length > 2).ToList());

                }
            }

            return text;
        }
    }
}
