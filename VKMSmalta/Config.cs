#region Usings

using VKMSmalta.Network;

#endregion

namespace VKMSmalta
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