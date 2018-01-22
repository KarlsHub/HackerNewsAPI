using System;
using System.Collections.Generic;
using HackerNewsWebService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    /// <summary>
    /// Unit tests for the HackerNews web service
    /// </summary>
    /// <remarks>Ok, so these are really weak tests but you have to start somewhere</remarks>
    [TestClass]
    public class WebServiceUnitTests
    {
        private HackerNews _hackerNews = null;
        private long _storyId = 16169236; // got this from a best story list .. hopefully it remains valid

        [TestMethod]
        public void TestGetBestStories()
        {
            _hackerNews = new HackerNews();
            List<long> storyIds = _hackerNews.GetBestStories();

            Assert.IsTrue(storyIds.Count > 0);
        }

        [TestMethod]
        public void GetStoryById()
        {
            _hackerNews = new HackerNews();
            HackerNewsStory story = _hackerNews.GetStoryById(_storyId);

            Assert.IsNotNull(story);
        }
    }
}
