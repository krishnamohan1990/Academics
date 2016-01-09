using System;
using DataAccessLib.Exceptions;

namespace ServiceLibrary
{
	public class ProgramNotFoundException:ServiceException
	{
		public ProgramNotFoundException() { }
		public ProgramNotFoundException(string message) : base(message) { }
		public ProgramNotFoundException(string message, Exception innerException) : base(message, innerException) { }
	}
}
