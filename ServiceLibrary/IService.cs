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
		List<AcademicYear> GetAllAcademicYears(Guid branchId);

		[OperationContract]
		void AddBranch(Branch branch);

		[OperationContract]
		void DeleteBranch(Guid branchID);

		[OperationContract]
		Branch GetBranch(Guid branchID);

		[OperationContract]
		IEnumerable<Branch> GetAllBranches(Guid userID);

		[OperationContract]
		void InsertProgram(Program program);

		[OperationContract]
		void DeleteProgram(Program program);

		[OperationContract]
		Program SelectProgram(Guid programId);

		[OperationContract]
		IEnumerable<Program> SelectProgramsByBranch(Guid branchId);
		
		[OperationContract]
		IEnumerable<Program> SelectProgramsByYear(Guid yearId);
	}
}
