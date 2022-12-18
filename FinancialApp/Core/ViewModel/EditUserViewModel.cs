using System;
using FinancialApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinancialApp.Core.ViewModels
{
	public class EditUserViewModel
	{
		public ApplicationUser User { get; set;}

		public IList<SelectListItem> Roles { get; set;  }
	}
}

