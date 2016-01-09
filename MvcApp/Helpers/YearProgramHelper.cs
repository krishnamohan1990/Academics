using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Services.Description;
using Microsoft.Ajax.Utilities;
using MvcApp.Components;
using MvcApp.Models;
using MvcApp.TestServiceReference;
using WebGrease.Css.Extensions;
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
				var yearsList = client.GetAcademicYearsByUser(UserData.GetInstance.UserID);
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

		#region Programs

		public static void AddProgram(Program program)
		{
			var p = new program
			{
				ProgramID = program.ID.Value,
				ProgramName = program.Name,
				Description = program.Description,
				CreatedBy = UserData.GetInstance.AdminID,
				CreatedOn = CommonHelper.CurrentDate
			};
			try
			{
				using (var client = new ServiceClient())
				{
					client.AddProgram(p);
				}
			}
			catch (FaultException<Error> ex)
			{
				throw;
			}
		}

		public static void UpdateProgram(Program program)
		{
			var p = new program
			{
				ProgramID = program.ID.Value,
				ProgramName = program.Name,
				Description = program.Description,
				CreatedBy = UserData.GetInstance.AdminID,
				CreatedOn = CommonHelper.CurrentDate
			};
			using (var client = new ServiceClient())
			{
				client.UpdateProgram(p);
			}
		}

		public static IEnumerable<Program> GetProgramsByUserID(Guid userId)
		{
			if (SessionManager.Contains(SessionKeyID.Programs))
				return SessionManager.Get<IEnumerable<Program>>(SessionKeyID.Programs);
			IList<Program> programs = new List<Program>();
			using (var client = new ServiceClient())
			{
				var prog = client.GetProgramsByAdminID(userId);
				prog.ForEach(p =>
				{
					programs.Add(new Program
					{
						Name = p.ProgramName,
						Description = p.Description,
						ID = p.ProgramID
					});
				});
			}
			return programs;
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
			return null;
		}

		#endregion
	}
}