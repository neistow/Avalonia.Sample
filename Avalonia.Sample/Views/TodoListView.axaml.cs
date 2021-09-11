using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Avalonia.Sample.ViewModels;
using ReactiveUI;

namespace Avalonia.Sample.Views
{
    public class TodoListView : ReactiveUserControl<TodoListViewModel>
    {
        public TodoListView()
        {
            this.WhenActivated(_ => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}