using DataAccess.Models;
using DataAccess.Repository;
using Parser.Functions;
using System.Collections.Generic;
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



            webPage.TextAsList = TextList.CreateTextList(webPage.InjectedDocument);
            webPage.BlogLink = Navigation.BlogLink(webPage.Links);
            webPage.Keywords = TextList.CreateKeywordList(webPage.TextAsList, ignoreList);
            webPage.PageType = PageTyping.FindPageType(webPage);

            return webPage;
        }

        public async Task NewIgnoreListItem(string item)
        {
            await IgnoreListRepository.AddItemToIgnoreList(item);
        }

    }
}
