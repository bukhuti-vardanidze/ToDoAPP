using ToDoApp.Api.Db.Entities;

namespace ToDoApp.Api.Models.Requests
{
    public class ToDoStatusChanger
    {
        public string Title { get; set; }
        public ToDoEntityStatus Status { get; set; }
   
    }
}
