using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CM.Map
{
    public class Log
    {
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="msg"></param>
        public static void WriteLog(string text)
        {

            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = System.IO.Path.Combine(path, "Logs");

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            //string fileFullName = System.IO.Path.Combine(path, string.Format("{0}.log", DateTime.Now.ToString("yyMMdd-HHmmss")));
            string fileFullName = System.IO.Path.Combine(path, string.Format("{0}.log", DateTime.Now.ToString("yyMMdd")));

            using (StreamWriter output = System.IO.File.AppendText(fileFullName))
            {
                output.WriteLine(DateTime.Now.ToString()+">>>>"+ text);

                output.Close();
            }
        }
    }
}
