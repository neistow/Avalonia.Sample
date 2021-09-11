using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.Sample.Models;

namespace Avalonia.Sample.Persistence
{
    public class ToDoItemPersistenceService : IToDoItemPersistenceService
    {
        private const string FilePath = "todos.json";

        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true
        };

        public async Task Save(IEnumerable<TodoItem> todoItems)
        {
            File.Delete(FilePath);
            await using var file = File.OpenWrite(FilePath);
            await JsonSerializer.SerializeAsync(file, todoItems, _options);
        }

        public async Task<IEnumerable<TodoItem>> Load()
        {
            if (!File.Exists(FilePath))
            {
                return Array.Empty<TodoItem>();
            }

            await using var file = File.OpenRead(FilePath);
            return await JsonSerializer.DeserializeAsync<IEnumerable<TodoItem>>(file);
        }
    }
}