using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IWebPageRepository: IRepository<WebPage>
    {
        Task<WebPage> FindByUrl(string url);
    }
}
