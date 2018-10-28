using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Diagnostics;

namespace AMGCommon
{
	class AMGRegistry
	{
		String baseNode = "";
		public String BaseNode
		{
			get { return baseNode; }
			set { baseNode = value; }
		}
		public AMGRegistry(String baseNode = "")
		{
			this.baseNode = baseNode;
		}

		public String LookupKey(String name)
		{
			if (Registry.GetValue(baseNode, name, null) != null)
				return Registry.GetValue(baseNode, name, null).ToString();
			return "";
		}

		public bool SetKey(String name, String value)
		{
			try
			{
				Registry.SetValue(baseNode, name, value);
			}
			catch
			{
				return false;
			}
			return true;
		}
	}
}
