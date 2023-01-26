namespace ToDoApp.Api.Models.Requests
{
    public class ToDoSearchRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string filter { get; set; }
    }
}
