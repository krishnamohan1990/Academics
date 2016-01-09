using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.Exceptions
{
	public class ServiceException:ApplicationException
	{
		public ServiceException() { }
		public ServiceException(string message):base(message) { }
		public ServiceException(string message, Exception innerException):base(message,innerException) { }
	}

	public class DbOperationFailedException : ServiceException
	{
		public DbOperationFailedException(){}
		public DbOperationFailedException(string message):base(message){}
		public DbOperationFailedException(string message,Exception innerException):base(message,innerException){}
	}
}
