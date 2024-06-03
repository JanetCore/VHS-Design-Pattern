using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VHS.Core.Handlers;

public class ControlBaseHandler : HandlerBase
{
    public ControlBaseHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
