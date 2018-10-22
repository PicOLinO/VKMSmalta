#region Usings

using System.Security;

#endregion

namespace Vkm.ComplexSim.Dialogs.ViewModel
{
    public interface IPasswordSupplier
    {
        SecureString GetConfirmPassword();
        SecureString GetPassword();
    }
}