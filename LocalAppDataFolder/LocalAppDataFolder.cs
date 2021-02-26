using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LocalAppDataFolder
{
    /// <summary>
    /// Helps to save the configs file in the local AppData.
    /// </summary>
    public class LocalAppData
    {
        public LocalAppData(string assemblyName)
        {
            AssemblyName = assemblyName;
        }

        public LocalAppData()
        {
            AssemblyName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
        }

        private static readonly string LocalAppDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private string AssemblyName;
        public string AssemblyFolderPath
        {
            get
            {
                string FolderPath = Path.Combine(LocalAppDataFolderPath, AssemblyName);
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }
                return FolderPath;
            }
        }

        /// <summary>
        /// Returns a stream to the AppData/local project folder where to save the config file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>FileStream to the AppData folder of the current assembly.</returns>
        public FileStream GetFile(string fileName)
        {
            string filePath = Path.Combine(AssemblyFolderPath, fileName);
            return File.Open(filePath, FileMode.OpenOrCreate);
        }
    }
}
