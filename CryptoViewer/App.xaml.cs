using CryptoViewer.Core.Interfaces;
using CryptoViewer.Infrastructure.Http;
using CryptoViewer.Infrastructure.Services;
using CryptoViewer.UI.Wpf.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CryptoViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var apiBaseUrl = new Uri(config["CoinCap:BaseUrl"]!);
            var apiKey = config["CoinCap:ApiKey"]!;

            var services = new ServiceCollection();

            services.AddSingleton(new ApiClient(apiBaseUrl, apiKey));

            services.AddScoped<IMarketDataService, MarketDataService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IConverterService, ConverterService>();

            services.AddTransient<MainViewModel>();

            ServiceProvider = services.BuildServiceProvider();

            var mainWindow = new MainWindow
            {
                DataContext = ServiceProvider.GetRequiredService<MainViewModel>()
            };

            mainWindow.Show();
        }
    }

}
