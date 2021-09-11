using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Avalonia.Sample.ViewModels;
using ReactiveUI;

namespace Avalonia.Sample.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            this.WhenActivated(_ => { });
            AvaloniaXamlLoader.Load(this);
#if DEBUG
            this.AttachDevTools();
#endif
        }
    }
}