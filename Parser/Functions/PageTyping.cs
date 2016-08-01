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
        public static PageType FindPageType(WebPage webPage)
        {
            if (CheckForHomePage(webPage)) return PageType.HomePage;
            if (CheckForBlogHomePage(webPage)) return PageType.BlogHomePage;
            if (CheckForBlogPage(webPage)) return PageType.BlogPage;

            return PageType.Page;
        }

        private static bool CheckForHomePage(WebPage webPage)
        {
            var path = webPage.Url.AbsolutePath;

            if (path == "/") return true;
            if (path.StartsWith("/index")) return true;
            if (path.StartsWith("/home")) return true;

            return false;
        }

        private static bool CheckForBlogHomePage(WebPage webPage)
        {
            var path = webPage.Url.AbsolutePath;

            if (path == "/blog") return true;

            if (webPage.Url.Segments.Last().Contains("blog") && webPage.Url.Segments.Last().Length <= 20) return true;

            return false;
        }

        private static bool CheckForBlogPage(WebPage webPage)
        {
            var path = webPage.Url.AbsolutePath;

            if (path != "/blog" && path.StartsWith("/blog")) return true;
            if (webPage.Url.Segments.Last().Contains("blog") && webPage.Url.Segments.Last().Length > 20) return true;

            return false;
        }
    }
}
