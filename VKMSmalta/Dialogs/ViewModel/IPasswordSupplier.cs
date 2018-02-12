using System.Security;

namespace VKMSmalta.Dialogs.ViewModel
{
    public interface IPasswordSupplier
    {
        SecureString GetPassword();
    }
}