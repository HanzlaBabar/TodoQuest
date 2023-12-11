using ToDoQuest.Data;

namespace ToDoQuest.Repositories
{
    public interface ITodoItemRepository
    {
        Task<List<TodoItem>> GetTodoItemsAsync();
        Task<TodoItem> CreateTodoItemAsync(TodoItem todoItem);
        Task<TodoItem> UpdateTodoItemAsync(TodoItem todoItem);
        Task DeleteTodoItemAsync(int id);
        Task<TodoItem> GetTodoItemById(int id);
    }
}