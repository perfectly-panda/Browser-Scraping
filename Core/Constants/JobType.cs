using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public enum JobType
    {
        ReadWebpage = 0,
        ReadWebsite = 1,
        RebuildBaseKeywords = 2,
        RebuildWebpageKeywords = 3,
        RebuildWebsiteKeywords = 4,
        RebuildRelatedKeywords = 5,
        CheckLinks = 6
    }
}
