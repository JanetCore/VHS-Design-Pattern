using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace VHS.Core
{
    public abstract class BasePage : Page, INotifyPropertyChanged
    {
        public double Height { get; set; } = 300;
        public double Width { get; set; } = 300;
        public string Title { get; set; } = "Untitlted";
        protected readonly IServiceProvider _serviceProvider;

        protected BasePage(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            DataContext = this;
        }

        protected T GetService<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
