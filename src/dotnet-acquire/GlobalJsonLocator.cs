
using System.IO;

namespace dotnet_acquire
{
    internal static class GlobalJsonLocator
    {
        public static FileInfo Find(DirectoryInfo directory)
        {
            do
            {
                var files = directory.GetFiles("global.json");
                if (files.Length > 0)
                {
                    return files[0];
                }

                directory = directory.Parent;
            }
            while (directory!= null);

            return null;
        }
    }
}