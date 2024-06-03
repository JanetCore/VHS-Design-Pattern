using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VHS.Core;

public class WindowBase : Window
{
    public WindowBase()
    {
        DataContext = this;
    }
}
