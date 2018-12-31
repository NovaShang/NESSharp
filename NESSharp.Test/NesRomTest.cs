
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NESSharp.Test
{
    [TestClass]
    public class NesRomTest
    {
        [TestMethod]
        public async Task OpenRomTest()
        {
            using (var s = File.OpenRead("Roms\\nestest.nes"))
            {
                var nesrom = await Models.NesRom.Open(s);
                Assert.IsNotNull(nesrom);
            }
        }
    }
}
