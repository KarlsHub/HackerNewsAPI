using System.Collections.Generic;

namespace HackerNewsWebService
{
    /// <summary>
    /// Hacker News Story Item / resource
    /// </summary>
    public class HackerNewsStory
    {
        public string By { get; set; }      // story author
        public int Id { get; set; }         // story ID
        public List<int> Kids { get; set; } // comments
        public int Score { get; set; }      // story's score, or the votes for a pollopt
        public int Time { get; set; }       // creation date in Unix time
        public string Title { get; set; }   // story title 
        public string Type { get; set; }    // type = story
        public string Url { get; set; }     // story URL
    }
}
