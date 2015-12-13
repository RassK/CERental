using System;
using System.Runtime.InteropServices;

namespace CERental.Core.Helpers
{
    public class PipesHelper
    {
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool WaitNamedPipe(string name, int timeout);

        /// <summary>
        /// Method to test if Windows considers that a named pipe of a certain name exists or not.
        /// </summary>
        public static bool DoesNamedPipeExist(string pipeFileName)
        {
            try
            {
                return WaitNamedPipe(@"\\.\pipe\" + pipeFileName, 0);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}