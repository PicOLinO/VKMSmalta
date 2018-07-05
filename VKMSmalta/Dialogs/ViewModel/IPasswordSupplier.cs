#region Usings

using System.Security;

#endregion

namespace Vkm.Smalta.Dialogs.ViewModel
{
    public interface IPasswordSupplier
    {
        SecureString GetConfirmPassword();
        SecureString GetPassword();
    }
}