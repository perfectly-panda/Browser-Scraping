
using DataAccess;
using Core.Entities;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Parser
{
    public class Parse
    {
        public ParsedWebpage Webpage { get; set; }

        public async void ParseWebpage(System.Windows.Forms.WebBrowser webBrowser)
        {
            this.Webpage = new ParsedWebpage(webBrowser);

            await SaveWebpage();
        }

        private Task SaveWebpage()
        {
            return Task.FromResult(0);
        }
    }
}
