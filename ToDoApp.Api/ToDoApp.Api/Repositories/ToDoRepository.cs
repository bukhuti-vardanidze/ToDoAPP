using ToDoApp.Api.Db.Entities;
using ToDoApp.Api.Db;
using ToDoApp.Api.Models.Requests;

namespace ToDoApp.Api.Repositories
{
    



    public interface IToDoRepository
    {
        // void Insert(ToDoEntity entity);
            Task InsertAsync(int userId, string title, string description, DateTime deadline);


            List<ToDoEntity> Search(string filter, int pageSize, int pageIndex);

            Task StatusChangerAsync(ToDoStatusChanger toDoStatus);
            Task SaveChangesAsync();
    }

    public class ToDoRepository : IToDoRepository
    {
        private readonly AppDbContext _db;

        public ToDoRepository(AppDbContext db)
        {
            _db = db;
        }

        //public void Insert(ToDoEntity entity)
        //{
        //    _db.ToDos.Add(entity);
        //}


        
        public async Task InsertAsync(int userId, string title, string description, DateTime deadline)
        {
            var entity = new ToDoEntity();
            entity.UserId = userId;
            entity.Title = title;
            entity.Description = description;
            entity.Deadline = deadline;
            entity.Status = ToDoEntityStatus.New;
            entity.CreatedAt = DateTime.UtcNow;


            _db.ToDos.AddAsync(entity);
        }

        public List<ToDoEntity> Search(string filter, int pageSize, int pageIndex)
        {
            var entities = _db.ToDos
                .Where(t => t.UserId == 1)
                .Where(t => t.Title.Contains(filter))
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .OrderBy(t => t.Deadline)
                .ToList();
            
            return entities;
        }

          
        
        
        
        //
        public async Task StatusChangerAsync(ToDoStatusChanger toDoStatus)
        {
            var toDoSt = _db.ToDos.Where(s => s.Title == toDoStatus.Title);
            // toDoSt.Status == toDoStatus.Status;
             return toDoSt;

        }

        public List<ToDoEntity> TDInfoGiver(ToDoInfoGiverRequest toDoInfo)
        {
            var DeadlineData = _db.ToDos.OrderBy(d => d.Deadline).ToList();
            return DeadlineData;
        }

        public async Task InfoUpdateAsync(ToDoUpdateRequest toDoStatus)
        { 
            //title,description
            

        }

            //

            public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }



      

    }
}
