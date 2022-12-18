using System;
using FinancialApp.Areas.Identity.Data;
using FinancialApp.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace FinancialApp.Repositories
{
	public class RoleRepository : IRoleRepository
	{
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public ICollection<IdentityRole> GetRoles()
		{
			return _context.Roles.ToList();
		}
	}
}

