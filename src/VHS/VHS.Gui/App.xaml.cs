using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using VHS.Gui.Views.Windows;

namespace VHS.Gui;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private ServiceProvider _serviceProvider;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        _serviceProvider = serviceCollection.BuildServiceProvider();

        var workspace = _serviceProvider.GetRequiredService<MainWorkspaceWindow>();
        workspace.Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<MainWorkspaceWindow>();
        // Register other services here
    }
}