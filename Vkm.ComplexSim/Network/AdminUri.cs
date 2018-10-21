namespace Vkm.ComplexSim.Network
{
    public class AdminUri
    {
        public AdminUri(string adminUriBase)
        {
            AdminUriBase = adminUriBase.Trim('/', '\\');
        }

        public string AdminAddHistoryUri => $"{AdminUriBase}/api/v1/history";
        public string AdminAuthorizeUri => $"{AdminUriBase}/api/v1/auth/token";
        public string AdminGetFreeStudentsUri => $"{AdminUriBase}/api/v1/freestudents";
        public string AdminRegisterUri => $"{AdminUriBase}/api/v1/auth/register";
        public string AdminResetPasswordUri => $"{AdminUriBase}/api/v1/auth/resetpwd";
        private string AdminUriBase { get; }
    }
}