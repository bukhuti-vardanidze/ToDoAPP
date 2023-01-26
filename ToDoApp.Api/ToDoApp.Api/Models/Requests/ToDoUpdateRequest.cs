namespace ToDoApp.Api.Models.Requests
{
    public class ToDoUpdateRequest
    {
        public DateTime updatedDeadline { get; set; }
        public string updatedDescription { get; set; }
        public string updatedTitle { get; set; }
    }
}
