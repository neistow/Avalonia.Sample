using System.Collections.Generic;
using Avalonia.Sample.Models;

namespace Avalonia.Sample.Persistence
{
    public class TodoItemsRepository
    {
        public ICollection<TodoItem> GetAll() => new List<TodoItem>
        {
            new() { Description = "Discard WPF", IsChecked = true },
            new() { Description = "Learn Avalonia", IsChecked = false }
        };
    }
}