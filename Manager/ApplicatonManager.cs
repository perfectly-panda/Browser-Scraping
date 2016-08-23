using Parser;
using Autofac;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Core.Entities;
using Core;

namespace Manager
{
    public class ApplicationManager
    {
        private Parse parser { get; set; }

        private List<JobList> JobList { get; set; }

        public ParsedWebpage ReceiveWebPage(WebBrowser webBrowser)
        {
            this.parser =  new Parse();

            this.parser.ParseWebpage(webBrowser);

            return parser.Webpage;
        }

        public async Task<int> NewIgnoreListItem(string item)
        {
            return await Task.FromResult<int>(1);
        }

    }
}
