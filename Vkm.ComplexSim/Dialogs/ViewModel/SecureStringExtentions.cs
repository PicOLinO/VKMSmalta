﻿#region Usings

using System;
using System.Runtime.InteropServices;
using System.Security;

#endregion

namespace Vkm.ComplexSim.Dialogs.ViewModel
{
    public static class SecureStringExtentions
    {
        public static string ConvertToUnsecureString(this SecureString securePassword)
        {
            if (securePassword == null)
            {
                throw new ArgumentNullException(nameof(securePassword));
            }

            var unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}