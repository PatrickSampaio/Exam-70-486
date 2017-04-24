using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandler
{
    class Program
    {
        public static string MyDirect = @"C:\PPTX\";
        public static string MyFile = @"Test.txt";
        static void Main(string[] args)
        {
            DirectoryInfo myDirectory = GetMyDictionary();
            //var myFile = GetMyFile(myDirectory.FullName);
            WriteInMyFile(Path.Combine(myDirectory.FullName + MyFile), "This is an serious bussiness");
        }

        public static DirectoryInfo GetMyDictionary()
        {
            DirectoryInfo currentDirectory = new DirectoryInfo(MyDirect);
            if (currentDirectory.Exists)
                currentDirectory.Delete(true);

            currentDirectory.Create();
            return currentDirectory;
        }

        //public static FileInfo GetMyFile(String dir)
        //{
        //    var pathMyFile = Path.Combine(dir + MyFile);
        //    FileInfo file = new FileInfo(pathMyFile);
        //    file.Create();
        //    return file;
        //}

        public static void WriteInMyFile(string fullPath, string toWrite)
        {
            using (FileStream fileStream = File.Create(fullPath))
            {
                byte[] data = Encoding.UTF8.GetBytes(toWrite);
                fileStream.Write(data, 0, data.Length);
            }
        }
    }
}
