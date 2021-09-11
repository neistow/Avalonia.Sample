using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Avalonia.Sample.ViewModels;
using ReactiveUI;

namespace Avalonia.Sample.Views
{
    public class AddItemView : ReactiveUserControl<AddItemViewModel>
    {
        public AddItemView()
        {
            this.WhenActivated(_ => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}