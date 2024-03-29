﻿using MiApp.LM.Presentacion.Wpf.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MiApp.LM.Presentacion.Wpf.MVVM
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
