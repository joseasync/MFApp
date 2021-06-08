using System;
using System.IO;
using System.Reflection;

namespace MagniFinance.Domain.Utils
{
    //Log for a simple app (we can also use log4net or Serilog...) 
    public class Logger
    {
        private static string pathFile = string.Empty;

        public static bool Log(string message, string fileName = "MFlogFile")
        {
            try
            {
                fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string filePath = Path.Combine(pathFile, fileName);
                if (!File.Exists(filePath))
                {
                    FileStream arquivo = File.Create(filePath);
                    arquivo.Close();
                }
                using (StreamWriter w = File.AppendText(filePath))
                {
                    Info(message, w);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private static void Info(string logmessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Info : ");
                txtWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine($"  :{logmessage}");
                txtWriter.WriteLine("------------------------------------");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
