using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public static class WebpageExtensions
    {
        public static string GetSubDomain(this Uri uri)
        {
            var subdomain = new StringBuilder();
            for (var i = 0; i < uri.Host.Split(new char[] { '.' }).Length - 2; i++)
            {
                //I use a ternary operator here...this could easily be converted to an if/else if you are of the ternary operators are evil crowd
                subdomain.Append((i < uri.Host.Split(new char[] { '.' }).Length - 3 &&
                                  uri.Host.Split(new char[] { '.' })[i + 1].ToLowerInvariant() != "www") ?
                                       uri.Host.Split(new char[] { '.' })[i] + "." :
                                       uri.Host.Split(new char[] { '.' })[i]);
            }
            return subdomain.ToString();
        }
    }

}
