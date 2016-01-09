using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Description;
using System.Web;
using System.Web.UI;
using Microsoft.Ajax.Utilities;
using MvcApp.Models;
using MvcApp.TestServiceReference;


namespace MvcApp.Helpers
{
	public static class UserHelper
	{
		public static Guid AdminRoleID
		{
			get
			{
				var id= ConfigurationManager.AppSettings["AdminRoleID"];
				return new Guid(id);
			}
		}

		public static void RegisterUser(RegisterModel userModel,Guid userId)
		{
			var client = new ServiceClient();
			var registerUserRequest = new user
			{
				UserID = userId,
				FirstName = userModel.FirstName,
				LastName = userModel.LastName,
				Gender=userModel.Gender,
				Email = userModel.Email,
				Password = userModel.Password,
				PhoneNumber = userModel.Phonenumber,
				BranchName = userModel.Branch,
				RoleID = AdminRoleID,
				CreatedBy = userId,
				CreatedOn = CommonHelper.CurrentDate
			};
			client.RegisterUser(registerUserRequest);
		}

		public static user GetUserDetails(string userId)
		{
			using (var client = new ServiceClient())
			{
				var user = client.GetUserDetails(userId);
				return user;
			}
		}
	}
}