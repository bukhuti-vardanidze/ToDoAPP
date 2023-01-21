using ToDoApp.Api.Db;
using ToDoApp.Api.Db.Entities;

namespace ToDoApp.Api.Models.Repositories
{
    public interface ISendEmailRequestRepository
    {
        //....
        void Insert(SendEmailRequestEntity sendEmailRequestEntity);
    }

    public class SendEmailRequestRepository : ISendEmailRequestRepository
    {

        private readonly AppDbContext _db;

        //..
    }

    
}
