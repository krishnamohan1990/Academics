using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLib.Helpers;
using Services.Contracts;
using DataAccessLib.Interfaces;

namespace DataAccessLib.DataAccess
{
	public class ProgramDA:IProgramDA
	{
		#region Singleton
		private static readonly ProgramDA _programDA=new ProgramDA();
		private ProgramDA() { }

		public static IProgramDA Instance
		{
			get { return _programDA; }
		}
		#endregion

		public void InsertORUpdate(Program program)
		{
			try
			{
				using (var con = DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("InsertProgram", con))
				{
					cmd.Parameters.AddWithValue("@programId", program.ProgramID);
					cmd.Parameters.AddWithValue("@programName", program.ProgramName);
					cmd.Parameters.AddWithValue("@description", program.Description);
					cmd.Parameters.AddWithValue("@branchId", program.BranchID);
					cmd.Parameters.AddWithValue("@createdOn", program.CreatedOn);
					cmd.Parameters.AddWithValue("@createdBy", program.CreatedBy);
					con.Open();
					cmd.ExecuteNonQuery();
				}
			}
			catch
			{
				throw;
			}
		}

		public void Delete(Program program)
		{
			try
			{
				using (var con = DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("DeleteProgram", con))
				{
					cmd.Parameters.AddWithValue("@programId", program.ProgramID);
					con.Open();
					cmd.ExecuteNonQuery();
				}
			}
			catch
			{
				throw;
			}
		}

		public Program Select(Guid programId)
		{
			try
			{
				Program program = null;
				using (var con = DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("SelectProgram", con))
				{
					cmd.Parameters.AddWithValue("@programId", programId);
					con.Open();
					var dr = cmd.ExecuteReader();
					while (dr.Read())
					{
						program = CreateFromReader(dr);
					}
				}
				return program;
			}
			catch(Exception)
			{
				throw;
			}
		}

		public IEnumerable<Program> SelectByBranchID(Guid branchId)
		{
			try
			{
				IList<Program> program = new List<Program>();
				using (var con = DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("SelectProgramByBranch", con))
				{
					cmd.Parameters.AddWithValue("@branchId", branchId);
					con.Open();
					var dr = cmd.ExecuteReader();
					while (dr.Read())
					{
						program.Add(CreateFromReader(dr));
					}
				}
				return program;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public IEnumerable<Program> SelectByYearID(Guid yearId)
		{
			try
			{
				IList<Program> program = new List<Program>();
				using (var con = DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("SelectProgramByYear", con))
				{
					cmd.Parameters.AddWithValue("@yearId", yearId);
					con.Open();
					var dr = cmd.ExecuteReader();
					while (dr.Read())
					{
						program.Add(CreateFromReader(dr));
					}
				}
				return program;
			}
			catch (Exception)
			{
				throw;
			}
		}

		private Program CreateFromReader(SqlDataReader dr)
		{
			return new Program
			{
				ProgramID = new Guid(dr["ProgramID"].ToString()),
				ProgramName = dr["ProgramName"].ToString(),
				Description = dr["Description"].ToString(),
				BranchID = new Guid(dr["BranchID"].ToString()),
				CreatedBy = new Guid(dr["CreatedBy"].ToString()),
				CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
				UpdatedOn = dr["UpdatedOn"] == null ? DateTime.MaxValue: Convert.ToDateTime(dr["UpdatedOn"])
			};
		}
	}
}
