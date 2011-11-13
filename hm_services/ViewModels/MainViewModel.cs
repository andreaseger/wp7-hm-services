using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace hm_services
{
  public class MainViewModel : INotifyPropertyChanged
  {
    public MainViewModel()
    {
      this.News = new ObservableCollection<NewsViewModel>();
    }

    /// <summary>
    /// A collection for NewsViewModel objects.
    /// </summary>
    public ObservableCollection<NewsViewModel> News { get; private set; }

    private string _sampleProperty = "Sample Runtime Property Value";
    /// <summary>
    /// Sample ViewModel property; this property is used in the view to display its value using a Binding
    /// </summary>
    /// <returns></returns>
    public string SampleProperty
    {
      get
      {
        return _sampleProperty;
      }
      set
      {
        if (value != _sampleProperty)
        {
          _sampleProperty = value;
          NotifyPropertyChanged("SampleProperty");
        }
      }
    }

    public bool IsDataLoaded
    {
      get;
      private set;
    }

    /// <summary>
    /// Creates and adds a few NewsViewModel objects into the News collection.
    /// </summary>
    public void LoadData()
    {
      // Sample data; replace with real data
      this.News.Add(new NewsViewModel() { Subject = "runtime one", Authors = "Maecenas praesent accumsan bibendum", Text = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu" });
      this.News.Add(new NewsViewModel() { Subject = "runtime two", Authors = "Dictumst eleifend facilisi faucibus", Text = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus" });
      this.News.Add(new NewsViewModel() { Subject = "runtime three", Authors = "Habitant inceptos interdum lobortis", Text = "Habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent" });
      this.News.Add(new NewsViewModel() { Subject = "runtime four", Authors = "Nascetur pharetra placerat pulvinar", Text = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos" });
      this.News.Add(new NewsViewModel() { Subject = "runtime five", Authors = "Maecenas praesent accumsan bibendum", Text = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur" });
      this.News.Add(new NewsViewModel() { Subject = "runtime six", Authors = "Dictumst eleifend facilisi faucibus", Text = "Pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent" });
      this.News.Add(new NewsViewModel() { Subject = "runtime seven", Authors = "Habitant inceptos interdum lobortis", Text = "Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat" });
      this.News.Add(new NewsViewModel() { Subject = "runtime eight", Authors = "Nascetur pharetra placerat pulvinar", Text = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum" });
      this.News.Add(new NewsViewModel() { Subject = "runtime nine", Authors = "Maecenas praesent accumsan bibendum", Text = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu" });
      this.News.Add(new NewsViewModel() { Subject = "runtime ten", Authors = "Dictumst eleifend facilisi faucibus", Text = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus" });
      this.News.Add(new NewsViewModel() { Subject = "runtime eleven", Authors = "Habitant inceptos interdum lobortis", Text = "Habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent" });
      this.News.Add(new NewsViewModel() { Subject = "runtime twelve", Authors = "Nascetur pharetra placerat pulvinar", Text = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos" });
      this.News.Add(new NewsViewModel() { Subject = "runtime thirteen", Authors = "Maecenas praesent accumsan bibendum", Text = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur" });
      this.News.Add(new NewsViewModel() { Subject = "runtime fourteen", Authors = "Dictumst eleifend facilisi faucibus", Text = "Pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent" });
      this.News.Add(new NewsViewModel() { Subject = "runtime fifteen", Authors = "Habitant inceptos interdum lobortis", Text = "Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat" });
      this.News.Add(new NewsViewModel() { Subject = "runtime sixteen", Authors = "Nascetur pharetra placerat pulvinar", Text = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum" });

      this.IsDataLoaded = true;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(String propertyName)
    {
      PropertyChangedEventHandler handler = PropertyChanged;
      if (null != handler)
      {
        handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}