using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace MvcApp.TestServiceReference
{
	public partial class ServiceClient : IDisposable
	{
		public void Dispose()
		{
			Dispose(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				try
				{
					if (State != CommunicationState.Faulted)
					{
						Close();
					}
				}
				finally
				{
					if (State != CommunicationState.Closed)
					{
						Abort();
					}
				}
			}
		}

		~ServiceClient()
		{
			Dispose(false);
		}
	}
}