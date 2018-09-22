
using System;
using System.IO;
using System.Threading;
using NUnit.Framework;

namespace dotnet_acquire
{
    public class TempDirectory : IDisposable
    {
        public static TempDirectory Create()
        {
            var path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(path);
            return new TempDirectory(path);
        }

        public TempDirectory(string path)
        {
            Path = path;
        }

        public string Path { get; }

        public void Dispose()
        {
            for (var i = 0; i < 10; i++)
            {
                try
                {
                    Directory.Delete(Path);
                    return;
                }
                catch (Exception ex)
                {
                    TestContext.Out.WriteLine("Failed to delete: " + Path);
                    TestContext.Out.WriteLine(ex);
                    Thread.Sleep(100);
                }
            }
        }
    }
}
