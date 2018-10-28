using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AMGCommon
{
    class AMGSystem
    {
        private String sourcePath = "";
        public String SourcePath
        {
            get { return sourcePath; }
            set { sourcePath = value; }
        }
        private String targetPath = "";
        public String TargetPath
        {
            get { return targetPath; }
            set { targetPath = value; }
        }

        #region Constructors
        public AMGSystem(String source = "", String target = "")
        {
            sourcePath = source;
            targetPath = target;
        }
        #endregion

        #region Static Methods
        public static void ExitProgram()
        {
            Console.WriteLine("Thank you for visiting.  Please come again soon....");
            Environment.Exit(0);
        }
        public static void Sleeper(int seconds)
        {
            System.Threading.Thread.Sleep(seconds * 1000);
        }
        public static String RunCommand(String cmd)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.Arguments = String.Format("/c \"{0}\"", cmd);
            info.RedirectStandardOutput = true;
            info.RedirectStandardError = true;
            info.UseShellExecute = false;
            Process process = new Process();
            process.StartInfo = info;
            try
            {
                process.Start();
                process.WaitForExit();
                return process.StandardOutput.ReadToEnd();
            }
            catch(IOException e1) { return e1.StackTrace; }
        }
		public static bool FileExists(String path)
		{
			return File.Exists(path);
		}
        #endregion

        #region Public Methods
        public String ReadFile()
        {
            if(File.Exists(sourcePath))
            {
                return File.ReadAllText(sourcePath);
            }
            return "";
        }
        public bool WriteFile(String data)
        {
            try
            {
                File.WriteAllText(targetPath, data);
            }
            catch(IOException e) { return false; }
            return true;
        }
        #endregion
    }
}
