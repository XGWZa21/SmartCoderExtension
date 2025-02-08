// Controls/PackageGuids.cs
using System;

namespace SmartCoderExtension.Utilities
{
    public static class PackageGuids
    {
        public const string PackageString = "849473DB-5BD1-4023-8505-71B2EE2A708A";
        public static readonly Guid Package = new Guid(PackageString);

        public const string CommandSetString = "[68DFC6F1-FC97-49AA-B80C-E634FC47CD72";
        public static readonly Guid CommandSet = new Guid(CommandSetString);
    }
}