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

namespace hm_services
{
  public class ItemViewModel : INotifyPropertyChanged
  {
    #region Properties
    private string _subject;
    public string Subject
    {
      get { return _subject; }
      set {
        if (value != _subject)
        {
          _subject = value;
          NotifyPropertyChanged("Subject");
        }
      }
    }

    private string _text;
    public string Text
    {
      get { return _text; }
      set
      {
        if (value != _text)
        {
          _text = value;
          NotifyPropertyChanged("Text");
        }
      }
    }

    private string _teacher_code;
    public string TeacherCode
    {
      get { return _teacher_code; }
      set
      {
        if (value != _teacher_code)
        {
          _teacher_code = value;
          NotifyPropertyChanged("TeacherCode");
        }
      }
    }
    
    private DateTime _publish;
    public DateTime Publish
    {
      get { return _publish; }
      set
      {
        if (value != _publish)
        {
          _publish = value;
          NotifyPropertyChanged("Publish");
        }
      }
    }

    private DateTime _expire;
    public DateTime Expire
    {
      get { return _expire; }
      set
      {
        if (value != _expire)
        {
          _expire = value;
          NotifyPropertyChanged("Expire");
        }
      }
    }
    #endregion

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
  }
}
