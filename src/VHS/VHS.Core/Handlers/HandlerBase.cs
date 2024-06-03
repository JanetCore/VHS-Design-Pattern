using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Serilog;
using VHS.Core.Handlers;

namespace VHS.Core;

public abstract class HandlerBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    protected readonly ILogger Logger;
    private readonly IServiceProvider _serviceProvider;

    protected HandlerBase(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        Logger = Log.ForContext<HandlerBase>();
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected ICommand CreateCommand(Action execute, Func<bool> canExecute = null)
    {
        return new RelayCommand(execute, canExecute);
    }

    protected ICommand CreateCommand<T>(Action<T> execute, Func<T, bool> canExecute = null)
    {
        // Assuming RelayCommand is not generic
        return new RelayCommand(() => execute(default(T)), () => canExecute == null || canExecute(default(T)));
    }
}
