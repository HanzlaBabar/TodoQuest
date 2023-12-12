using ToDoQuest.Models;
using ToDoQuest.Repositories;

namespace ToDoQuest.Services
{
    class TodoItemService : ITodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoItemService(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task CreateTodoItemAsync(TodoViewModel model)
        {
            var item = model.ToTodoItem();
            await _todoItemRepository.CreateTodoItemAsync(item);
        }

        public async Task DeleteTodoItemAsync(int id)
        {
            await _todoItemRepository.DeleteTodoItemAsync(id);
        }

        public async Task<TodoViewModel> GetTodoItemById(int id)
        {
            var item = await _todoItemRepository.GetTodoItemById(id);
            return TodoViewModel.FromTodoItem(item);
        }

        public async Task<List<TodoViewModel>> GetTodoItemsAsync()
        {
            var items = await _todoItemRepository.GetTodoItemsAsync();
            return items.Select(TodoViewModel.FromTodoItem).ToList();
        }

        public async Task UpdateTodoItemAsync(TodoViewModel model)
        {
            var item = model.ToTodoItem();
            await _todoItemRepository.UpdateTodoItemAsync(item);
        }

        public async Task CompleteTodoItemAsync(int id)
        {
            await _todoItemRepository.CompleteTodoItemAsync(id);
        }
    }
}