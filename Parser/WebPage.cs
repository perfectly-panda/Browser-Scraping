using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using DataAccess.Models;
using Parser.Functions;

namespace Parser
{
    public partial class WebPage
    {
        public void CreateWebPage(System.Windows.Forms.WebBrowser webBrowser, List<IgnoreList> ignoreList)
        {
            this.OriginalDocument = new HtmlDocument();
            this.InjectedDocument = new HtmlDocument();
            this.OriginalDocument.LoadHtml(webBrowser.DocumentText);

            this.InjectedDocument.LoadHtml(webBrowser.DocumentText);

            var children = this.InjectedDocument.DocumentNode.Descendants();

            var clean = children.Where(n => n.Name == "header" || n.Name == "footer").ToList();

            for (int i = clean.Count() - 1; i >= 0; i--)
            {
                clean[i].Remove();
            }

            this.Links = OriginalDocument.DocumentNode.Descendants().Where(e => e.Name == "a").ToList();

            this.Url = webBrowser.Url;
            this.Domain = webBrowser.Document.Domain;
        }

        public Uri Url { get; set; }

        public String Domain { get; set; }

        public List<HtmlNode> Links { get; set; }

        public HtmlDocument OriginalDocument { get; set; }

        public HtmlDocument InjectedDocument { get; set; }

        public String BlogLink { get; set; }

        public PageType PageType { get; set; }

        public List<string> TextAsList { get; set; }

        public int WordCount
        {
            get {
                return TextAsList.Count;
            }
        }

        public Dictionary<string, int> Keywords {get; set;}

        public override string ToString()
        {
            return this.OriginalDocument.DocumentNode.InnerHtml;
        }
    }
}
