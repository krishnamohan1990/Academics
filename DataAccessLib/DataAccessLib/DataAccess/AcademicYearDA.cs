using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLib.Helpers;
using DataAccessLib.Interfaces;
using Services.Contracts;
using System.Data.SqlClient;

namespace DataAccessLib.DataAccess
{
	public class AcademicYearDA:IAcademicYearDA
	{
		#region Singleton

		private static IAcademicYearDA _yearDA=new AcademicYearDA();
		private AcademicYearDA() { }

		public static IAcademicYearDA Instance
		{
			get { return _yearDA; }
		}

		#endregion

		public void InsertYear(AcademicYear year)
		{
			
			try
			{
				using(var con=DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("InsertAcademicYear", con))
				{
					cmd.Parameters.AddWithValue("@academicYearId", year.AcademicYearID);
					cmd.Parameters.AddWithValue("@name", year.Name);
					cmd.Parameters.AddWithValue("@fromDate", year.FromDate);
					cmd.Parameters.AddWithValue("@toDate", year.ToDate);
					cmd.Parameters.AddWithValue("@isCurrentYear", year.IsCurrentYear);
					cmd.Parameters.AddWithValue("@branchId", year.BranchID);
					cmd.Parameters.AddWithValue("@createdBy", year.CreatedBy);
					cmd.Parameters.AddWithValue("@createdOn", year.CreatedOn);
					con.Open();
					cmd.ExecuteNonQuery();
				}
			}
			catch
			{
				throw;
			}
		}

		public void UpdateYear(AcademicYear year)
		{
			
			try
			{
				using(var con = DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("UpdateAcademicYear", con))
				{
					cmd.Parameters.AddWithValue("@academicYearId", year.AcademicYearID);
					cmd.Parameters.AddWithValue("@name", year.Name);
					cmd.Parameters.AddWithValue("@fromDate", year.FromDate);
					cmd.Parameters.AddWithValue("@toDate", year.ToDate);
					cmd.Parameters.AddWithValue("@isCurrentYear", year.IsCurrentYear);
					cmd.Parameters.AddWithValue("@branchId", year.BranchID);
					cmd.Parameters.AddWithValue("@updatedOn", year.CreatedOn);
					con.Open();
					cmd.ExecuteNonQuery();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Delete(AcademicYear year)
		{
			try
			{
				using(var con = DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("DeleteAcademicYear", con))
				{
					cmd.Parameters.AddWithValue("@academicYearId", year.AcademicYearID);
					cmd.Parameters.AddWithValue("@updatedOn", year.CreatedOn);
					con.Open();
					cmd.ExecuteNonQuery();
				}
			}
			catch
			{
				throw;
			}
		}

		public List<AcademicYear> GetAcademicYears(Guid branchId,bool currentYearOnly)
		{
			var years=new List<AcademicYear>();
			try
			{
				using(var con = DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("SelectAcademicYears", con))
				{
					cmd.Parameters.AddWithValue("@currentYearOnly", currentYearOnly);
					cmd.Parameters.AddWithValue("@branchId", branchId);
					con.Open();
					var dr = cmd.ExecuteReader();
					while (dr.Read())
					{
						years.Add(CreateFromReader(dr));
					}
				}
				return years;
			}
			catch
			{
				throw;
			}
		}

		private AcademicYear CreateFromReader(IDataReader dr)
		{
			var year = new AcademicYear
			{
				AcademicYearID = new Guid(dr["AcademicYearID"].ToString()),
				Name = dr["Name"].ToString(),
				FromDate = Convert.ToDateTime(dr["FromDate"]),
				ToDate = Convert.ToDateTime(dr["ToDate"]),
				CreatedBy = new Guid(dr["CreatedBy"].ToString()),
				CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
				IsCurrentYear = Convert.ToBoolean(dr["IsCurrentYear"])
			};
			return year;
		}
	}
}
