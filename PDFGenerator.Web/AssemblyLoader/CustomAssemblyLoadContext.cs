using System;
using System.Runtime.Loader;

namespace PDFGenerator.Web.AssemblyLoader
{
    public class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        public IntPtr LoadUnmanagedLibrary(string absolutePath)
        {
            return LoadUnmanagedDll(absolutePath);
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedLibraryName)
        {
            return LoadUnmanagedDllFromPath(unmanagedLibraryName);
        }
    }
}
