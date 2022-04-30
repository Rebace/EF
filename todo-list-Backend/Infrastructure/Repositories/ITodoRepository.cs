using To_Do_List_Backend.Domain;

namespace To_Do_List_Backend.Repositories
{
    public interface ITodoRepository
    {
        List<Todo> GetTodoList();
        Todo? GetById(int id);
        Todo Create(Todo todo);
        void Delete(Todo todo);
        void Update(Todo todo);
    }
}
