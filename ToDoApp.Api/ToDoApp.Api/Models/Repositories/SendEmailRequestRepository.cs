using ToDoApp.Api.Db;

namespace ToDoApp.Api.Models.Repositories
{
    public interface ISendEmailRequestRepository
    {
        //....
    }

    public class SendEmailRequestRepository : ISendEmailRequestRepository
    {

        private readonly AppDbContext _db;

        //..
    }

    
}
