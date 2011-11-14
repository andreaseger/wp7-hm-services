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

      DataContext = App.ViewModel;

      this.Loaded += new RoutedEventHandler(MainPage_Loaded);
    }

    // Load data for the ViewModel Items
    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
      this.NewsListBox.Visibility = Visibility.Visible;

      App.ViewModel.Items.Clear();

      App.ViewModel.GetNewsItems("");

      this.NewsListBox.Focus();
      /*
      if (!App.CurrentApp.DB.DatabaseExists())
      {
        App.CurrentApp.DB.CreateDatabase();
      }
      else
      {
        var authors = App.CurrentApp.DB.Authors.ToList();
      }
      */
    }
  }
}