namespace ToDoApp.Api.Models.Requests
{
    public class ToDoCreateRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}
