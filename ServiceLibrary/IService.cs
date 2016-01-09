using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Services.Contracts;

namespace ServiceLibrary
{
	[ServiceContract]
	public interface IService
	{
		[OperationContract]
		void AddUser(User user);

		[WebInvoke(Method = "GET", UriTemplate = "GetUser?uId={userId}", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		[OperationContract]
		User GetUserDetails(string userId);

		[OperationContract]
		void RegisterUser(User userRequest);

		[OperationContract]
		void AddRole(Role role);

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "AddUserRole/{userId}/{roleId}",
			BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		void AddUserRole(string userId, string roleId);

		[OperationContract]
		void AddYear(AcademicYear year);

		[OperationContract]
		void UpdateYear(AcademicYear year);

		[OperationContract]
		void DeleteYear(AcademicYear year);

		[OperationContract]
		AcademicYear GetCurrentYear(Guid branchId);

		[OperationContract]
		List<AcademicYear> GetAcademicYearsByBranch(Guid branchId);


		[OperationContract]
		List<AcademicYear> GetAcademicYearsByUser(Guid userId);

		[OperationContract]
		void AddBranch(Branch branch);

		[OperationContract]
		void DeleteBranch(Guid branchID);

		[OperationContract]
		Branch GetBranch(Guid branchID);

		[OperationContract]
		IEnumerable<Branch> GetAllBranches(Guid userID);

		[OperationContract]
		[FaultContract(typeof(Error))]
		void AddProgram(Program program);

		[OperationContract]
		[FaultContract(typeof(Error))]
		void UpdateProgram(Program program);

		[OperationContract]
		[FaultContract(typeof(Error))]
		void DeleteProgram(Program program);

		[OperationContract]
		[FaultContract(typeof(Error))]
		Program GetProgram(Guid programId);

		[OperationContract]
		[FaultContract(typeof(Error))]
		IEnumerable<Program> GetProgramsByBranch(Guid branchId);

		[OperationContract]
		[FaultContract(typeof(Error))]
		IEnumerable<Program> GetProgramsByYear(Guid yearId);
		
		[OperationContract]
		[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
		[FaultContract(typeof(Error))]
		IEnumerable<Program> GetProgramsByBranchAndYear(Guid branchId, Guid yearId);

		[OperationContract]
		[FaultContract(typeof(Error))]
		IEnumerable<Program> GetProgramsByAdminID(Guid adminId);
	}
}
