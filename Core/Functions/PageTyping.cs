using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Core.Constants;
using Core.Entities;

namespace Core.Functions
{
     public static class PageTyping
    {
        public static PageType FindPageType(ParsedWebpage Webpage)
        {
            if (CheckForHomePage(Webpage)) return PageType.HomePage;
            if (CheckForBlogHomePage(Webpage)) return PageType.BlogHomePage;
            if (CheckForBlogPage(Webpage)) return PageType.BlogPage;

            return PageType.Page;
        }

        private static bool CheckForHomePage(ParsedWebpage Webpage)
        {
            var path = Webpage.Url.AbsolutePath;

            if (Webpage.SubDomain != "" && Webpage.SubDomain != "www") return false;

            if (path == "/") return true;
            if (path.StartsWith("/index")) return true;
            if (path.StartsWith("/home")) return true;

            return false;
        }

        private static bool CheckForBlogHomePage(ParsedWebpage Webpage)
        {
            var path = Webpage.Url.AbsolutePath;

            if (path == "/blog") return true;

            if (Webpage.SubDomain == "blog" && path == "/") return true;

            if (Webpage.Url.Segments.Last().Contains("blog") && Webpage.Url.Segments.Last().Length <= 20) return true;

            return false;
        }

        private static bool CheckForBlogPage(ParsedWebpage Webpage)
        {
            var path = Webpage.Url.AbsolutePath;

            if (path != "/blog" && path.StartsWith("/blog")) return true;
            if (Webpage.Url.Segments.Last().Contains("blog") && Webpage.Url.Segments.Last().Length > 20) return true;
            if (Webpage.SubDomain == "blog" && path != "/") return true;

            return false;
        }
    }
}
