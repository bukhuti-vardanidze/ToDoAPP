using ToDoApp.Api.Db.Entities;
using ToDoApp.Api.Db;

namespace ToDoApp.Api.Repositories
{
    



    public interface IToDoRequestRepository
    {
        void Insert(ToDoRequestEntity entity);
        Task SaveChangesAsync();
    }

    public class ToDoRequestRepository : IToDoRequestRepository
    {
        private readonly AppDbContext _db;

        public ToDoRequestRepository(AppDbContext db)
        {
            _db = db;
        }

        public void Insert(ToDoRequestEntity entity)
        {
            _db.ToDoRequest.Add(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
