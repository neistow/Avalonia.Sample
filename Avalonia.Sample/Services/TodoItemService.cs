using System;
using Avalonia.Sample.Models;
using DynamicData;

namespace Avalonia.Sample.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly SourceCache<TodoItem, Guid> _items = new(i => i.Id);

        public IObservable<IChangeSet<TodoItem, Guid>> Connect() => _items.Connect();

        public void Add(TodoItem item)
        {
            _items.AddOrUpdate(item);
        }

        public void Remove(Guid id)
        {
            _items.Remove(id);
        }
    }
}