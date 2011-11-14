using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Linq;
using Microsoft.Phone.Info;

namespace hm_services
{
  public class MainViewModel : INotifyPropertyChanged
  {
    private readonly string _newsUrl = "http://fi.cs.hm.edu/fi/rest/public/news.xml";
    private string _filter;
    
    public MainViewModel()
    {
      this.Items = new ObservableCollection<ItemViewModel>();
    }

    /// <summary>
    /// A collection for ItemViewModel objects.
    /// </summary>
    public ObservableCollection<ItemViewModel> Items { get; private set; }
    
    public void GetNewsItems(string filter)
    {
      this.Items.Clear();
      this._filter = filter;

      // initialize a new WebRequest
      HttpWebRequest newsrequest= (HttpWebRequest)WebRequest.Create(new Uri(_newsUrl));
      
      // set up the state object for the async request
      NewsItemUpdateState newsItemState = new NewsItemUpdateState();
      newsItemState.AsyncRequest = newsrequest;

      // start the asynchronous request
      newsrequest.BeginGetResponse(new AsyncCallback(HandleFirstResponseForTotal), newsItemState); // this is still main thread
    }

    /// <summary>
    /// Handle the first response returned from the async request
    /// </summary>
    /// <param name="asyncResult"></param>
    private void HandleFirstResponseForTotal(IAsyncResult asyncResult)  ///now this is background
    {
      // get the state information
      NewsItemUpdateState newsItemState = (NewsItemUpdateState)asyncResult.AsyncState;
      HttpWebRequest newsrequest = (HttpWebRequest)newsItemState.AsyncRequest;

      // end the async request
      newsItemState.AsyncResponse = (HttpWebResponse)newsrequest.EndGetResponse(asyncResult);

      Stream streamResult;
      ObservableCollection<ItemViewModel> newsItemList = new ObservableCollection<ItemViewModel>();

      try
      {
        // get the stream containing the response from the async call
        streamResult = newsItemState.AsyncResponse.GetResponseStream();

        // load the XML
        XElement xmlNewsItems = XElement.Load(streamResult);
        var xmlCurrent = xmlNewsItems.Descendants("newslist");
        //FIXME the xml parsing does not work...
        foreach (XElement news in xmlCurrent.Elements("news"))
        {
          ItemViewModel temp = new ItemViewModel();
          temp.Subject = news.Element("subject").Value;
          temp.Text = news.Element("text").Value;
          temp.Publish = DateTime.Parse(news.Element("publish").Value);
          temp.Expire = DateTime.Parse(news.Element("expire").Value);
          temp.TeacherCode = news.Element("teacher") != null ? news.Element("teacher").Value : null;
          newsItemList.Add(temp);
        }//background

        int sleepcounter = 2;
        int itemcounter = 0;
        foreach (ItemViewModel item in newsItemList)
        {
          itemcounter++;
          if (itemcounter % sleepcounter == 0)
          {
            System.Threading.Thread.Sleep(20);
          }
          var dummy = item;

          Deployment.Current.Dispatcher.BeginInvoke(() =>
          {
            this.Items.Add(dummy);
          });
        }
      }
      catch (Exception)
      {
        return;
        //TODO
      }
      long applicationCurrentMemoryUsage = (long)DeviceExtendedProperties.GetValue("ApplicationCurrentMemoryUsage");
    }


    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(String propertyName)
    {
      if (null != PropertyChanged)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
    #endregion

    /// <summary>
    /// State information for our NewsItemUpdateState async call
    /// </summary>
    public class NewsItemUpdateState
    {
      public HttpWebRequest AsyncRequest { get; set; }
      public HttpWebResponse AsyncResponse { get; set; }
    }
  }
}
