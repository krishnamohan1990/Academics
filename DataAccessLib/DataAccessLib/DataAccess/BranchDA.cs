using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DataAccessLib.Helpers;
using DataAccessLib.Interfaces;
using Services.Contracts;

namespace DataAccessLib.DataAccess
{
	public class BranchDA : IBranchDA, IDataAccess
	{
		#region Singleton

		private static IBranchDA _branchDA = new BranchDA();

		private BranchDA()
		{
		}

		public static IBranchDA Instance
		{
			get { return _branchDA; }
		}

		#endregion


		public void Insert(Branch branch)
		{
			try
			{
				using (var transaction = new TransactionScope(TransactionScopeOption.Required))
				using (var con = DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("InsertBranch", con))
				{
					cmd.Parameters.AddWithValue("@branchId", branch.BranchID);
					cmd.Parameters.AddWithValue("@branchName", branch.BranchName);
					cmd.Parameters.AddWithValue("@description", branch.Description);
					cmd.Parameters.AddWithValue("@isDefault", branch.IsDefault);
					cmd.Parameters.AddWithValue("@createdBy", branch.CreatedBy);
					cmd.Parameters.AddWithValue("@createdOn", branch.CreatedOn);
					con.Open();
					cmd.ExecuteNonQuery();
					transaction.Complete();
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public void Delete(Guid branchID)
		{
			try
			{
				using (var con = DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("DeleteBranch", con))
				{
					cmd.Parameters.AddWithValue("@branchId", branchID);
					con.Open();
					cmd.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public Branch Select(Guid branchId)
		{
			try
			{
				Branch branch= null;
				using (var con = DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("SelectBranch", con))
				{
					cmd.Parameters.AddWithValue("@branchId", branchId);
					con.Open();
					var dr = cmd.ExecuteReader();
					while (dr.Read())
					{
						branch = CreateFromReader(dr);
					}
				}
				return branch;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		public IEnumerable<Branch> SelectAll(Guid userID)
		{
			try
			{
				var branches = new List<Branch>();
				using (var con = DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("SelectAllBranches", con))
				{
					cmd.Parameters.AddWithValue("@userId", userID);
					con.Open();
					var dr = cmd.ExecuteReader();
					while (dr.Read())
					{
						branches.Add(CreateFromReader(dr));
					}
				}
				return branches;
			}
			catch
			{
				throw;
			}
		}

		private Branch CreateFromReader(SqlDataReader dr)
		{
			return new Branch
			{
				BranchID = new Guid(dr["BranchID"].ToString()),
				BranchName = dr["Name"].ToString(),
				Description = dr["Description"].ToString(),
				IsDefault = Convert.ToBoolean(dr["IsDefault"]),
				CreatedBy = new Guid(dr["CreatedBy"].ToString()),
				CreatedOn = Convert.ToDateTime(dr["CreatedOn"])
			};
		}
	}
}
