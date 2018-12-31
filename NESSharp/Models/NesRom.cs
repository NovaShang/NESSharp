using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace NESSharp.Models
{
    public class NesRom
    {
        public const string EX_BAD_HEADER = "Bad NES Rom header";
        public const string EX_WRONG_LENGTH = "Wrong NES Rom length";

        public async static Task<NesRom> Open(Stream stream)
        {
            var rom = new NesRom();

            var head = new byte[16];
            if (await stream.ReadAsync(head, 0, 16) < 16)
                throw new Exception(EX_BAD_HEADER);
            if (Encoding.ASCII.GetString(head.Take(3).ToArray()) != "NES")
                throw new Exception(EX_BAD_HEADER);

            rom.Flags = (RomFlags)head[6];
            rom.Mapper = (byte)((head[6] >> 4) | (head[7] & 0xF0));

            var prgLength = head[4] * 0x4000;
            rom.PrgData = new byte[prgLength];
            if (await stream.ReadAsync(rom.PrgData, 0, prgLength) < prgLength)
                throw new Exception(EX_WRONG_LENGTH);

            var chrLength = head[5] * 0x2000;
            rom.ChrData = new byte[chrLength];
            if (await stream.ReadAsync(rom.ChrData, 0, chrLength) < chrLength)
                throw new Exception(EX_WRONG_LENGTH);

            return rom;
        }

        public byte[] PrgData { get; set; }

        public byte[] ChrData { get; set; }

        public byte Mapper { get; set; }

        public RomFlags Flags { get; set; }

    }
}
