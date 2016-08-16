using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Core.Functions
{
    public static class Navigation
    {
        public static string BlogLink(List<HtmlNode> links)
        {
            if (links.Count > 0)
            {
                var blog = links.Where(l => l.InnerText.ToLower().Contains("blog")).FirstOrDefault();

                if (blog != null)
                {
                    return blog.Attributes.Where(a => a.Name == "href").First().Value;
                }

            }

            return null;
        }
    }
}
