using System;

namespace hm_services
{
  public class NewsItem
  {
    public string Subject { get; set; }
    public string Text { get; set; }
    public DateTime Publish { get; set; }
    public DateTime Expire { get; set; }
    public Uri URL { get; set; }
    public string Author { get; set; }
    public string Teacher { get; set; }

    public override string ToString()
    {
      return Subject + ": " + Text + " | " + Author + " | " + Teacher + " || " + Publish.ToShortDateString();
    }
  }
}
  