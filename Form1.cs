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
using DataMaintenance;

namespace Browser
{
    public partial class Form1 : Form
    {
        private ParsedWebpage Webpage { get; set; }

        public EventLog EventLog { get; set; }

        private ApplicationManager Manager {get; set;}


        public Form1(ApplicationManager manager)
        {
            InitializeComponent();

            EventLog = new EventLog(2000, new UpdateDelegate(SetLine));

            LogView.DataSource = EventLog.Log;

            this.Manager = manager;
            Manager.AddBrowser(webBrowser1);

            backgroundWorker1.RunWorkerAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.ReadyState != WebBrowserReadyState.Complete || e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
            {
                return;
            }
            else
            {
                EventLog.AppendLog("Page Loaded");

                ParsedWebpage Webpage =  await Manager.ReceiveWebpage();

                textBox2.Text = Webpage.Url.ToString();

                EventLog.AppendLog("Processing Complete");
                EventLog.AppendLog("Title: " + Webpage.PageTitle);
                EventLog.AppendLog("Domain: " + Webpage.Domain);
                EventLog.AppendLog("URL: " + Webpage.Url);
                EventLog.AppendLog("Links: " + Webpage.Links.Count());
                EventLog.AppendLog("Word Count: " + Webpage.WordCount.ToString());

                string blogLink = Webpage.BlogLink == null ? "No" : "Yes";
                EventLog.AppendLog("Blog Link: " + blogLink);
                if(Webpage.BlogLink != null)
                {
                    EventLog.AppendLog(Webpage.BlogLink);
                }

                if (Manager.Complete)
                {
                    button1.Enabled = true;
                }
                else
                {
                    Manager.ExecuteNextTask();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text))
            {
                EventLog.AppendLog("Navigating to " + textBox1.Text);
                webBrowser1.Navigate(textBox1.Text);
                button1.Enabled = false;
            }
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var jobManager = new JobManager();

            jobManager.Start();
        }
    }
}
