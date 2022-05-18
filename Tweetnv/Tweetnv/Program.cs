using System;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;


namespace Tweetnv
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            //connect to twitterAPI
            var userCredentials = new TwitterCredentials("wvc3QL7GQV0SlyP3M3C1zxTyQ", "1MD3IayCxW6az7zwaUisDj1e2f35GACxwgsgBUy5HuBXAzw8Pl", "1507040615854444552-oE556nY9IT2ftgHnpw6h5GdUuRHLAN", "xfx3GQTsVC3JDfRK1jZ1PpPI0037PVa81ARqU8dDcRTs");
            var userClient = new TwitterClient(userCredentials);

            //keywords for twt collection
            var stream = userClient.Streams.CreateFilteredStream();
            stream.AddTrack("javascript");
            stream.AddTrack("python");
            stream.AddTrack("java");
            stream.AddTrack("c#");

            // Counters
            int c1 = 0;

            int c2 = 0;

            int c3 = 0;

            int c4 = 0;

            int twtcount = 1;

            // Filters
            string f1 = "javascript";

            string f2 = "python";

            string f3 = "java";

            string f4 = "c#";


            //twts found loop
            stream.MatchingTweetReceived += (sender, eventReceived) =>
            {
                //used for the counters or other uses of the keywords
                ITweet tweet = eventReceived.Tweet;
                string twttxt = eventReceived.Tweet.FullText;
                int x = tweet.FavoriteCount;
                string twtauthorname = tweet.CreatedBy.Name;

               

                //show twts
                Console.WriteLine("");
                Console.WriteLine(twtauthorname, " ", x);
                Console.WriteLine(eventReceived.Tweet);
                Console.WriteLine("");
                
                //show counters
                Console.WriteLine(f1,":", c1, ", ", f2, ":", c2, ", ", f3, ":", c3, ", ", f4, ":", c4);
                
                //counters
                if (twttxt.Contains(f1))
                {
                    c1++;
                }

                if (twttxt.Contains(f2))
                {
                    c2++;
                }

                if (twttxt.Contains(f3))
                {
                    c3++;
                }

                if (twttxt.Contains(f4))
                {
                    c4++;
                }

                //Terminate
                if (twtcount == 100)
                {
                    stream.Stop();
                    Console.WriteLine("Complite!");
                }

                twtcount++;

            };

            await stream.StartMatchingAnyConditionAsync();
        }
    }
}
