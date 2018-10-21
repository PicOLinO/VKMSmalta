#region Usings

using Vkm.ComplexSim.Network;

#endregion

namespace Vkm.ComplexSim
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