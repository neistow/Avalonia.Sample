﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Avalonia.Sample.Views
{
    public class TodoListView : UserControl
    {
        public TodoListView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}