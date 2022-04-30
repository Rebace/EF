using To_Do_List_Backend.Domain;

namespace To_Do_List_Backend.Dto
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }

    static class ToTodo
    {
        public static Todo Map(this TodoDto todoDto)
        {
            return new Todo
            {
                Id = todoDto.Id,
                Title = todoDto.Title,
                IsDone = todoDto.IsDone
            };
        }
    }
}
