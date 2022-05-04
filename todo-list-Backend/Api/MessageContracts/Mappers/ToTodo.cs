using To_Do_List_Backend.Domain;
using To_Do_List_Backend.Dto;

namespace todo_list_Backend.Api.MessageContracts.Mappers
{
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
