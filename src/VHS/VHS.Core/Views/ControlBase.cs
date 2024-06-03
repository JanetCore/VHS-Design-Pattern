using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VHS.Core;

public class ControlBase : UserControl
{
    public ControlBase()
    {
        DataContext = this;
    }
}
