using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMGCommon;
using AMGToolKit.Classes.AMGToolKit;
using AMGToolKit.Classes.AMGToolKit.AMGTools;

namespace AMGToolKit
{
    class Program
    {
        static void Main(string[] args)
        {
            bool help = false;
            bool isVersion = false;
			bool isList = false;
            String toolName = "gacutil";
            AMGTool tool = null;
            Dictionary<String, Object> arguments = new Dictionary<string, object>();

            if(args.Count() > 0)
            {
                for(int i = 0; i < args.Count(); i++)
                {
                    if (args[i].Equals("-h")) { help = true; }
					else if (args[i].Equals("-version")) { isVersion = true; }
					else if (args[i].Equals("-list")) { isList = true; }
					else if (args[i].Equals("-tool")) { toolName = args[i + 1]; }
                    else
                    {
                        if(args[i][0] == '-')
                        {
                            arguments.Add(args[i].Replace('-', '\0'), args[i + 1]);
                        }
                    }
                }
            }

			if (help) { SR.HelpMenu(); }
			else if(isList) { SR.ListTools(); }
			else if (isVersion) { Console.WriteLine("{0} Version v. {1}", SR.__PROGRAM_NAME_STRING__, SR.__PROGRAM_VERSION_STRING__); }
			else
			{
				tool = AMGToolKitFactory.CreateTool(toolName);
				try
				{
					tool.Invoke(arguments);
				}
				catch (Exception e)
				{
					Console.WriteLine("{0}\n{1}", e.Message, e.StackTrace);
				}
			}
        }
    }
}
