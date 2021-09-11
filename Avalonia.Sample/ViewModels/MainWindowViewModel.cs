using System.Reactive.Disposables;
using ReactiveUI;
using Splat;

namespace Avalonia.Sample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IScreen, IActivatableViewModel
    {
        public ViewModelActivator Activator { get; }

        public RoutingState Router { get; } = new();

        public MainWindowViewModel()
        {
            Activator = new ViewModelActivator();

            this.WhenActivated((CompositeDisposable disposables) =>
            {
                Router.Navigate.Execute(Locator.Current.GetRequiredService<TodoListViewModel>());
            });
        }
    }
}