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
        
        public string Title { get; set; }
        public string Description { get; set; }
        public ToDoEntityStatus Status { get; set; }
        public DateTime Deadline { get; set; }
      


    }
}
