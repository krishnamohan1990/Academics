using System;
using System.Collections.Generic;
using Services.Contracts;

namespace DataAccessLib.Interfaces
{
	public interface IBranchDA
	{
		void Insert(Branch branch);
		void Delete(Guid branchID);
		Branch Select(Guid branchID);
		IEnumerable<Branch> SelectAll(Guid userID);
	}
}
