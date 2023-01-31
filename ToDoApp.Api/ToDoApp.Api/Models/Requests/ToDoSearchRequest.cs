namespace ToDoApp.Api.Models.Requests
{
    public class ToDoSearchRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string filter { get; set; }
    }
}
