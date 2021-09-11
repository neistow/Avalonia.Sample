using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Avalonia.Sample.Models;
using Avalonia.Sample.Persistence;
using Avalonia.Sample.Services;
using DynamicData;
using ReactiveUI;
using Splat;

namespace Avalonia.Sample.ViewModels
{
    public class TodoListViewModel : ViewModelBase, IRoutableViewModel
    {
        private bool _loaded;

        private readonly ITodoItemService _itemService;
        private readonly IToDoItemPersistenceService _persistenceService;

        private bool _collectionEmpty;

        public bool CollectionEmpty
        {
            get => _collectionEmpty;
            set => this.RaiseAndSetIfChanged(ref _collectionEmpty, value);
        }

        private ReadOnlyObservableCollection<TodoItemViewModel> _items;
        public ReadOnlyObservableCollection<TodoItemViewModel> Items => _items;

        public ReactiveCommand<Unit, Unit> AddItem { get; }
        public ReactiveCommand<Guid, Unit> RemoveItem { get; }

        public string UrlPathSegment => nameof(TodoListViewModel);
        public IScreen HostScreen { get; }

        public TodoListViewModel(IScreen screen, ITodoItemService itemService, IToDoItemPersistenceService persistenceService)
        {
            HostScreen = screen;
            _itemService = itemService;
            _persistenceService = persistenceService;

            _itemService.Connect()
                .Transform(i => new TodoItemViewModel(i))
                .ObserveOn(RxApp.MainThreadScheduler)
                .AutoRefresh(i => i.IsChecked)
                .Bind(out _items)
                .Subscribe(async _ =>
                {
                    if (_loaded)
                    {
                        await SaveItems();
                    }
                });

            AddItem = ReactiveCommand.Create(() =>
            {
                screen.Router.Navigate.Execute(Locator.Current.GetRequiredService<AddItemViewModel>());
            });
            RemoveItem = ReactiveCommand.Create<Guid>(_itemService.Remove);

            this.WhenAnyValue(x => x.Items.Count)
                .Subscribe(x => CollectionEmpty = x == 0);

            RxApp.MainThreadScheduler.Schedule(InitializeItems);
        }

        private async void InitializeItems()
        {
            var items = await _persistenceService.Load();
            foreach (var item in items)
            {
                _itemService.Add(item);
            }

            _loaded = true;
        }

        private Task SaveItems()
        {
            return _persistenceService.Save(Items.Select(i => new TodoItem
                {
                    Description = i.Description,
                    IsChecked = i.IsChecked
                })
            );
        }
    }
}