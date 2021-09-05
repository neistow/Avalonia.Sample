using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Sample.Persistence;
using Avalonia.Sample.ViewModels;
using Avalonia.Sample.Views;

namespace Avalonia.Sample
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(new TodoItemsRepository())
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}