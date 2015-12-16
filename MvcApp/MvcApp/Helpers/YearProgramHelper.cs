using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApp.Components;
using MvcApp.Models;
using MvcApp.TestServiceReference;
using model = MvcApp.Models;
using service=MvcApp.TestServiceReference;

namespace MvcApp.Helpers
{
	public static class YearProgramHelper
	{
		public static void AddYear(model.AcademicYear year)
		{
			using (var client=new ServiceClient())
			{
				var serviceYear = new academicYear
				{
					AcademicYearID = CommonHelper.NewGuid,
					Name = year.Name,
					FromDate = year.FromDate,
					ToDate = year.ToDate,
					BranchID = UserData.GetInstance.BranchID,
					IsCurrentYear = year.IsCurrentYear,
					CreatedBy = UserData.GetInstance.AdminID,
					CreatedOn = CommonHelper.CurrentDate
				};
				client.AddYear(serviceYear);
			}
			SessionManager.Remove(SessionKeyID.Years);
		}

		public static void UpdateYear(model.AcademicYear year)
		{
			using (var client = new ServiceClient())
			{
				if (year.ID != null)
				{
					var serviceYear = new academicYear
					{
						AcademicYearID = year.ID.Value,
						Name = year.Name,
						FromDate = year.FromDate,
						ToDate = year.ToDate,
						BranchID = UserData.GetInstance.BranchID,
						IsCurrentYear = year.IsCurrentYear,
						CreatedOn = CommonHelper.CurrentDate
					};
					client.UpdateYear(serviceYear);
				}
			}
			SessionManager.Remove(SessionKeyID.Years);
		}

		public static void DeleteYear(Guid ID)
		{
			using (var client=new ServiceClient())
			{
				var serviceYear = new academicYear
				{
					AcademicYearID = ID,
					CreatedBy = UserData.GetInstance.AdminID,
					CreatedOn = CommonHelper.CurrentDate
				};
				client.DeleteYear(serviceYear);
			}
			var years = SessionManager.Get<List<AcademicYear>>(SessionKeyID.Years);
			SessionManager.Add(SessionKeyID.Years,years.Where(y=>y.ID!=ID).ToList());
		}

		public static List<AcademicYear> GetYears()
		{
			if (SessionManager.Contains(SessionKeyID.Years))
				return SessionManager.Get<List<AcademicYear>>(SessionKeyID.Years);
			var years = new List<AcademicYear>();
			using (var client=new ServiceClient())
			{
				var yearsList = client.GetAllAcademicYears(UserData.GetInstance.BranchID);
				years = (from p in yearsList
					select new AcademicYear
					{
						ID = p.AcademicYearID,
						Name = p.Name,
						FromDate = p.FromDate,
						ToDate = p.ToDate,
						IsCurrentYear = p.IsCurrentYear
					}).ToList();
				SessionManager.Add(SessionKeyID.Years, years);
			}
			return years;
		}

		public static void AddProgram(Program program)
		{
			var p = new program
			{
				ProgramID = program.ID.Value,
				ProgramName = program.Name,
				Description = program.Description,
				BranchID = UserData.GetInstance.BranchID,
				CreatedBy = UserData.GetInstance.AdminID,
				CreatedOn = CommonHelper.CurrentDate
			};
			using (var client = new ServiceClient())
			{
				client.AddProgram(p);
			}
		}

		public static Program GetProgam(Guid programId)
		{
			program p;
			using (var client = new ServiceClient())
			{
				p = client.GetProgram(programId);
			}
			if (p != null)
			{
				return new Program
				{
					ID = p.ProgramID,
					Name = p.ProgramName,
					Description = p.Description,
				};
			}
		}
	}
}