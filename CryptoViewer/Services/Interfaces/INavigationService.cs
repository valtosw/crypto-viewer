using System.Windows.Controls;

namespace CryptoViewer.UI.Wpf.Services.Interfaces
{
    public interface INavigationService
    {
        void SetFrame(Frame frame);
        void NavigateTo<T>() where T : Page;
    }
}
