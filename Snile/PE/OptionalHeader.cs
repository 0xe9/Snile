using Snile.Snile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snile.PE
{
    public class OptionalHeader
    {
        private DataStream memStream = null;
        private BinaryParser binaryParser = null;

        private long optHeaderAddress;

        private uint fileHeaderSize = 0x16;

        public OptionalHeader(Reader reader)
        {
            this.memStream = reader.memStream;
            this.binaryParser = reader.binaryParser; //0x96 v
            this.optHeaderAddress = reader.GetDOSHeader().GetFileAddress() + fileHeaderSize;
        }

        public UInt16 GetMagicNumber()
        {
            return (UInt16)(binaryParser.ParseUInt16(optHeaderAddress + 0x2));
        }

        public byte GetMajorLinkerVersion()
        {
            return (byte)(binaryParser.ParseByte(optHeaderAddress + 0x4));
        }

        public byte GetMinorLinkerVersion()
        {
            return (byte)(binaryParser.ParseByte(optHeaderAddress + 0x5));
        }

        public UInt32 GetSizeOfCode()
        {
            return (UInt32)(binaryParser.ParseUInt32(optHeaderAddress + 0x6));
        }

        public UInt32 GetInitializedDataSize()
        {
            return (UInt32)(binaryParser.ParseUInt32(optHeaderAddress + 0xA));
        }

        public UInt32 GetUninitializedDataSize()
        {
            return (UInt32)(binaryParser.ParseUInt32(optHeaderAddress + 0xC));
        }

        public UInt32 GetEntryPointAddress()
        {
            return (UInt32)(binaryParser.ParseUInt32(optHeaderAddress + 0x12));
        }

        public UInt32 GetBaseOfCode()
        {
            return (UInt32)(binaryParser.ParseUInt32(optHeaderAddress + 0x16));
        }

        public UInt32 GetBaseOfData()
        {
            return (UInt32)(binaryParser.ParseUInt32(optHeaderAddress + 0x1A));
        }

        public UInt32 GetImageBase()
        {
            return (UInt32)(binaryParser.ParseUInt32(optHeaderAddress + 0x1E));
        }

        public UInt32 GetSectionAlignment()
        {
            return (UInt32)(binaryParser.ParseUInt32(optHeaderAddress + 0x22));
        }

        public UInt32 GetFileAlignment()
        {
            return (UInt32)(binaryParser.ParseUInt32(optHeaderAddress + 0x26));
        }

        public UInt16 GetMajorOSVersion()
        {
            return (UInt16)(binaryParser.ParseUInt16(optHeaderAddress + 0x2A));
        }

        public UInt16 GetMinorOSVersion()
        {
            return (UInt16)(binaryParser.ParseUInt16(optHeaderAddress + 0x2C));
        }

        public UInt16 GetMajorImageVersion()
        {
            return (UInt16)(binaryParser.ParseUInt16(optHeaderAddress + 0x2E));
        }

        public UInt16 GetMinorImageVersion()
        {
            return (UInt16)(binaryParser.ParseUInt16(optHeaderAddress + 0X30));
        }

        public UInt16 GetMajorSubsystemVersion()
        {
            return (UInt16)(binaryParser.ParseUInt16(optHeaderAddress + 0x32));
        }

        public UInt16 GetMinorSubsystemVersion()
        {
            return (UInt16)(binaryParser.ParseUInt16(optHeaderAddress + 0x34));
        }

        public UInt32 GetVersionValue()
        {
            return (UInt32)(binaryParser.ParseUInt32(optHeaderAddress + 0x36));
        }

        public UInt32 GetSizeOfImage()
        {
            return (UInt32)(binaryParser.ParseUInt32(optHeaderAddress + 0x3A));
        }

        public UInt32 GetSizeOfHeaders()
        {
            return (UInt32)(binaryParser.ParseUInt32(optHeaderAddress + 0x3E));
        }

        public UInt32 GetChecksum()
        {
            return (UInt32)(binaryParser.ParseUInt32(optHeaderAddress + 0x42));
        }

        public UInt16 GetSubsystem()
        {
            return (UInt16)(binaryParser.ParseUInt16(optHeaderAddress + 0x46));
        }

        public UInt16 GetDllCharacteristics()
        {
            return (UInt16)(binaryParser.ParseUInt16(optHeaderAddress + 0x48));
        }

        public UInt32 GetReserveStackSize()
        {
            return (UInt32)(binaryParser.ParseUInt32(optHeaderAddress + 0x4A));
        }

        public UInt32 GetCommitStackSize()
        {
            return (UInt32)(binaryParser.ParseUInt32(optHeaderAddress + 0x4E));
        }

        public UInt32 GetReserveHeapSize()
        {
            return (UInt32)(binaryParser.ParseUInt32(optHeaderAddress + 0x52));
        }

        public UInt32 GetCommitHeapSize()
        {
            return (UInt32)(binaryParser.ParseUInt32(optHeaderAddress + 0x56));
        }

        public UInt32 GetLoaderFlags()
        {
            return (UInt32)(binaryParser.ParseUInt32(optHeaderAddress + 0x5A));
        }

        public UInt32 GetNumberOfRvaAndSizes()
        {
            return (UInt32)(binaryParser.ParseUInt32(optHeaderAddress + 0x5E));
        }
    }
}
