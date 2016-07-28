using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public static class IgnoreListRepository
    {
        public async static Task<List<IgnoreList>> GetIgnoreList()
        {
            using (var db = new WebsiteDataContext())
            {
                List<IgnoreList> result = await (db.IgnoreList.Select(i => i)).ToListAsync();
                return result;
            }
        }

        public static async Task AddItemToIgnoreList(string item)
        {
            using (var db = new WebsiteDataContext())
            {
                try
                {
                    var check = await db.IgnoreList.Where(i => i.Value == item).FirstOrDefaultAsync();

                    if(check == null)
                    {

                        IgnoreList ignore = new IgnoreList();
                        ignore.Value = item;
                        ignore.Id = Guid.NewGuid();

                        db.IgnoreList.Add(ignore);

                        var result = await db.SaveChangesAsync();
                    }
                }
                catch
                {

                }
            }
        }

    }
}
