using Microsoft.EntityFrameworkCore;
using ToDoQuest.Data;

namespace ToDoQuest.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TodoItemRepository (ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<TodoItem> CreateTodoItemAsync(TodoItem todoItem)
        {
            _dbContext.TodoItems.Add(todoItem);
            await _dbContext.SaveChangesAsync();
            return todoItem;
        }

        public async Task DeleteTodoItemAsync(int id)
        {
            var todoItem = await _dbContext.TodoItems.FirstOrDefaultAsync(x => x.Id == id);

            if(todoItem != null)
            {
                _dbContext.TodoItems.Remove(todoItem);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<TodoItem> GetTodoItemById(int id)
        {
            return await _dbContext.TodoItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TodoItem>> GetTodoItemsAsync()
        {
            return await _dbContext.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> UpdateTodoItemAsync(TodoItem todoItem)
        {
            _dbContext.TodoItems.Update(todoItem);
            await _dbContext.SaveChangesAsync();
            return todoItem;
        }
    }
}