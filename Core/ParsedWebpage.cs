using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using Core.Entities;
using Core.Constants;
using Core.Functions;

namespace Core
{
    public partial class ParsedWebpage
    {
        public ParsedWebpage(System.Windows.Forms.WebBrowser webBrowser)
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

            this.PageTitle = webBrowser.DocumentTitle;

            this.Headers = new Dictionary<HeaderType, List<HtmlNode>>();
            FindHeaderNodes();
        }

        #region basic info
        public Uri Url { get; set; }

        public String Domain { get; set; }

        public String PageTitle { get; set; }

        public Dictionary<HeaderType, List<HtmlNode>> Headers { get; set; }

        public List<HtmlNode> Links { get; set; }

        public HtmlDocument OriginalDocument { get; set; }

        public HtmlDocument InjectedDocument { get; set; }

        public string SubDomain { get
            {
                return this.Url.GetSubDomain();
            }
        }
        #endregion

        #region calculated fields
        public String BlogLink { get; set; }

        public PageType PageType { get; set; }

        private List<string> _textAsList { get; set; }
        public List<string> TextAsList
        {
            get
            {
                if (_textAsList == null)
                {
                    _textAsList = TextList.CreateTextList(this.InjectedDocument);
                }

                return _textAsList;
            }
        }

        public int WordCount
        {
            get {
                if(TextAsList == null)
                {
                    _textAsList = TextList.CreateTextList(this.InjectedDocument);
                }

                return TextAsList.Count;
            }
        }

        public Dictionary<string, int> Keywords { get; set; }

        #endregion

        private void FindHeaderNodes()
        {
            var h1 = this.OriginalDocument.DocumentNode.Descendants().Where(n => n.Name.ToLower() == "h1");
            for(int i = 1; i <= 6; i++)
            {
                var nodes = this.OriginalDocument.DocumentNode.Descendants().Where(n => n.Name.ToLower() == "h"+i).ToList();


                Headers.Add( (HeaderType)Enum.Parse(typeof(HeaderType), "H" + i), nodes);
            }

            var bold = this.OriginalDocument.DocumentNode.Descendants().Where(n => n.Name.ToLower() == "b").ToList();

            Headers.Add((HeaderType)Enum.Parse(typeof(HeaderType), "B"), bold);
        }

        public override string ToString()
        {
            return this.OriginalDocument.DocumentNode.InnerHtml;
        }
    }
}