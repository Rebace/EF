using System.Data;
using System.Data.SqlClient;
using To_Do_List_Backend.Domain;
using To_Do_List_Backend.Repositories;
using todo_list_Backend.Infrastructure;

namespace todo_list_Backend.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _dbContext;

        public TodoRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Todo> GetTodoList()
        {
            return _dbContext.Set<Todo>().ToList();
        }

        public Todo? GetById(int id)
        {
            return _dbContext.Set<Todo>().FirstOrDefault(x => x.Id == id);
        }

        public Todo Create(Todo todo)
        {
            var entity = _dbContext.Set<Todo>().Add(todo);
            return entity.Entity;
        }

        public void Delete(Todo todo)
        {
            _dbContext.Set<Todo>().Remove(todo);
        }

        public void Update(Todo todo)
        {
            _dbContext.Update(todo);
        }
    }
}
