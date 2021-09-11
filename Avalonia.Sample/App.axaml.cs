using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Sample.Views;
using ReactiveUI;
using Splat;

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
            Bootstrapper.RegisterDependencies(Locator.CurrentMutable, Locator.Current);

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = Locator.Current.GetService<IScreen>()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}