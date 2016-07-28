using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mshtml;
using System.Diagnostics;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace Browser
{
    public partial class Form1 : Form
    {
        private WebPage WebPage { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebPage = null;

            WebPage = new WebPage(webBrowser1);

            LinkCount.Text = WebPage.Links.Count.ToString();
            WordCount.Text = WebPage.WordCount().ToString();
            textBox3.Text = WebPage.ToString();
            textBox2.Text = WebPage.Url.ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
            textBox2.Text = "Loading";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(WebPage != null)
            {
                textBox3.Text = WebPage.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (WebPage != null)
            {
                StringBuilder sb = new StringBuilder();

                var links = WebPage.Links;

                foreach (HtmlAgilityPack.HtmlNode link in links)
                {
                    var href = link.Attributes.Where(a => a.Name == "href").FirstOrDefault();

                    if(href != null)
                    {
                        sb.Append(href.Value);
                        sb.AppendLine();
                    }
                    
                }

                textBox3.Text = sb.ToString();
            }
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sb = webBrowser1.DocumentText;

             var match = "<header(.+)header>";

            var result = Regex.Replace(sb, match, string.Empty, RegexOptions.Singleline);

            webBrowser1.DocumentText = result;

            HtmlAgilityPack.HtmlDocument check = new HtmlAgilityPack.HtmlDocument();
            check.LoadHtml(webBrowser1.DocumentText);

             var children = check.DocumentNode.Descendants();

            var clean = children.Where(n => n.Name == "header" || n.Name == "footer").ToList();
            
            for (int i = clean.Count()-1; i >= 0; i--)
            {
                clean[i].Remove();
            }

            var after = children.Where(n => n.Name == "header" || n.Name == "footer").ToList();


            var Injection = true;
        }
    }

    public static class ParseHtml
    {
       public static int WordCount(System.Windows.Forms.HtmlDocument doc)
        {
            int wordCount = 0;

            var elements = doc.Links;

            var check = new Regex("[a-zA-Z0-9]");

            var pattern = @"[\S]+";

            foreach ( HtmlElement element in elements)
            {
                if (element.InnerText != null)
                {

                    var checkResult = Regex.Matches(element.InnerText, pattern).Cast<Match>().Select(m => m.Value).ToList();
                        //.Where(s => s.Length > 0 && check.IsMatch(s));

                    if(checkResult.Count() > 0)
                    {
                        wordCount += checkResult.Count();
                    }
                }
            }

           // var dict = new Dictionary<string, int>();

           // foreach (var word in file)
            //    if (dict.ContainsKey(word))
            //        dict[word]++;
            //    else
            //        dict[word] = 1;

            return wordCount;
        }
    }
}
