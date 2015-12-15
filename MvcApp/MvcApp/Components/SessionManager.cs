using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;

namespace MvcApp.Components
{
	public static class SessionManager
	{
		public static void Add(string key, Object value)
		{
			if(HttpContext.Current.Session[key]!=null)
				Remove(key);
			HttpContext.Current.Session.Add(key,value);
		}
		public static T Get<T>(string key)
		{
			return (T)HttpContext.Current.Session[key];
		}

		public static bool Contains(string key)
		{
			return HttpContext.Current.Session[key] != null;
		}
		public static void Remove(string key)
		{
			HttpContext.Current.Session.Remove(key);
		}

		public static void Clear()
		{
			HttpContext.Current.Session.Clear();
		}

		public static void Abort()
		{
			HttpContext.Current.Session.Abandon();
		}
	}
}