using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace HackerNewsWebService
{
    /// <summary>
    /// Rest Web Service wrapper for HackerNews
    /// </summary>
    public class HackerNews
    {
        #region Variables 
        const string _hackerNewsUrl = "https://hacker-news.firebaseio.com/v0";
        const string _bestStories = "beststories.json";
        const string _item = "item/{0}.json";

        private readonly RestClient _hackerNewsWebServiceClient;
        #endregion

        #region Constructor 
        public HackerNews()
        {
            _hackerNewsWebServiceClient = new RestClient(_hackerNewsUrl);
        }
        #endregion

        #region Web Service Calls
        /// <summary>
        /// Gets the story specified by the ID 
        /// </summary>
        /// <param name="id">ID of the story/resource</param>
        /// <returns>Hacker News Story object</returns>        
        public HackerNewsStory GetStoryById(long id)
        {
            RestRequest request = new RestRequest(string.Format(_item, id));
            IRestResponse<HackerNewsStory> response = _hackerNewsWebServiceClient.Execute<HackerNewsStory>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                // should probably use HttpResponseException
                throw new Exception(string.Format("StatusCode {0}: {1}", response.StatusCode.ToString(), response.ErrorMessage));
            }

            return response.Data;
        }

        /// <summary>
        /// Returns the IDs of the best stories
        /// </summary>
        /// <returns>The IDs of the Top 200 stories</returns>
        /// <remarks>There are more than 200 best stories but web service only seems to return that many</remarks>
        public List<long> GetBestStories()
        {
            RestRequest request = new RestRequest(_bestStories);
            IRestResponse<List<long>> response = _hackerNewsWebServiceClient.Execute<List<long>>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                // should probably use HttpResponseException
                throw new Exception(string.Format("StatusCode {0}: {1}", response.StatusCode.ToString(), response.ErrorMessage));
            }

            return response.Data;
        }
        #endregion
    }
}
