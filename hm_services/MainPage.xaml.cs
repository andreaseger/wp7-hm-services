using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Data.Linq;

namespace hm_services
{
  public partial class MainPage : PhoneApplicationPage
  {
    // Constructor
    public MainPage()
    {
      InitializeComponent();

      this.Loaded += new RoutedEventHandler(MainPage_Loaded);
    }

    // Load data for the ViewModel Items
    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
      if (!App.CurrentApp.DB.DatabaseExists())
      {
        App.CurrentApp.DB.CreateDatabase();
        //TODO load new data from server
      }
      else
      {
        DataLoadOptions options = new DataLoadOptions();
        // eager loading of authors
        options.LoadWith<Data.Entry>(c => c.Authors);
        App.CurrentApp.DB.LoadOptions = options;
        var news = App.CurrentApp.DB.News.ToList();
      }
    }
  }
}