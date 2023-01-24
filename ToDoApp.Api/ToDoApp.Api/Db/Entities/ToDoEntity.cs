namespace ToDoApp.Api.Db.Entities
{
    
   
    public enum ToDoEntityStatus
    {
        New,
        Sent,
        Failed
    }
    public class ToDoEntity
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public ToDoEntityStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime Deadline  { get; set; }



    }
}
