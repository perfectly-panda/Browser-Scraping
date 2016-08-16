using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using Manager;
using Parser;
using Core;

namespace Browser
{
    public partial class Form1 : Form
    {
        private ParsedWebpage WebPage { get; set; }

        public EventLog EventLog { get; set; }

        private ApplicationManager Manager {get; set;}


        public Form1(ApplicationManager manager)
        {
            InitializeComponent();

            EventLog = new EventLog(2000, new UpdateDelegate(SetLine));

            LogView.DataSource = EventLog.Log;

            this.Manager = manager;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private  void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.ReadyState != WebBrowserReadyState.Complete || e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
            {
                return;
            }
            else
            {
                EventLog.AppendLog("Page Loaded");

                ParsedWebpage webPage =  Manager.ReceiveWebPage(webBrowser1);

                textBox2.Text = webPage.Url.ToString();

                EventLog.AppendLog("Processing Complete");
                EventLog.AppendLog("Title: " + webPage.PageTitle);
                EventLog.AppendLog("Domain: " + webPage.Domain);
                EventLog.AppendLog("URL: " + webPage.Url);
                EventLog.AppendLog("Links: " + webPage.Links.Count());
                EventLog.AppendLog("Word Count: " + webPage.WordCount.ToString());

                string blogLink = webPage.BlogLink == null ? "No" : "Yes";
                EventLog.AppendLog("Blog Link: " + blogLink);
                if(webPage.BlogLink != null)
                {
                    EventLog.AppendLog(webPage.BlogLink);
                }

                button1.Enabled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EventLog.AppendLog("Navigating to " + textBox1.Text);
            webBrowser1.Navigate(textBox1.Text);
            button1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void SetLine()
        {
            LogView.SetSelected(LogView.Items.Count - 1, true);
        }

        private async void addignore_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(IgnoreListEntry.Text))
            {
                await Manager.NewIgnoreListItem(IgnoreListEntry.Text);

                IgnoreListEntry.Text = null;
            }
        }
    }
}
