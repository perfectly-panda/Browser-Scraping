using Parser;
using Autofac;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Core.Entities;
using Core;
using System;

namespace Manager
{
    public class ApplicationManager
    {
        private WebBrowser WebBrowser { get; set; }

        private Parse parser { get; set; }

        public bool Complete { get { return JobList == null || JobList.Count == 0; } }

        private List<JobList> JobList { get; set; }

        private Guid CurrentJob { get; set; }

        public void AddBrowser(WebBrowser webBrowser)
        {
            this.WebBrowser = webBrowser;
        }



        public async Task<ParsedWebpage> ReceiveWebpage()
        {
            this.parser =  new Parse();

            this.parser.ParseWebpage(WebBrowser);

            await CheckTaskList();

            return parser.ParsedWebpage;
        }

        public void ExecuteNextTask()
        {

        }

        public async Task<int> NewIgnoreListItem(string item)
        {
            return await Task.FromResult<int>(1);
        }

        private async Task CheckTaskList()
        {
            
        }

    }
}
