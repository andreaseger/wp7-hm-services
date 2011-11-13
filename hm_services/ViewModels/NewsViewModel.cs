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

namespace hm_services.ViewModels
{
  public class NewsViewModel : INotifyPropertyChanged
  {
    private string _subject;
    /// <summary>
    /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
    /// </summary>
    /// <returns></returns>
    public string Subject
    {
      get
      {
        return _subject;
      }
      set
      {
        if (value != _subject)
        {
          _subject = value;
          NotifyPropertyChanged("Subject");
        }
      }
    }

    private string _authors;
    /// <summary>
    /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
    /// </summary>
    /// <returns></returns>
    public string Authors
    {
      get
      {
        return _authors;
      }
      set
      {
        if (value != _authors)
        {
          _authors = value;
          NotifyPropertyChanged("Authors");
        }
      }
    }

    private string _text;
    /// <summary>
    /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
    /// </summary>
    /// <returns></returns>
    public string Text
    {
      get
      {
        return _text;
      }
      set
      {
        if (value != _text)
        {
          _text = value;
          NotifyPropertyChanged("Text");
        }
      }
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
