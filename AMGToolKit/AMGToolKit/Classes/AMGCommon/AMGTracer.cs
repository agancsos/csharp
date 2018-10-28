using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMGCommon
{
    enum TRACE_LEVEL
    {
        NONE,
        ERROR,
        WARNING,
        INFORMATIONAL,
        VERBOSE
    }

    class AMGTracer
    {
        #region Properties
        private TRACE_LEVEL globalTraceLevel = TRACE_LEVEL.ERROR;
        private String targetFilePath = "";
        #endregion

        #region Accessors
        public TRACE_LEVEL GlobalTraceLevel
        {
            get { return globalTraceLevel; }
            set { globalTraceLevel = value; }
        }
        public String TargetFilePath
        {
            get { return targetFilePath; }
            set { targetFilePath = value; }
        }
        #endregion

        #region Constructors
        public AMGTracer(TRACE_LEVEL level = TRACE_LEVEL.ERROR)
        {
            globalTraceLevel = level;
        }
        #endregion

        #region Trace Methods
		public void Trace(TRACE_LEVEL level, String message, bool print)
		{
			if((int) globalTraceLevel >= (int)level)
			{
				Trace(String.Format("{0} {1}", level.ToString(), message), print);
			}
		}
        public void Trace(String message, bool print)
        {
			String content = "";
            if (print)
				Console.WriteLine(message);
			if(AMGSystem.FileExists(targetFilePath))
			{
				content = new AMGSystem(targetFilePath).ReadFile() + "\n";
			}
			content += (DateTime.Now.ToLongDateString() + message);
			new AMGSystem("", targetFilePath).WriteFile(content);
        }
        #endregion
    }
}
