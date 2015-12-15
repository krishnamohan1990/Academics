using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MvcApp.Helpers
{
	public static class CommonHelper
	{
		public static DateTime CurrentDate
		{
			get { return DateTime.Now; }
		}

		public static Guid NewGuid
		{
			get { return Guid.NewGuid(); }
		}
	}
}