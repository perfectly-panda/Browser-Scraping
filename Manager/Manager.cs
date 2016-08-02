using DataAccess.Repository;
using Parser;
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
            Parse parser =  new Parse(webBrowser);

            return parser.WebPage;
        }

        public async Task NewIgnoreListItem(string item)
        {
            await IgnoreListRepository.AddItemToIgnoreList(item);
        }

    }
}
