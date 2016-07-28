using DataAccess;
using DataAccess.Models;
using DataAccess.Repository;
using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manager
{
    public class ApplicationManager
    {
        public async Task<Parser.WebPage> ReceiveWebPage(WebBrowser webBrowser)
        {
            Parser.WebPage webPage =  new Parser.WebPage();

            List<IgnoreList> ignoreList = await IgnoreListRepository.GetIgnoreList();

            webPage.CreateWebPage(webBrowser, ignoreList);

            return webPage;
        }

        public async Task NewIgnoreListItem(string item)
        {
            await IgnoreListRepository.AddItemToIgnoreList(item);
        }

    }
}
