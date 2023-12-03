using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursachFront.Core.Services.Path
{
    public static class PathFindService
    {
        public static string GetPath(string file)
        {
          
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = GetProjectDirectory(currentDirectory) + file;
            return fullPath;

        }
        public static string GetPath(string file,bool faceOrFinger)
        {
            string choice = GetChoice(faceOrFinger);
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = GetProjectDirectory(currentDirectory) +choice+ file;
            return fullPath;

        }
        private static string GetChoice(bool fof)
         => (fof is true)?"\\Sources\\Faces\\":"\\Sources\\Fingermarks\\";



        private static string GetProjectDirectory(string currentDirectory)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
            DirectoryInfo projectDirectoryInfo = directoryInfo.Parent?.Parent?.Parent;
            string projectDirectory = projectDirectoryInfo?.FullName;
            return projectDirectory;
        }
    }
}
