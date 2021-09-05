using System;
using System.Reactive.Linq;
using Avalonia.Sample.Models;
using Avalonia.Sample.Persistence;
using ReactiveUI;

namespace Avalonia.Sample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _content;

        public ViewModelBase Content
        {
            get => _content;
            private set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public TodoListViewModel List { get; }

        public MainWindowViewModel(TodoItemsRepository repository)
        {
            Content = List = new TodoListViewModel(repository.GetAll());
        }

        public void AddItem()
        {
            var vm = new AddItemViewModel();

            Observable.Merge(vm.Add, vm.Cancel.Select(_ => null as TodoItem))
                .Take(1)
                .Subscribe(model =>
                {
                    if (model != null)
                    {
                        List.Items.Add(model);
                    }

                    Content = List;
                });

            Content = vm;
        }
    }
}