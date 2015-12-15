using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLib.Helpers;
using DataAccessLib.Interfaces;
using Services.Contracts;
using System.Transactions;

namespace DataAccessLib.DataAccess
{
	public class UserDA : IUserDA, IDataAccess
	{
		#region Singleton

		private static IUserDA _userDA = new UserDA();
		private UserDA() { }
		public static IUserDA Instance
		{
			get { return _userDA ; }
		}

		#endregion

		public void InsertUser(User user)
		{
			try
			{
				using(var transaction=new TransactionScope(TransactionScopeOption.Required))
				using(var con = DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("InsertUser", con))
				{
					cmd.Parameters.AddWithValue("@userId", user.UserID);
					cmd.Parameters.AddWithValue("@firstName", user.FirstName);
					cmd.Parameters.AddWithValue("@lastName", user.LastName);
					cmd.Parameters.AddWithValue("@gender", user.Gender);
					cmd.Parameters.AddWithValue("@email", user.Email);
					cmd.Parameters.AddWithValue("@phoneNumber", user.PhoneNumber);
					cmd.Parameters.AddWithValue("@password", user.Password);
					cmd.Parameters.AddWithValue("@branchId", user.BranchID);
					cmd.Parameters.AddWithValue("@createdBy", user.CreatedBy);
					cmd.Parameters.AddWithValue("@createdOn", user.CreatedOn);
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

		public void InsertRole(Role role)
		{

		}

		public void InsertUserRole(Guid userId, Guid roleId)
		{
			try
			{
				using(var con = DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("InsertUserRole", con))
				{
					cmd.Parameters.AddWithValue("@userId", userId);
					cmd.Parameters.AddWithValue("@roleId", roleId);
					con.Open();
					cmd.ExecuteNonQuery();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public void UpdateUser(User user)
		{

		}

		public User GetUser(string userId)
		{
			try
			{
				User user = null;
				using(var con=DAHelper.SqlConnection)
				using (var cmd = DAHelper.Command("SelectUserByUserId", con))
				{
					cmd.Parameters.AddWithValue("@userId", userId);
					con.Open();
					var dr = cmd.ExecuteReader();
					
					while (dr.Read())
					{
						user = new User();
						user.UserID = new Guid(userId);
						user.FirstName = dr["FirstName"].ToString();
						user.LastName = dr["LastName"].ToString();
						user.Gender = dr["Gender"].ToString();
						user.Email = dr["Email"].ToString();
						user.PhoneNumber = dr["PhoneNumber"].ToString();
						user.Password = dr["Password"].ToString();
						user.BranchID = new Guid(dr["BranchID"].ToString());
						user.BranchName = dr["Name"].ToString();
						user.RoleID = new Guid(dr["RoleID"].ToString());
						user.CreatedBy = new Guid(dr["CreatedBy"].ToString());
						user.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
					}
				}
				return user;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public void RegisterUser(User user)
		{
			try
			{
				var branch = new Branch()
				{
					BranchID = DAHelper.NewGuid,
					BranchName = user.BranchName,
					CreatedBy = user.UserID,
					CreatedOn = user.CreatedOn,
					IsDefault = true
				};
				user.BranchID = branch.BranchID;
				user.CreatedBy = user.CreatedBy;
				user.CreatedOn = user.CreatedOn;
				using (var transaction = new TransactionScope(TransactionScopeOption.Required))
				{
					BranchDA.Instance.Insert(branch);
					InsertUser(user);
					InsertUserRole(user.UserID, user.RoleID);
					transaction.Complete();
				}
			}
			catch (Exception EX)
			{
				throw;
			}

		}
	}
}
