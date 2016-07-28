using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public partial class WebPage
    {
        private void FindBlogLink()
        {
            if (this.Links.Count > 0)
            {
                var blog = this.Links.Where(l => l.InnerText.ToLower().Contains("blog")).FirstOrDefault();

                if (blog == null)
                {
                    var check = "";
                }
                else
                {
                    BlogLink = blog.Attributes.Where(a => a.Name == "href").First().Value;
                }

            }
        }
    }
}
