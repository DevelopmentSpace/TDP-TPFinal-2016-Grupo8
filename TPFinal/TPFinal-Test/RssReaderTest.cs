using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPFinal.Model.RssReaderModel;
using TPFinal.Domain;

namespace TPFinal_Test
{
    /// <summary>
    /// Descripción resumida de RssReaderTest
    /// </summary>
    [TestClass]
    public class RssReaderTest
    {

        [TestMethod]
        public void SyndicationGetFeeds()
        {
            SyndicationFeedRssReader reader = new SyndicationFeedRssReader();

            IEnumerable<RssItem> items = reader.Read("http://contenidos.lanacion.com.ar/herramientas/rss/origen=2");
            Assert.IsNotNull(items);
            
        }

        [ExpectedException(typeof(Exception),AllowDerivedTypes=true)]
        [TestMethod]
        public void SyndicationGetFeedsInvalidUrl()
        {
            SyndicationFeedRssReader reader = new SyndicationFeedRssReader();

            IEnumerable<RssItem> items = reader.Read("http://wwww.google.com.ar");

        }
    }
}
