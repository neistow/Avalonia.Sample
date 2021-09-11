using System;
using Avalonia.Sample.Models;
using DynamicData;

namespace Avalonia.Sample.Services
{
    public interface ITodoItemService
    {
        IObservable<IChangeSet<TodoItem, Guid>> Connect();
        void Add(TodoItem item);
        void Remove(Guid id);
    }
}