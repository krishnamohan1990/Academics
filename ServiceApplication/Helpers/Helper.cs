using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceApplication.Helpers
{
	public class Helper
	{
		public static string NewGuid
		{
			get { return Guid.NewGuid().ToString(); }
		}
	}
}