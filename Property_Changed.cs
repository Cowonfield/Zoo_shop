using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WpfApp7.Infrastructure
{
    public class Property_Changed : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string prapertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prapertyName));
        }
    }
}