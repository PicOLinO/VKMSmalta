#region Usings

using System.Security;

#endregion

namespace VKMSmalta.Dialogs.ViewModel
{
    public interface IPasswordSupplier
    {
        SecureString GetConfirmPassword();
        SecureString GetPassword();
    }
}