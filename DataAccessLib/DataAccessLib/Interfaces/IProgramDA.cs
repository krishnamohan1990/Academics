using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Contracts;

namespace DataAccessLib.Interfaces
{
	public interface IProgramDA:IDataAccess
	{
		void InsertORUpdate(Program program);
		void Delete(Program program);
		Program Select(Guid programId);
		IEnumerable<Program> SelectByBranchID(Guid branchId);
		IEnumerable<Program> SelectByYearID(Guid yearID);
	}
}
