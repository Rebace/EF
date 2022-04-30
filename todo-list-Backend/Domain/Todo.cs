using To_Do_List_Backend.Dto;

namespace To_Do_List_Backend.Domain
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }

    static class ToTodoDto
    {
        public static TodoDto Map(this Todo todo)
        {
            return new TodoDto
            {
                Id = todo.Id,
                Title = todo.Title,
                IsDone = todo.IsDone
            };
        }
    }
}
