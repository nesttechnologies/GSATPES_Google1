using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToTwitter;
using LinqToTwitter.Common;

namespace ConsoleApp15
{
    class Program
    {
        static void Main(string[] args)
            {
                ShowTweets("Vishakh_Rocks", 10);
            }
            private static void ShowTweets(string i_sUser, int i_iCount)
            {
                var authTwitter = new SingleUserAuthorizer
                {
                    CredentialStore = new SingleUserInMemoryCredentialStore
                    {
                        ConsumerKey = "4Kl5yOtTAl1tg6ItCtDFfhaxy",
                        ConsumerSecret = "pUQgM6XnP2GjDIgNIH5LavVeCJEZ6CltnuSNQxvZE62z8J1j4V",
                        OAuthToken = "120139909-ZdyoSXu8wsw1plYhVgQWB58ieCdv9p5tGoCxSw0t",
                        OAuthTokenSecret = "wd0jneYWx4uOnLPfxJKEHZkz9fbqyGXYKTyAdUZKxLF20"

                    }
                };
            var Twitter = new LinqToTwitter.TwitterContext(authTwitter);
            var untildate = new DateTime(2017, 7, 13);
            var srch =
             (from search in Twitter.Search
              where search.Type == SearchType.Search &&
                    search.Query == "Twitter" &&
                   search.GeoCode == "36.9710,-55.447967,500mi" &&
                   search.Until == untildate
             select search)
            .SingleOrDefault();

        Console.WriteLine("\nQuery: {0}\n", srch.SearchMetaData.Query);
            var count = 0;
            srch.Statuses.ForEach( entry => 
            Console.WriteLine(
                "ID: {0, -200}, Source: {1}\nContent: {2}\n",
                entry.StatusID, entry.Source, entry.Text));

            srch.Statuses.ForEach(entry =>
             count++);
            Console.WriteLine("count: " + count);
            
           Console.ReadKey();
            }
            
    }
}
