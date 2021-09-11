using System;

namespace Avalonia.Sample.Models
{
    public class TodoItem
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Description { get; set; }
        public bool IsChecked { get; set; }
    }
}