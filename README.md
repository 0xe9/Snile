### What is Snile?
Snile is a super fast IL editing library that can read/write .NET Files. This project was written to be able to be used with obfuscated files. Meaning it won't throw exception's or errors like other .NET libraries do. It can support invalid metadata in the CLR header which is the .NET Header. Snile stand's for Super .NET IL Editor


### Features
* Can read **any** .NET Module
* Can read **any** file with a CLR Header
* 100% Read/Write to **any** header. (DOS, NT, FILE, OPTIONAL, DATA_DIRECTORIES, CLR, TABLE)
* Access to all the file's sections, which you can add/remove sections.
* Very fast and stable
* Updated Frequently

### Examples
Some examples with some things you can do with this library.

Getting the .text section.
```
Reader assembly = new Reader("C:\Example.exe");
Section textSection = assembly.GetSections().GetTextSection();
Console.WriteLine("Virtual Address: 0x{0:X}", textSection.GetVirtualAddress());
```



### Authors and Contributors
Joe. - @0xe9

### Support or Contact
Having trouble with Snile? Contact me at jadamita@hotmail.com and we’ll help you sort it out.

If you're using the GitHub for Mac, simply sync your repository and you'll see the new branch.
