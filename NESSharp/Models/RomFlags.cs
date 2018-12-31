using System;

namespace NESSharp.Models
{
    [Flags]
    public enum RomFlags
    {
        FourScreen = 0b00000001,
        Trainer = 0b00000010,
        SRam = 0b00000100,
        Mirror = 0b00001000
    }
}
