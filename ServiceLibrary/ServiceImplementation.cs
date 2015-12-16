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
			UserDA.Instance.InsertUser(user);
		}

		public User GetUserDetails(string userId)
		{
			return UserDA.Instance.GetUser(userId);
		}
		
		public void AddRole(Role role)
		{
			UserDA.Instance.InsertRole(role);
		}

		public void AddUserRole(string userId, string roleId)
		{
			UserDA.Instance.InsertUserRole(new Guid(userId), new Guid(roleId));
		}

		public void RegisterUser(User userRequest)
		{
			UserDA.Instance.RegisterUser(userRequest);
		}

		public void AddYear(AcademicYear year)
		{
			AcademicYearDA.Instance.InsertYear(year);
		}
		public void UpdateYear(AcademicYear year)
		{
			AcademicYearDA.Instance.UpdateYear(year);
		}
		public void DeleteYear(AcademicYear year)
		{
			AcademicYearDA.Instance.Delete(year);
		}

		public AcademicYear GetCurrentYear(Guid branchId)
		{
			var years = AcademicYearDA.Instance.GetAcademicYears(branchId, true);
			return years.FirstOrDefault();
		}

		public List<AcademicYear> GetAllAcademicYears(Guid branchId)
		{
			var years = AcademicYearDA.Instance.GetAcademicYears(branchId, false);
			return years;
		}

		public void AddBranch(Branch branch)
		{
			BranchDA.Instance.Insert(branch);
		}

		public void DeleteBranch(Guid branchID)
		{
			BranchDA.Instance.Delete(branchID);
		}

		public Branch GetBranch(Guid branchID)
		{
			return BranchDA.Instance.Select(branchID);
		}

		public IEnumerable<Branch> GetAllBranches(Guid userID)
		{
			return BranchDA.Instance.SelectAll(userID);
		}

		public void AddProgram(Program program)
		{
			ProgramDA.Instance.InsertORUpdate(program);
		}

		public void DeleteProgram(Program program)
		{
			ProgramDA.Instance.Delete(program);
		}

		public Program GetProgram(Guid programId)
		{
			return ProgramDA.Instance.Select(programId);
		}

		public IEnumerable<Program> GetProgramsByBranch(Guid branchId)
		{
			return ProgramDA.Instance.SelectByBranchID(branchId);
		}

		public IEnumerable<Program> GetProgramsByYear(Guid yearId)
		{
			return ProgramDA.Instance.SelectByYearID(yearId);
		}
	}
}
