using System;
using Avalonia.Sample.Models;
using ReactiveUI;

namespace Avalonia.Sample.ViewModels
{
    public class TodoItemViewModel : ViewModelBase
    {
        private bool _isChecked;

        public bool IsChecked
        {
            get => _isChecked;
            set => this.RaiseAndSetIfChanged(ref _isChecked, value);
        }

        public string Description { get; }
        public Guid Id { get; }
        
        public TodoItemViewModel(TodoItem todoItem)
        {
            _isChecked = todoItem.IsChecked;
            Description = todoItem.Description;
            Id = todoItem.Id;
        }
    }
}