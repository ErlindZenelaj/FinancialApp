using System;
using FinancialApp.Core.Repositories;

namespace FinancialApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository User { get; }
        public IRoleRepository Role { get; }

        public UnitOfWork(IUserRepository user, IRoleRepository role)
        {
            User = user;
            Role = role;
           
        }

        public Task FindByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}