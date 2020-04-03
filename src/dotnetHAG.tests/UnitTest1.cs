using NUnit.Framework;
using System;

namespace dotnetHAG.tests
{
    public class UnitTest1
    {
        [Test]
        public void Test_VersionChecker_ReturnsErrorMessageWhenFileNotFound()
        {
            // can't confirm what version to test platform has
            string output = VersionChecker.GetConsoleOutput("noSuchFile.exe --version");
            Assert.AreEqual("file not found", output);
        }

        [Test]
        public void Test_VersionChecker_DoesNotCrashOrReturnNull()
        {
            // can't confirm what version to test platform has
            string output = VersionChecker.GetConsoleOutput("dotnet --version");
            Console.WriteLine(output);
            Assert.NotNull(output);
        }

        [Test]
        public void Test_VersionChecker_OutputIsVersionFormat()
        {
            // can't confirm what version to test platform has
            string output = VersionChecker.GetConsoleOutput("dotnet --version");
            Version ver = new Version(output);
            Console.WriteLine(ver);
            Assert.NotNull(ver);
        }

        [Test]
        public void Test_VersionChecker_VersionIsNotZero()
        {
            // can't confirm what version to test platform has
            Version ver = VersionChecker.GetDotnetVersion();
            Assert.NotNull(ver);
            Assert.NotZero(ver.Major);
        }
    }
}
