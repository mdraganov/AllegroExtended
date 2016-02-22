namespace AllegroExtended.Services.Data
{
    using System;
    using System.Linq;

    using AllegroExtended.Data.Common;
    using AllegroExtended.Data.Models;

    public class AccountRequestService : IAccountRequestService
    {
        private readonly IDbRepository<AccountRequest> requests;

        public AccountRequestService(IDbRepository<AccountRequest> requests)
        {
            this.requests = requests;
        }

        public AccountRequest GetById(int id)
        {
            return this.GetById(id);
        }

        public void Add(AccountRequest request)
        {
            this.requests.Add(request);
            this.requests.Save();
        }

        public void Delete(int id)
        {
            var request = this.GetById(id);

            this.requests.Delete(request);
            this.requests.Save();
        }

        public IQueryable<AccountRequest> GetAll()
        {
            return this.requests.All();
        }

        public IQueryable<AccountRequest> GetAllUnread()
        {
            return this.requests.All().Where(x => !x.IsRead);
        }
    }
}
