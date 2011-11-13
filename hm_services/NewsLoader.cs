using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using System.Collections.Generic;

namespace hm_services
{
  public class NewsLoader
  {
    private string news_url = "http://fi.cs.hm.edu/fi/rest/public/news.xml";
    private Dictionary<string, string> names;

    public NewsLoader() { }
    public void fetch_news()
    {
      var wc = new WebClient();
      wc.DownloadStringAsync(new Uri(news_url));
      wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_NewsDownloadStringCompleted);
    }
    void wc_NewsDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
      var xmlData = e.Result;
      XDocument dataDoc = XDocument.Load(new StringReader(xmlData));

      var news = from news_item in dataDoc.Descendants("newslist")
                 let stamp = DateTime.Parse(news_item.Attribute("publish").Value)
                 orderby stamp ascending
                 select new NewsItem
                 {
                   Text = news_item.Attribute("text").Value,
                   Subject = news_item.Attribute("subject").Value,
                   Author = news_item.Attribute("author").Value,
                   Teacher = news_item.Attribute("teacher").Value,
                   Publish = DateTime.Parse(news_item.Attribute("publish").Value),
                   Expire = DateTime.Parse(news_item.Attribute("expire").Value),
                   URL = new Uri(news_item.Attribute("url").Value)
                 };

      foreach (var news_item in news)
      {
        if (!names.Keys.Contains(news_item.Teacher))
          names.Add(news_item.Teacher, null);
        if (!names.Keys.Contains(news_item.Author))
          names.Add(news_item.Author, null);
      }

      foreach (var name in names.Keys)
      {
        var wc = new WebClient();
        wc.DownloadStringAsync(new Uri("http://fi.cs.hm.edu/fi/rest/public/person/name/" + name + ".xml"));
        wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_NamesDownloadStringCompleted);
      }
    }
    void wc_NamesDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
      var xmlData = e.Result;
      XDocument dataDoc = XDocument.Load(new StringReader(xmlData));
      var author = from person in dataDoc.Descendants("person")
                   select new Data.Author
                   {
                     Title = person.Attribute("title").Value,
                     FirstName = person.Attribute("firstname").Value,
                     LastName = person.Attribute("lastname").Value,
                     Code = "foo"
                   };
    }
  }
}
