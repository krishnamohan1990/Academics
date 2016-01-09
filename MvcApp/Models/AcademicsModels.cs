using System;
using System.ComponentModel.DataAnnotations;
using MvcApp.TestServiceReference;

namespace MvcApp.Models
{
	public class AcademicsModels
	{
	
	}

	public class AcademicYear
	{
		[Required]
		[Display(Name="Academic Year Name")]
		[RegularExpression(@"([0-9a-zA-Z- ]+)",ErrorMessage = "Invalid Name.Only Alphanumeric,- are allowed")]
		[StringLength(20,ErrorMessage = "Name should be 4 to 50 characters length",MinimumLength = 4)]
		public string Name { get; set; }
		public Guid? ID { get; set; }
		[Required]
		//[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}",ApplyFormatInEditMode = true,ConvertEmptyStringToNull = true)]
		public DateTime FromDate { get; set; }
		[Required]
		//[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}", ConvertEmptyStringToNull = true)]
		public DateTime  ToDate { get; set; }
		[Display(Name = @"Set as Current Year?")]
		public bool IsCurrentYear { get; set; }
	}

	public class Branch
	{
		public Guid? ID { get; set; }
		[Required]
		[Display(Name = "Branch Name")]
		[StringLength(30,ErrorMessage = "Name should be 3 to 30 characters length",MinimumLength = 3)]
		[RegularExpression(@"[a-zA-Z0-9 _-]*",ErrorMessage = "Invalid Name.Only Alphanumeric, _, - are allowed")]
		public string Name { get; set; }
		[StringLength(100,MinimumLength = 0,ErrorMessage = "Description should be 0 to 100 characters length")]
		public string Description { get; set; }
		public bool IsDefault { get; set; }
	}

	public class Program
	{
		public Guid? ID { get; set; }
		[Required]
		[Display(Name = "Program Name")]
		[StringLength(50, ErrorMessage = "Name should be 3 to 50 characters length", MinimumLength = 3)]
		[RegularExpression(@"[a-zA-Z0-9 _-]*", ErrorMessage = "Invalid Name.Only Alphanumeric, _, - are allowed")]
		public string Name { get; set; }
		[StringLength(100, MinimumLength = 0, ErrorMessage = "Description should be 0 to 100 characters length")]
		public string Description { get; set; }
	}
}