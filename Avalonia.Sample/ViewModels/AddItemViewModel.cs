using System.Reactive;
using Avalonia.Sample.Models;
using ReactiveUI;

namespace Avalonia.Sample.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {
        private string _description;

        public string Description
        {
            get => _description;
            set => this.RaiseAndSetIfChanged(ref _description, value);
        }

        public ReactiveCommand<Unit, TodoItem> Add { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }

        public AddItemViewModel()
        {
            var addEnabled = this.WhenAnyValue(
                x => x.Description,
                x => !string.IsNullOrWhiteSpace(x)
            );

            Add = ReactiveCommand.Create(
                () => new TodoItem { Description = Description },
                addEnabled
            );
            Cancel = ReactiveCommand.Create(() => { });
        }
    }
}