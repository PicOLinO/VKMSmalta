using VKMSmalta.Network;

namespace VKMSmalta
{
    public class Config
    {
        public AdminUri AdminUri { get; }

        public Config(string adminUriBase)
        {
            AdminUri = new AdminUri(adminUriBase);
        }

    }
}