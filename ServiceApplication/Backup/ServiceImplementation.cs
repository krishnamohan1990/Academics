using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using DataAccessLib.DataAccess;
using DataAccessLib.Helpers;
using Services.Contracts;

namespace ServiceLibrary
{
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(AddressFilterMode = AddressFilterMode.Any,InstanceContextMode=InstanceContextMode.PerCall)]
	public class ServiceImplementation:IService
	{
		public void AddUser(User user)
		{
			var userDa=new UserDA();
			userDa.InsertUser(user);
		}

		public User GetUserDetails(string userId)
		{
			var userDa = new UserDA();
		    var user= userDa.GetUser(userId);
			return user;
		}
		
		public void AddRole(Role role)
		{
			var userDa = new UserDA();
			userDa.InsertRole(role);
		}

		public void AddUserRole(string userId, string roleId)
		{
			var userDa = new UserDA();
			userDa.InsertUserRole(new Guid(userId), new Guid(roleId));
		}

		public void RegisterUser(User userRequest)
		{
			var branch = new Branch()
			{
				BranchID = Helper.NewGuid,
				BranchName = userRequest.BranchName,
				CreatedBy = userRequest.UserID,
				CreatedOn = userRequest.CreatedOn,
				IsDefault=true
			};
			AddBranch(branch);
			userRequest.BranchID = branch.BranchID;
			userRequest.CreatedBy = userRequest.CreatedBy;
			userRequest.CreatedOn = userRequest.CreatedOn;
			AddUser(userRequest);
			AddUserRole(userRequest.UserID.ToString(), userRequest.RoleID.ToString());
		}

		public void AddYear(AcademicYear year)
		{
			var yearDA = new AcademicYearDA();
			yearDA.InsertYear(year);
		}
		public void UpdateYear(AcademicYear year)
		{
			var yearDA = new AcademicYearDA();
			yearDA.UpdateYear(year);
		}
		public void DeleteYear(AcademicYear year)
		{
			var yearDA = new AcademicYearDA();
			yearDA.Delete(year);
		}

		public AcademicYear GetCurrentYear(Guid branchId)
		{
			var yearDA = new AcademicYearDA();
			var years=yearDA.GetAcademicYears(branchId, true);
			return years.FirstOrDefault();
		}

		public List<AcademicYear> GetAllAcademicYears(Guid branchId)
		{
			var yearDA = new AcademicYearDA();
			var years=yearDA.GetAcademicYears(branchId, false);
			return years;
		}

		public void AddBranch(Branch branch)
		{
			var branchDa = new BranchDA();
			branchDa.Insert(branch);
		}

		public void UpdateBranch(Branch branch)
		{
			throw new NotImplementedException();
		}

		public void DeleteBranch(Guid branchID)
		{
			throw new NotImplementedException();
		}

		public Branch GetBranch(Guid branchID)
		{
			throw new NotImplementedException();
		}

		public List<Branch> GetAllBranches(Guid userID)
		{
			throw new NotImplementedException();
		}
	}
}
