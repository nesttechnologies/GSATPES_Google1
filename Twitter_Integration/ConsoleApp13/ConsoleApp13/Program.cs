using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToTwitter;
using System.Linq.Expressions;
using LinqToTwitter.Common;
namespace ConsoleApp13
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
                    OAuthToken = "120139909-ZdyoSXu8wsw1plYhVgQWB58ieCdv9p5tGoCxSw0t", //need this value from config.json file,  
                    OAuthTokenSecret = "wd0jneYWx4uOnLPfxJKEHZkz9fbqyGXYKTyAdUZKxLF20"

                }
            };

            //await authTwitter.AuthorizeAsync();
            var objTwitter = new TwitterContext(authTwitter);
            var statusTweets =
                from tweet in objTwitter.Status
                where tweet.Type == StatusType.User
                      && tweet.ID == 120139909 && tweet.Count == i_iCount  // ID for User
                select tweet;

            foreach (var tweet in statusTweets)
            {
                Console.WriteLine(tweet.Text);
                Console.WriteLine();
                
            }
            Console.ReadLine();
        }
        }
      
           
    }

    
