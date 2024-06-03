using System.Windows.Controls;

namespace VHS.Core;

public class PageBase : Page
{
    public PageBase()
    {
        DataContext = this;
    }
}