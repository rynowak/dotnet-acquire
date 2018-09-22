using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using McMaster.Extensions.CommandLineUtils;

namespace dotnet_acquire
{
    [Command(Description = "dotnet-acquire can install .NET SDKs")]
    internal class Program
    {
        public static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        public int OnExecute()
        {
            var globalJsonFile = GlobalJsonLocator.Find(new DirectoryInfo(Directory.GetCurrentDirectory()));
            if (globalJsonFile == null)
            {

            }

            
            return 0;
        }
    }
}
