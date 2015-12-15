
using System;
using System.Collections.Generic;
using System.Linq;
using MvcApp.Components;
using MvcApp.Models;
using MvcApp.TestServiceReference;

namespace MvcApp.Helpers
{
	public static class BranchHelper
	{
		public static void AddBranch(Branch branch)
		{
			using (var client = new ServiceClient())
			{
				var b = new branch
				{
					BranchID = branch.ID.Value,
					BranchName = branch.Name,
					Description = branch.Description,
					CreatedBy = UserData.GetInstance.AdminID,
					CreatedOn = CommonHelper.CurrentDate,
					IsDefault = branch.IsDefault
				};
				client.AddBranch(b);
				SessionManager.Remove(SessionKeyID.Branches);
				if(branch.IsDefault)
					UserData.GetInstance.BranchID = branch.ID.Value;
			}
		}

		public static Branch GetBranch(Guid branchId)
		{
			Branch branch = null;
			using (var client = new ServiceClient())
			{
				var b=client.GetBranch(branchId);
				branch = new Branch
				{
					ID = b.BranchID,
					Name = b.BranchName,
					Description = b.Description,
					IsDefault = b.IsDefault
				};
			}
			return branch;
		}

		public static IEnumerable<Branch> GetAllBranches
		{
			get
			{
				if (SessionManager.Contains(SessionKeyID.Branches))
					return SessionManager.Get<List<Branch>>(SessionKeyID.Branches);
				List<Branch> lstBranch;
				using (var client = new ServiceClient())
				{
					var branches = client.GetAllBranches(UserData.GetInstance.UserID);
					lstBranch = (from b in branches
						select new Branch
						{
							ID = b.BranchID,
							Name = b.BranchName,
							Description = b.Description,
							IsDefault = b.IsDefault
						}).ToList();
					SessionManager.Add(SessionKeyID.Branches,lstBranch);
				}
				return lstBranch;
			}
		}

		public static void DeleteBranch(Guid id)
		{
			using (var client = new ServiceClient())
			{
				client.DeleteBranch(id);
			}
			var branches = SessionManager.Get<List<Branch>>(SessionKeyID.Branches);
			SessionManager.Add(SessionKeyID.Branches,branches.Where(i=>i.ID!=id).Select(j=>j).ToList());
		}
	}
}