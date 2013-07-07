using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snile.Snile;
using Snile.PE;
using Snile.CLR;

namespace Example
{
    class Program
    {
        static string filePath = @"C:\Users\Joe\Documents\Visual Studio 2012\Projects\TestFlow\TestFlow\bin\Debug\TestFlow.exe";

        static void Main(string[] args)
        {
            Console.WriteLine("Snile example");
            Console.WriteLine("");

            Reader reader = new Reader(filePath);

            Streams s = new Streams(reader);

            #region done
            //#region DOS
            //DOSHeader dos = reader.GetDOSHeader();
            //Console.WriteLine("DOS Header: ");
            //Console.WriteLine(" -Magic Number: 0x{0:X6}", dos.GetMagicNumber());
            //Console.WriteLine(" -Last Size: 0x{0:X6}", dos.GetLastSize());
            //Console.WriteLine(" -Page Count: 0x{0:X6}", dos.GetPageCount());
            //Console.WriteLine(" -Relocations: 0x{0:X6}", dos.GetRelocations());
            //Console.WriteLine(" -Paragraph Header Size: 0x{0:X6}", dos.GetParagraphHeaderSize());
            //Console.WriteLine(" -Minimum Extra Paragraphs: 0x{0:X6}", dos.GetMinExtraParagraphs());
            //Console.WriteLine(" -Maximum Extra Paragraphs: 0x{0:X6}", dos.GetMaxExtraParagraphs());
            //Console.WriteLine(" -Initial SS: 0x{0:X6}", dos.GetInitialSS());
            //Console.WriteLine(" -Initial SP: 0x{0:X6}", dos.GetInitialSP());
            //Console.WriteLine(" -Checksum: 0x{0:X6}", dos.GetChecksum());
            //Console.WriteLine(" -Initial IP: 0x{0:X6}", dos.GetInitialIP());
            //Console.WriteLine(" -Initial CS: 0x{0:X6}", dos.GetInitialCS());
            //Console.WriteLine(" -Relocation File Address: 0x{0:X6}", dos.GetRelocFileAddress());
            //Console.WriteLine(" -Overlay Number: 0x{0:X6}", dos.GetOverlayNumber());
            //Console.WriteLine(" -OEM ID: 0x{0:X6}", dos.GetOEMid());
            //Console.WriteLine(" -OEM Info: 0x{0:X6}", dos.GetOEMInfo());
            //Console.WriteLine(" -File Address: 0x{0:X6}", dos.GetFileAddress());
            //Console.WriteLine("");
            //#endregion
            //#region NT
            //NTHeader nt = reader.GetNTHeader();
            //Console.WriteLine("NT Header: ");
            //Console.WriteLine(" -Magic Number: 0x{0:X6}", nt.GetMagicNumber());
            //Console.WriteLine("");
            //#endregion
            //#region FILE
            //FileHeader file = reader.GetFileHeader();
            //Console.WriteLine("File Header: ");
            //Console.WriteLine(" -Machine: 0x{0:X6}", file.GetMachine());
            //Console.WriteLine(" -Number of Sections: 0x{0:X6}", file.GetNumberOfSections());
            //Console.WriteLine(" -Timp Date Stamp: 0x{0:X6}", file.GetTimpDateStamp());
            //Console.WriteLine(" -Symbol Table Address: 0x{0:X6}", file.GetSymbolTableAddress());
            //Console.WriteLine(" -Number of Symbols: 0x{0:X6}", file.GetNumberOfSymbols());
            //Console.WriteLine(" -Optional Header Size: 0x{0:X6}", file.GetOptionalHeaderSize());
            //Console.WriteLine(" -Characteristics: 0x{0:X6}", file.GetCharacteristics());
            //Console.WriteLine("");
            //#endregion
            //#region OPT
            //OptionalHeader opt = reader.GetOptionalHeader();
            //Console.WriteLine("Optional Header: ");
            //Console.WriteLine(" -Machine: 0x{0:X6}", opt.GetMagicNumber());
            //Console.WriteLine(" -Major Linker Version: 0x{0:X6}", opt.GetMajorLinkerVersion());
            //Console.WriteLine(" -Minor Linker Version: 0x{0:X6}", opt.GetMinorLinkerVersion());
            //Console.WriteLine(" -Size of Code: 0x{0:X6}", opt.GetSizeOfCode());
            //Console.WriteLine(" -Initialized Data Size: 0x{0:X6}", opt.GetInitializedDataSize());
            //Console.WriteLine(" -Uninitialized Data Size: 0x{0:X6}", opt.GetUninitializedDataSize());
            //Console.WriteLine(" -EntryPoint Address: 0x{0:X6}", opt.GetEntryPointAddress());
            //Console.WriteLine(" -Base Of Code: 0x{0:X6}", opt.GetBaseOfCode());
            //Console.WriteLine(" -Base of Data: 0x{0:X6}", opt.GetBaseOfData());
            //Console.WriteLine(" -Image Base: 0x{0:X6}", opt.GetImageBase());
            //Console.WriteLine(" -Section Alignment: 0x{0:X6}", opt.GetSectionAlignment());
            //Console.WriteLine(" -File Alignment: 0x{0:X6}", opt.GetFileAlignment());
            //Console.WriteLine(" -Major OS Version: 0x{0:X6}", opt.GetMajorOSVersion());
            //Console.WriteLine(" -Minor OS Version: 0x{0:X6}", opt.GetMinorOSVersion());
            //Console.WriteLine(" -Major Image Version: 0x{0:X6}", opt.GetMajorImageVersion());
            //Console.WriteLine(" -Minor Image Version: 0x{0:X6}", opt.GetMinorImageVersion());
            //Console.WriteLine(" -Major Subsystem Version: 0x{0:X6}", opt.GetMajorSubsystemVersion());
            //Console.WriteLine(" -Minor Subsystem Version: 0x{0:X6}", opt.GetMinorSubsystemVersion());
            //Console.WriteLine(" -Version Value: 0x{0:X6}", opt.GetVersionValue());
            //Console.WriteLine(" -Size of Image: 0x{0:X6}", opt.GetSizeOfImage());
            //Console.WriteLine(" -Size of Headers: 0x{0:X6}", opt.GetSizeOfHeaders());
            //Console.WriteLine(" -Checksum: 0x{0:X6}", opt.GetChecksum());
            //Console.WriteLine(" -Subsystem: 0x{0:X6}", opt.GetSubsystem());
            //Console.WriteLine(" -Dll Characteristics: 0x{0:X6}", opt.GetDllCharacteristics());
            //Console.WriteLine(" -Reserve Stack Size: 0x{0:X6}", opt.GetReserveStackSize());
            //Console.WriteLine(" -Commit Stack Size: 0x{0:X6}", opt.GetCommitStackSize());
            //Console.WriteLine(" -Reserve Heap Size: 0x{0:X6}", opt.GetReserveHeapSize());
            //Console.WriteLine(" -Commit Heap Size: 0x{0:X6}", opt.GetCommitHeapSize());
            //Console.WriteLine(" -Loader Flags: 0x{0:X6}", opt.GetLoaderFlags());
            //Console.WriteLine(" -Number of RVA and Sizes: 0x{0:X6}", opt.GetNumberOfRvaAndSizes());
            //Console.WriteLine("");
            //#endregion
            //#region DIRECTORIES
            //DataDirectories data = reader.GetDataDirectories();
            //Console.WriteLine("Export Directory: " + data.GetExportDirectory().ToString());
            //Console.WriteLine(" -Import Directory: " + data.GetImportDirectory().ToString());
            //Console.WriteLine(" -Resource Directory: " + data.GetResourceDirectory().ToString());
            //Console.WriteLine(" -Exception Directory: " + data.GetExceptionDirectory().ToString());
            //Console.WriteLine(" -Security Directory: " + data.GetSecurityDirectory().ToString());
            //Console.WriteLine(" -Relocation Directory: " + data.GetRelocationDirectory().ToString());
            //Console.WriteLine(" -Debug Directory: " + data.GetDebugDirectory().ToString());
            //Console.WriteLine(" -Architecture Directory: " + data.GetArchitectureDirectory().ToString());
            //Console.WriteLine(" -TLS Directory: " + data.GetTLSDirectory().ToString());
            //Console.WriteLine(" -Configuration Directory: " + data.GetConfigDirectory().ToString());
            //Console.WriteLine(" -Bound Import Directory: " + data.GetBoundImportDirectory().ToString());
            //Console.WriteLine(" -IAT Directory: " + data.GetIATDirectory().ToString());
            //Console.WriteLine(" -Delay Import Directory: " + data.GetDelayImportDirectory().ToString());
            //Console.WriteLine(" -.NET Metadata Directory: " + data.GetNETMetadataDirectory().ToString());
            //Console.WriteLine("");
            //#endregion
            //#region SECTIONS
            //List<Section> sections = reader.GetSections();
            //foreach (Section section in sections)
            //{
            //    Console.WriteLine("Section Name: " + section.GetName());
            //    Console.WriteLine(" -Virtual Size: 0x{0:X6}", section.GetVirtualSize());
            //    Console.WriteLine(" -Virtual Address: 0x{0:X6}", section.GetDataAddress());
            //    Console.WriteLine(" -Raw Data Size 0x{0:X6}", section.GetDataSize());
            //    Console.WriteLine(" -Raw Data Address 0x{0:X6}", section.GetDataAddress());
            //    Console.WriteLine(" -Relocations Address 0x{0:X6}", section.GetRelocationsAddress());
            //    Console.WriteLine(" -Line Numbers Address 0x{0:X6}", section.GetLineNumbersAddress());
            //    Console.WriteLine(" -Relocations Count 0x{0:X6}", section.GetRelocationsCount());
            //    Console.WriteLine(" -Line Number Count 0x{0:X6}", section.GetLineNumbersCount());
            //    Console.WriteLine("");
            //}
            //#endregion     //Console.WriteLine("");
            //#region CLR
            //CLRHeader clr = reader.GetCLRHeader();
            //Console.WriteLine("CLR Header:");
            //Console.WriteLine(" -Magic Number: 0x{0:X6}", clr.GetMagicNumber());
            //Console.WriteLine(" -Major Runtime Version: 0x{0:X6}", clr.GetMajorRuntimeVersion());
            //Console.WriteLine(" -Minor Runtime Version: 0x{0:X6}", clr.GetMinorRuntimeVersion());
            //Console.WriteLine(" -MetaData RVA: 0x{0:X6}", clr.GetMetaDataRVA());
            //Console.WriteLine(" -MetaData Size: 0x{0:X6}", clr.GetMetaDataSize());
            //Console.WriteLine(" -Flags: 0x{0:X6}", clr.GetFlags());
            //Console.WriteLine(" -EntryPoint Token: 0x{0:X6}", clr.GetEntryPointToken());
            //Console.WriteLine(" -Resources RVA: 0x{0:X6}", clr.GetResourcesRVA());
            //Console.WriteLine(" -Resource Size: 0x{0:X6}", clr.GetResourcesSize());
            //Console.WriteLine(" -Strong Name Signature RVA: 0x{0:X6}", clr.GetStrongNameSigRVA());
            //Console.WriteLine(" -Strong Name Signature Size: 0x{0:X6}", clr.GetStrongNameSigSize());
            //Console.WriteLine(" -Code Manager Table RVA: 0x{0:X6}", clr.GetCodeManagerTableRVA());
            //Console.WriteLine(" -Code Manager Table Size: 0x{0:X6}", clr.GetCodeManagerTableSize());
            //Console.WriteLine(" -VTable Fixup RVA: 0x{0:X6}", clr.GetVTableFixRVA());
            //Console.WriteLine(" -VTable Fixup Size: 0x{0:X6}", clr.GetVTableFixSize());
            //Console.WriteLine(" -Export Address Table Jumps RVA: 0x{0:X6}", clr.GetExportAddressTableJumpsRVA());
            //Console.WriteLine(" -Export Address Table Jumps Size: 0x{0:X6}", clr.GetExportAddressTableJumpsSize());
            //Console.WriteLine(" -Managed Native Header RVA: 0x{0:X6}", clr.GetManagedNativeHeaderRVA());
            //Console.WriteLine(" -Managed Native Header Size: 0x{0:X6}", clr.GetManagedNativeHeaderSize());
            //Console.WriteLine("");
            //#endregion
            //#region meta
            //MetadataHeader meta = reader.GetMetadataHeader();
            //Console.WriteLine("MetaData Header: ");
            //Console.WriteLine(" -Signature: 0x{0:X6}", meta.GetSignature());
            //Console.WriteLine(" -Major Version: 0x{0:X6}", meta.GetMajorVersion());
            //Console.WriteLine(" -Minor Version: 0x{0:X6}", meta.GetMinorVersion());
            //Console.WriteLine(" -Version Length: 0x{0:X6}", meta.GetVersionLength());
            //Console.WriteLine(" -Flags: 0x{0:X6}", meta.GetFlags());
            //Console.WriteLine(" -Number of Streams: 0x{0:X6}", meta.GetNumberOfStreams());
            //Console.WriteLine("");
            //#endregion
            #endregion

            //reader.Write(@"C:\Users\Joe\Documents\Visual Studio 2012\Projects\TestFlow\TestFlow\bin\Debug\TestFlowJOE.exe");
            Console.WriteLine("Done!");

            Console.Read();
        }
    }
}
