﻿namespace ToDoApp.Api.Db.Entities
{
    
   
    public enum ToDoEntityStatus
    {
        New,
        Sent,
        Failed
    }
    public class ToDoRequestEntity
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public ToDoEntityStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime Deadline  { get; set; }



    }
}
