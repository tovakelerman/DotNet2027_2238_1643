using System;
using System.IO;
using System.Reflection;

namespace Tools
{
    public class LogManager
    {
        private static readonly string logPath = "Log";

       public static string LogPath()
        {

            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logPath);
        }
        public static string thisFoledrPath()
        {
            string folder = LogPath();
            string path = $@"{DateTime.Now.Year}/{DateTime.Now.Month}";
            string fullPath = Path.Combine(folder, path);
            if (Directory.Exists(fullPath))
                return fullPath;
            Directory.CreateDirectory(fullPath);
            return fullPath;
        }

       public static string thisFilePath()
        {
            string folder = thisFoledrPath(); //I changed this here: folder = Log\2026\11 (the month folder) - the day is the FILE inside it
            string nameOfFile = $"{DateTime.Now.Day}.txt"; //I changed this here: the file name is only the day (was "year/month/day", which is not a file name on its own); ".txt" so it is a real file with an extension
            string fullPath = Path.Combine(folder, nameOfFile); //I changed this here: month folder + day file (the old code joined the folder with the whole year/month/day path a second time)
            if (!File.Exists(fullPath)) //I changed this here: File.Exists got a RELATIVE path before, so it always said false
            {
                using (FileStream stream = File.Create(fullPath)) { } //I changed this here: using + close - File.Create returned an OPEN file that was never closed, so the writer below could not open it
            }
            return fullPath; //I changed this here: one return path only (it had two different paths before)
        }
        public static void writeToLog(string nameOfProject, string nameOfFunction, string message)
        {
            string File = thisFilePath();
            using FileStream file = new FileStream(File, FileMode.Append, FileAccess.Write); //I changed this here: using - the file is closed even if writing fails
            using StreamWriter writer = new StreamWriter(file); //I changed this here: using - same reason
            writer.WriteLine($"{DateTime.Now}\t{nameOfProject}.{nameOfFunction}:\t{message}");


        }
        public static void CleanLog()
        {
            string logPath = LogPath();
            string[] subDirectories = Directory.GetDirectories(logPath);
            foreach (string subDirectory in subDirectories)
            {
                if (!(Path.GetFileName(subDirectory).StartsWith($"{DateTime.Now.Year}"))) //I changed this here: subDirectory is the FULL path (Log\2022), so it never starts with "2026" - compare only the final folder name
                {
                    string fullPath = Path.Combine(logPath, subDirectory); //I changed this here: keep as-is - an absolute path is returned unchanged by Path.Combine
                    Directory.Delete(fullPath, true);
                }
            }
        }

    }
}
