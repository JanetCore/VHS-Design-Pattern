using Serilog;

namespace VHS.Core;

public abstract class ServiceBase
{
    protected readonly ILogger Logger;

    protected ServiceBase()
    {
        Logger = Log.ForContext<ServiceBase>();
    }
}
