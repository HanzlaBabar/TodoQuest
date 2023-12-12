using ToDoQuest.Models;

namespace ToDoQuest.Services
{
    public interface ITodoItemService
    {
        Task<List<TodoViewModel>> GetTodoItemsAsync();
        Task CreateTodoItemAsync(TodoViewModel model);
        Task UpdateTodoItemAsync(TodoViewModel model);
        Task DeleteTodoItemAsync(int id);
        Task<TodoViewModel> GetTodoItemById(int id);
        Task CompleteTodoItemAsync(int id);
    }
}