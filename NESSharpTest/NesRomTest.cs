using Microsoft.VisualStudio.TestTools.UnitTesting;
using NESSharp;
using System.IO;

namespace NESSharpTest
{
    [TestClass]
    public class NesRomTest
    {
        [TestMethod]
        public void OpenRomTest()
        {
            using (var s = File.OpenRead("testnes.nes"))
            {
                var task = NESSharp.Models.NesRom.Open(s);
                task.RunSynchronously();
                var nesrom = task.Result;
                Assert.IsNotNull(nesrom);

            }
        }
    }
}
