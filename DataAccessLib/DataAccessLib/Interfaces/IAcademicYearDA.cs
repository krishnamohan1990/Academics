using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Contracts;

namespace DataAccessLib.Interfaces
{
	public interface IAcademicYearDA
	{
		void InsertYear(AcademicYear year);
		void UpdateYear(AcademicYear year);
		void Delete(AcademicYear year);
		List<AcademicYear> GetAcademicYears(Guid branchId, bool currentYearonly);
	}
}
