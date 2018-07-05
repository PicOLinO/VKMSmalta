#region Usings

using Vkm.Smalta.Network;

#endregion

namespace Vkm.Smalta
{
    public class Config
    {
        public Config(string adminUriBase)
        {
            AdminUri = new AdminUri(adminUriBase);
        }

        public AdminUri AdminUri { get; }
    }
}