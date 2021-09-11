using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Sample.Models;

namespace Avalonia.Sample.Persistence
{
    public interface IToDoItemPersistenceService
    {
        Task Save(IEnumerable<TodoItem> todoItems);
        Task<IEnumerable<TodoItem>> Load();
    }
}