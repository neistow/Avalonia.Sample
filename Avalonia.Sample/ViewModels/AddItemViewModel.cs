using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Sample.Models;
using Avalonia.Sample.Services;
using ReactiveUI;

namespace Avalonia.Sample.ViewModels
{
    public class AddItemViewModel : ViewModelBase, IRoutableViewModel
    {
        private readonly ITodoItemService _repository;

        private string _description = "";

        public string Description
        {
            get => _description;
            set => this.RaiseAndSetIfChanged(ref _description, value);
        }

        public ReactiveCommand<Unit, Unit> Add { get; }
        public ReactiveCommand<Unit, Unit> GoBack { get; }

        public string UrlPathSegment => nameof(AddItemViewModel);
        public IScreen HostScreen { get; }

        public AddItemViewModel(IScreen screen, ITodoItemService repository)
        {
            _repository = repository;
            HostScreen = screen;

            var canAdd = this.WhenAnyValue(
                x => x.Description,
                x => !string.IsNullOrWhiteSpace(x)
            );

            Add = ReactiveCommand.Create(
                () =>
                {
                    AddNewItem();
                    GoBack.Execute();
                },
                canAdd
            );
            GoBack = screen.Router.NavigateBack;
        }

        private void AddNewItem() => _repository.Add(new TodoItem { Description = _description });
    }
}