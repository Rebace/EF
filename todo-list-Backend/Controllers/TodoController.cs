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
            List<Todo> todos = _todoRepository.GetTodoList();
            return Ok(todos.Select(x => x.Map()));
        }

        [HttpGet]
        [Route("{todoId}")]
        public IActionResult GetById(int todoId)
        {
            Todo? todo = _todoRepository.GetById(todoId);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo.Map());
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] TodoDto todoDto)
        {
            var createdTodo = _todoRepository.Create(todoDto.Map());

            _unitOfWork.Commit();

            return Ok(createdTodo.Id);
        }

        [HttpPut]
        [Route("{todoId}/complete")]
        public IActionResult Complete(int todoId)
        {
            Console.WriteLine(todoId);

            Todo? comletedTodo = _todoRepository.GetById(todoId);
            comletedTodo.IsDone = false;
            _todoRepository.Update(comletedTodo);

            _unitOfWork.Commit();

            return Ok(comletedTodo.Map());
        }

        [HttpDelete]
        [Route("{todo}/delete")]
        public IActionResult Delete([FromBody] TodoDto todoDto)
        {
            _todoRepository.Delete(todoDto.Map());

            _unitOfWork.Commit();

            return NoContent();
        }
    }
}
