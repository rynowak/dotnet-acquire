
using System.IO;
using NUnit.Framework;

namespace dotnet_acquire
{
    [TestFixture]
    public class GlobalJsonLocatorTest
    {
        public TempDirectory TempDirectory { get; set; }

        [SetUp]
        public void SetUp()
        {
            TempDirectory = TempDirectory.Create();
        }

        [TearDown]
        public void TearDown()
        {
            TempDirectory.Dispose();
        }

        [Test]
        public void Find_FindsGlobalJson_InCurrentDirectory()
        {
            var expected = Path.Combine(TempDirectory.Path, "global.json");
            File.WriteAllText(expected, " ");

            var actual = GlobalJsonLocator.Find(new DirectoryInfo(TempDirectory.Path));

            Assert.AreEqual(expected, actual.FullName);
        }

        [Test]
        public void Find_FindsGlobalJson_InParent()
        {
            var expected = Path.Combine(TempDirectory.Path, "global.json");
            File.WriteAllText(expected, " ");

            Directory.CreateDirectory(Path.Combine(TempDirectory.Path, "foo"));
            Directory.CreateDirectory(Path.Combine(TempDirectory.Path, "foo", "bar"));

            var actual = GlobalJsonLocator.Find(new DirectoryInfo(Path.Combine(TempDirectory.Path, "foo", "bar")));

            Assert.AreEqual(expected, actual.FullName);
        }
    }
}