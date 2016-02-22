namespace AllegroExtended.Services.Data
{
    using System.Linq;

    using AllegroExtended.Data.Models;

    public interface IAccountRequestService
    {
        AccountRequest GetById(int id);

        IQueryable<AccountRequest> GetAll();

        IQueryable<AccountRequest> GetAllUnread();

        void Add(AccountRequest request);

        void Delete(int id);
    }
}
