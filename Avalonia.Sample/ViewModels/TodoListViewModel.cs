using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Sample.Models;

namespace Avalonia.Sample.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        public ICollection<TodoItem> Items { get; }
        
        public TodoListViewModel(ICollection<TodoItem> items)
        {
            Items = new ObservableCollection<TodoItem>(items);
        }
    }
}