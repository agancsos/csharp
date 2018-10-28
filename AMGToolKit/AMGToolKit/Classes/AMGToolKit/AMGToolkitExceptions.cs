using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMGToolKit.Classes.AMGToolKit
{
	class WindowsOnlyException : Exception
	{
		public WindowsOnlyException() { }
		public WindowsOnlyException(String message) : base(message) { }
	}

	class OperationNotSupportedException : Exception
	{
		public OperationNotSupportedException() { }
		public OperationNotSupportedException(String message) : base(message) { }
	}
}
