using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLib.Helpers
{
	public class DAHelper
	{
		private static string _connectionString = ConfigurationManager.ConnectionStrings["MYDB"].ConnectionString;
		public static string AcademicsDB
		{
			get { return _connectionString; }
		}
		public static SqlConnection SqlConnection{
			get
			{
				return new SqlConnection(AcademicsDB);
			}
		}

		public static SqlCommand Command(string procedure,SqlConnection connection)
		{
			return new SqlCommand(procedure, connection) { CommandType = CommandType.StoredProcedure };
		}

		public static Guid NewGuid { get { return Guid.NewGuid(); } }
		public static DateTime  CurrentDate { get { return DateTime.Now; }}
	}
}
