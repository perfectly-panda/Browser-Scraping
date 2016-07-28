using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace Browser
{
    class WebPage
    {
        public WebPage(string html)
        {
            this.OriginalDocument = new HtmlDocument();
            this.InjectedDocument = new HtmlDocument();
            this.OriginalDocument.LoadHtml(html);

            this.InjectedDocument.LoadHtml(html);

            var children = this.InjectedDocument.DocumentNode.Descendants();

            var clean = children.Where(n => n.Name == "header" || n.Name == "footer").ToList();

            for (int i = clean.Count() - 1; i >= 0; i--)
            {
                clean[i].Remove();
            }


        }

        public Uri Url { get; set; }

        public HtmlDocument OriginalDocument { get; set; }

        public HtmlDocument InjectedDocument { get; set; }

        public int WordCount()
        {
            int result = 0;

            var check = new Regex("[a-zA-Z0-9]");

            var pattern = @"[\S]+";

            var elements = this.InjectedDocument.DocumentNode.ChildNodes.Where(n => n.Name == "html").First().ChildNodes.Where(h => h.Name == "body").First().Descendants();

            foreach (var element in elements.Where(e => e.NodeType == HtmlNodeType.Text))
            {
                if (element.InnerText != null)
                {

                    var checkResult = Regex.Matches(element.InnerText, pattern).Cast<Match>().Select(m => m.Value).ToList();
                    //.Where(s => s.Length > 0 && check.IsMatch(s));

                    if (checkResult.Count() > 0)
                    {
                        result += checkResult.Count();
                    }
                }
            }

            return result;
        }
    }
}
