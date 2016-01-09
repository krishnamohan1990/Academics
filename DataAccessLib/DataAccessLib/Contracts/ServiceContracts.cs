using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
	[DataContract(Name = "branch")]
	public class Branch
	{

		[DataMember]
		public Guid BranchID { get; set; }

		[DataMember]
		public string BranchName { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public bool IsDefault { get; set; }

		[DataMember]
		public Guid CreatedBy { get; set; }

		[DataMember]
		public DateTime CreatedOn { get; set; }
	}

	[DataContract(Name = "user")]
	public class User
	{
		[DataMember]
		public Guid UserID { get; set; }

		[DataMember]
		public string FirstName { get; set; }

		[DataMember]
		public string LastName { get; set; }

		[DataMember]
		public string Gender { get; set; }

		[DataMember]
		public string Email { get; set; }

		[DataMember]
		public string PhoneNumber { get; set; }

		[DataMember]
		public string Password { get; set; }

		[DataMember]
		public Guid BranchID { get; set; }
		
		[DataMember]
		public string BranchName { get; set; }

		[DataMember]
		public Guid RoleID { get; set; }

		[DataMember]
		public Guid CreatedBy { get; set; }

		[DataMember]
		public DateTime CreatedOn { get; set; }
	}



	[DataContract(Name = "role")]
	public class Role
	{
		[DataMember]
		public Guid RoleID { get; set; }

		[DataMember]
		public string RoleName { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public Guid CreatedBy { get; set; }

		[DataMember]
		public DateTime CreatedOn { get; set; }
	}

	[DataContract(Name = "academicYear")]
	public class AcademicYear
	{
		[DataMember]
		public Guid AcademicYearID { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public DateTime FromDate { get; set; }

		[DataMember]
		public DateTime ToDate { get; set; }

		[DataMember]
		public bool IsCurrentYear { get; set; }
		
		[DataMember]
		public Guid CreatedBy { get; set; }

		[DataMember]
		public DateTime CreatedOn { get; set; }
	}

	[DataContract(Name="program")]
	public class Program
	{
		[DataMember]
		public Guid ProgramID { get; set; }

		[DataMember]
		public string ProgramName { get; set; }

		[DataMember]
		public string Description { get; set; }
		
		[DataMember]
		public Guid CreatedBy { get; set; }

		[DataMember]
		public DateTime CreatedOn { get; set; }

		[DataMember]
		public DateTime UpdatedOn { get; set; }
	}

	[DataContract(Name="section")]
	public class Section
	{
		[DataMember]
		public Guid SectionID { get; set; }

		[DataMember]
		public string SectionName { get; set; }

		[DataMember]
		public Guid CreatedBy { get; set; }

		[DataMember]
		public DateTime CreatedOn { get; set; }
	}

	[DataContract]
	public class Error
	{
		public string Message { get; set; }
		public string Reason { get; set; }
	}
}