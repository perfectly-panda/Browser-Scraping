using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Parser.Functions
{
     public static class PageTyping
    {
        public static PageType FindPageType(HtmlDocument document)
        {
            return PageType.HomePage;
        }
    }
}
