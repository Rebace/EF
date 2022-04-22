using Microsoft.AspNetCore.Mvc;
using To_Do_List_Backend.Domain;
using To_Do_List_Backend.Dto;
using To_Do_List_Backend.Repositories;
using todo_list_Backend.UnitOfWorks;

namespace todo_list_Backend.Controllers
{
    [Route("rest/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TodoController(ITodoRepository todoRepository, IUnitOfWork unitOfWork)
        {
            _todoRepository = todoRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            List<Todo> todos = _todoRepository.GetTodos();
            return Ok(todos.Select(x => x.ToTodoDto()));
        }

        [HttpGet]
        [Route("{todoId}")]
        public IActionResult Get(int todoId)
        {
            Todo? todo = _todoRepository.Get(todoId);
            return Ok(todo.ToTodoDto());
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] TodoDto todoDto)
        {
            var createdTodo = _todoRepository.Create(todoDto.ToTodo());

            _unitOfWork.Commit();

            return Ok(createdTodo.Id);
        }

        [HttpPut]
        [Route("{todoId}/complete")]
        public IActionResult Complete(int todoId)
        {
            Console.WriteLine(todoId);

            Todo? comletedTodo = _todoRepository.Get(todoId);
            comletedTodo.IsDone = false;
            _todoRepository.Update(comletedTodo);

            _unitOfWork.Commit();

            return Ok(comletedTodo.ToTodoDto());
        }

        [HttpDelete]
        [Route("{todoId}/delete")]
        public IActionResult Delete(int todoId)
        {
            _todoRepository.Delete(todoId);

            _unitOfWork.Commit();

            return NoContent();
        }
    }
}
