using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

namespace VHS.Core
{
    public abstract class BaseHandler : BaseNotifyPropertyChanged
    {
        private readonly IServiceProvider _serviceProvider;

        protected BaseHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected T GetService<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
