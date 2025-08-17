using CryptoViewer.UI.Wpf.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace CryptoViewer.UI.Wpf.Services
{
    public class NavigationService(IServiceProvider serviceProvider) : INavigationService
    {
        private Frame _frame = null!;

        public void SetFrame(Frame frame) => _frame = frame;

        public void NavigateTo<T>() where T : Page
        {
            var page = serviceProvider.GetRequiredService<T>();
            _frame.Navigate(page);
        }

        public void NavigateTo<T>(object parameter) where T : Page
        {
            var page = serviceProvider.GetRequiredService<T>();

            if (page.DataContext is INavigable navigable)
            {
                navigable.OnNavigatedTo(parameter);
            }

            _frame.Navigate(page);
        }
    }
}
