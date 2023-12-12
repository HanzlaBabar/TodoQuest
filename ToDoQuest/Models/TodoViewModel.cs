using System.ComponentModel;
using ToDoQuest.Data;

namespace ToDoQuest.Models
{
    public class TodoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [DisplayName("Completed")]
        public bool IsCompleted { get; set; }

        public static TodoViewModel FromTodoItem(TodoItem todoItem)
        {
            return new TodoViewModel
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                IsCompleted = todoItem.IsCompleted
            };
        }

        public TodoItem ToTodoItem()
        {
            return new TodoItem
            {
                Id = Id,
                Title = Title,
                Description = Description,
                IsCompleted = IsCompleted
            };
        }
    }
}