using ToDoApp.Api.Db.Entities;
using ToDoApp.Api.Db;
using ToDoApp.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Api.Repositories
{
    



    public interface IToDoRepository
    {
        // void Insert(ToDoEntity entity);
            Task InsertAsync(int userId, string title, string description, DateTime deadline);
            List<ToDoEntity> Search(string filter, int pageSize, int pageIndex);

            Task<List<ToDoEntity>> StatusChangerAsync([FromBody] ToDoStatusChanger toDoStatus);
            Task UpdateToDoAsync(ToDoUpdateRequest request);
            Task<List<ToDoEntity>> CreateToDoAsync([FromBody] ToDoCreateRequest request);
            Task<List<ToDoEntity>> ToDoSearch(ToDoSearchRequest toDoInfo);
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
        public async Task<List<ToDoEntity>> StatusChangerAsync([FromBody] ToDoStatusChanger toDoStatus)
        {
            var result = await _db.ToDos.FindAsync(toDoStatus.Id);
            if(result.Status == ToDoEntityStatus.Sent)
            {
                toDoStatus.Status = ToDoEntityStatus.Sent;
            }
            if (result.Status == ToDoEntityStatus.Failed)
            {
                toDoStatus.Status = ToDoEntityStatus.Failed;
            }
            _db.ToDos.Update(result);
            return result;

        }
        
    

       

        public async Task<List<ToDoEntity>> CreateToDoAsync([FromBody] ToDoCreateRequest request)
        {
            var newRequest = new ToDoEntity
            {
                Title = request.Title,
                Description = request.Description,
                Deadline = request.Deadline

            };
            _db.ToDos.AddAsync(newRequest);
            return newRequest;
        
           
        }


        public async Task UpdateToDoAsync(ToDoUpdateRequest request)
        {
            var toDo =  _db.ToDos.Where(t => t.Title == request.updatedTitle).FirstOrDefault();
            if (!string.IsNullOrEmpty(request.updatedTitle))
            {
                toDo.Title = request.updatedTitle;
            }
            if (!string.IsNullOrEmpty(request.updatedDescription))
            {
                toDo.Description = request.updatedDescription;
            }
            _db.ToDos.Update(toDo);
                
        }

        public List<ToDoEntity> TDInfoGiver(ToDoInfoGiverRequest toDoInfo)
        {
            var DeadlineData = _db.ToDos.OrderBy(d => d.Deadline == toDoInfo.Deadline).ToList();
            return DeadlineData;
        }

        public async Task<List<ToDoEntity>> ToDoSearch(ToDoSearchRequest toDoInfo)
        {
            var search = _db.ToDos.Where(s=>s.Title == toDoInfo.Title).ToList();
            return search;
           
        }



        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }



      

    }
}
