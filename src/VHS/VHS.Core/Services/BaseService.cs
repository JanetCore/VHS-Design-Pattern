using System;
using Microsoft.Extensions.DependencyInjection;

namespace VHS.Core
{
    public abstract class BaseService
    {
        protected readonly IServiceProvider _serviceProvider;

        protected BaseService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected T GetService<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
