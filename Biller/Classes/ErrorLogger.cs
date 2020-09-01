using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Bajaj.Dinesh.Biller
{
    internal static class ErrorLogger
    {
        private static string EXTENSION = ".lgo";
        private static string PREFIX = "Entry_";
        private static int MAX_FILE_SIZE_IN_KB = 100 * 1024;

        internal static bool LogError(Exception ex)
        {
            string logFilePath = getLogFilePath();
            if (logFilePath == null)
            {
                return false;
            }

            //opens the log file, and add another error to it
            XmlDocument document = new XmlDocument();

            try
            {
                document.Load(logFilePath);
            }
            catch (Exception)
            {
                return false;
            }

            doLogEntry(document, ex);

            try
            {
                document.Save(logFilePath);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static string getLogFilePath()
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            folderPath = folderPath + "\\" + Global.AssemblyTitle;
            string filePath = GetLatestLogFile(folderPath);
            if (filePath == null)
            {
                return null;
            }

            if (!File.Exists(filePath))
            {
                bool result = CreateLogFile(filePath);
                if (!result) return null;
            }

            return filePath;
        }

        private static string GetLatestLogFile(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                try
                {
                    directoryInfo.Create();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return null;
                }
            }

            string[] files = Directory.GetFiles(folderPath, "*" + EXTENSION);
            if (files.Length == 0)
            {
                return folderPath + Path.DirectorySeparatorChar + PREFIX + Convert.ToString(1) + EXTENSION;
            }

            FileInfo fileInfo;
            string latestFilePath = null;
            int latestFileNumber = 0;
            int fileNumber;

            foreach (string fileName in files)
            {
                fileNumber = getFileNumber(fileName);
                if (fileNumber > latestFileNumber)
                {
                    latestFileNumber = fileNumber;
                    latestFilePath = fileName;
                }
            }

            fileInfo = new FileInfo(latestFilePath);
            if (fileInfo.Length < MAX_FILE_SIZE_IN_KB)
            {
                return latestFilePath;
            }

            fileNumber = getFileNumber(latestFilePath) + 1;
            return folderPath + Path.DirectorySeparatorChar + PREFIX + Convert.ToString(fileNumber) + EXTENSION;
        }

        private static int getFileNumber(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            char[] chars = fileInfo.Name.Substring(fileInfo.Name.IndexOf('_') + 1).ToCharArray();
            string numberString = string.Empty;
            foreach (char ch in chars)
            {
                if (!Char.IsDigit(ch))
                {
                    break;
                }
                numberString += ch.ToString();
            }

            return int.Parse(numberString);
        }

        private static bool CreateLogFile(string filePath)
        {
            XmlDocument document = new XmlDocument();

            XmlDeclaration declaration = document.CreateXmlDeclaration("1.0", string.Empty,
                "yes");
            document.AppendChild(declaration);
            XmlElement rootElement = document.CreateElement("Errors");
            document.AppendChild(rootElement);

            try
            {
                document.Save(filePath);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static void doLogEntry(XmlDocument document, Exception ex)
        {
            XmlElement rootElement = document.DocumentElement;

            XmlElement error = document.CreateElement("Error");
            rootElement.AppendChild(error);
            XmlElement element = document.CreateElement("DateTime");
            element.InnerText = DateTime.Now.ToString();
            error.AppendChild(element);
            element = document.CreateElement("ErrorType");
            element.InnerText = ex.GetType().FullName;
            error.AppendChild(element);
            element = document.CreateElement("ErrorMessage");
            element.InnerText = Global.getExceptionText(ex);
            error.AppendChild(element);

            element = document.CreateElement("StackTrace");
            string[] functionCalls = ex.StackTrace.Split(new string[] { "at " }, 12, StringSplitOptions.RemoveEmptyEntries);
            XmlElement functionCallElement;

            foreach (string functionCall in functionCalls)
            {
                functionCallElement = document.CreateElement("FunctionCall");
                functionCallElement.InnerText = functionCall;
                element.AppendChild(functionCallElement);
            }

            error.AppendChild(element);
        }
    }
}