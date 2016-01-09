using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApp.Helpers;

namespace MvcApp.Components
{
	public class UserData
	{
		private Hashtable Details = new Hashtable();
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Guid UserID { get; set; }
		public Guid AdminID { get; set; }
		public Guid CurrentYearID { get; set; }
		public Guid BranchID { get; set; }

		public string CurrentBranchName
		{
			get
			{
				if (Details.ContainsKey(BranchID))
					return Details[BranchID].ToString();
				var branch = BranchHelper.GetBranch(BranchID);
				Details.Add(BranchID,branch.Name);
				return branch.Name;
			}
		}

		private static UserData _instance = new UserData();
		private UserData() { }
		public static UserData GetInstance
		{
			get
			{
				if (SessionManager.Contains(SessionKeyID.UserData))
					return SessionManager.Get<UserData>(SessionKeyID.UserData);
				SessionManager.Add(SessionKeyID.UserData,_instance);
				return _instance;
			}
		}

		public void Add(string key, object value)
		{
			Details.Add(key,value);
		}

		public T GetValue<T>(string key)
		{
			return (T) Details[key];
		}
	}
}