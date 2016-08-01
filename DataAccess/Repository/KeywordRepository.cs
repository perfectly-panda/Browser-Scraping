using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class KeywordRepository
    {
        public static async Task<int> AddKeyword(string keyword)
        {
            using (var db = new WebsiteDataContext())
            {
                try
                {
                    var check = await db.Keyword.Where(i => i.Value == keyword).FirstOrDefaultAsync();

                    if (check == null)
                    {

                        Keyword word = new Keyword();
                        word.Value = keyword;
                        word.Id = Guid.NewGuid();

                        db.Keyword.Add(word);

                        return await db.SaveChangesAsync();
                    }

                    return 0;
                }
                catch
                {

                }

                return -1;
            }
        }

            public static async Task<int> AddKeywords(List<string> keywords)
        {
            using (var db = new WebsiteDataContext())
            {
                try
                {
                    var check = await db.Keyword.Where(i => keywords.Contains(i.Value)).ToListAsync();

                    if (check.Count < keywords.Count)
                    {
                        List<Keyword> words = new List<Keyword>();
                        var filteredKeywords = keywords.Where(p => !check.Any(k=> k.Value == p));

                        foreach (var keyword in filteredKeywords) {
                            Keyword word = new Keyword();
                            word.Value = keyword;
                            word.Id = Guid.NewGuid();

                            db.Keyword.Add(word);
                        }
                        
                        return await db.SaveChangesAsync();
                    }
                    return 0;
                }
                catch
                {

                }

                return -1;
            }
        }

        public static async Task<int> AddKeywordsToWebsite(Dictionary<string, int> keywords, string domain)
        {
            using (var db = new WebsiteDataContext())
            {
                var website = db.Website.Where(w => w.Domain == domain).First();

                foreach (var keyword in keywords)
                {
                    Keyword check = await db.Keyword.Where(i => i.Value == keyword.Key).FirstOrDefaultAsync();

                    if (check == null)
                    {
                        await AddKeyword(keyword.Key);
                        check = await db.Keyword.Where(i => i.Value == keyword.Key).FirstOrDefaultAsync();
                    }

                    WebsiteKeywords checkWeb = await db.WebsiteKeywords.Where(i => i.Keyword.Id == check.Id && i.WebSite.Id == website.Id).FirstOrDefaultAsync();

                    if (checkWeb == null)
                    {
                        //counts are going to be a computed from webpage updates
                        //existing keywords can therefore be ignored at this point
                        WebsiteKeywords word = new WebsiteKeywords();
                        word.Keyword = check;
                        word.Id = Guid.NewGuid();
                        word.WebSite = website;

                        db.WebsiteKeywords.Add(word);

                    }
                }
                try
                {
                    return await db.SaveChangesAsync();
                }
                catch
                {

                }

                return -1;
            }
        }
    }
}
