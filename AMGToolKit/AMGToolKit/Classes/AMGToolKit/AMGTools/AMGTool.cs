using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMGToolKit.Classes.AMGToolKit.AMGTools
{
    public abstract class AMGTool
    {
        protected Dictionary<String, Object> arguments;
        public Dictionary<String, Object> Arguments { get; set; }
        public void AddArgument(String a, Object b) { arguments.Add(a, b); }
		public AMGTool() { }
        public AMGTool(Dictionary<String, Object> args)
        {
            arguments = args;
        }
        public abstract bool Invoke();
        public bool Invoke(Dictionary<String, Object> args)
		{
			try
			{
				Arguments = args;
				Invoke();
			}
			catch
			{
				return false;
			}
			return true;
		}
        public abstract String GetName();
    }
}
