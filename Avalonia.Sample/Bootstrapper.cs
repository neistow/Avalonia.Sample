using System.Reflection;
using Avalonia.Sample.Persistence;
using Avalonia.Sample.Services;
using Avalonia.Sample.ViewModels;
using ReactiveUI;
using Splat;

namespace Avalonia.Sample
{
    public static class Bootstrapper
    {
        public static void RegisterDependencies(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            services.RegisterConstant<ITodoItemService>(new TodoItemService());
            services.RegisterConstant<IToDoItemPersistenceService>(new ToDoItemPersistenceService());

            services.RegisterConstant<IScreen>(new MainWindowViewModel());
            services.Register(() => new TodoListViewModel(
                resolver.GetRequiredService<IScreen>(),
                resolver.GetRequiredService<ITodoItemService>(),
                resolver.GetRequiredService<IToDoItemPersistenceService>()
            ));
            services.Register(() => new AddItemViewModel(
                resolver.GetRequiredService<IScreen>(),
                resolver.GetRequiredService<ITodoItemService>()
            ));

            services.RegisterViewsForViewModels(Assembly.GetExecutingAssembly());
        }
    }
}