using Autofac;
using Core.Entities;
using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class WebsiteService: GenericService<Website, IWebsiteRepository>
    {
    }
}
