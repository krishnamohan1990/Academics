using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLib.Exceptions;
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

		public void Insert(Program program)
		{
			bool success;
				using (var con = DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("InsertProgram", con))
				{
					cmd.Parameters.AddWithValue("@programId", program.ProgramID);
					cmd.Parameters.AddWithValue("@programName", program.ProgramName);
					cmd.Parameters.AddWithValue("@description", program.Description);
					cmd.Parameters.AddWithValue("@createdOn", program.CreatedOn);
					cmd.Parameters.AddWithValue("@createdBy", program.CreatedBy);
					con.Open();
					success = cmd.ExecuteNonQuery()>0;
				}
				if(!success)
					throw new Exception("Progam not added sucessfully");
		}

		public void Update(Program program)
		{
			try
			{
				using (var con = DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("UpdateProgram", con))
				{
					cmd.Parameters.AddWithValue("@programId", program.ProgramID);
					cmd.Parameters.AddWithValue("@programName", program.ProgramName);
					cmd.Parameters.AddWithValue("@description", program.Description);
					cmd.Parameters.AddWithValue("@updatedOn", program.CreatedOn);
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
				using (var cmd = DAHelper.Command("SelectProgramsByBranchID", con))
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
				using (var cmd = DAHelper.Command("SelectProgramsByYearID", con))
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


		public IEnumerable<Program> SelectByAdminID(Guid userId)
		{
			try
			{
				IList<Program> program = new List<Program>();
				using (var con = DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("SelectProgramsByAdminID", con))
				{
					cmd.Parameters.AddWithValue("@userId",userId);
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

		public IEnumerable<Program> SelectByBranchAndYearID(Guid branchId, Guid yearId)
		{
			try
			{
				IList<Program> program = new List<Program>();
				using (var con = DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("SelectProgramsByBranchAndYearID", con))
				{
					cmd.Parameters.AddWithValue("@branchId", yearId);
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
				CreatedBy = new Guid(dr["CreatedBy"].ToString()),
				CreatedOn = Convert.ToDateTime(dr["CreatedOn"]),
				UpdatedOn = dr["UpdatedOn"] == null ? DateTime.MaxValue: Convert.ToDateTime(dr["UpdatedOn"])
			};
		}
	}
}
