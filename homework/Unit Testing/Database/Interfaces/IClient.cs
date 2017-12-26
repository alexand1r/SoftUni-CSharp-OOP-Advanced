using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Interfaces
{
    public interface IClient
    {
        IList<ITweet> Tweets { get; set; }

        string Tweet(ITweet tweet);

        string ShowLastTweet();
    }
}
