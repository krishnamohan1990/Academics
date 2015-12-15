using System;
using Services.Contracts;

namespace DataAccessLib.Interfaces
{
	public interface IUserDA
	{
		void InsertUser(User user);
		void InsertRole(Role role);
		void InsertUserRole(Guid userId, Guid roleId);
		void UpdateUser(User user);
		User GetUser(string userId);
		void RegisterUser(User user);
	}
}
