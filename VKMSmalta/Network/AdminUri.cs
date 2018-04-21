namespace VKMSmalta.Network
{
    public class AdminUri
    {
        public string AdminUriBase { get; }

        public AdminUri(string adminUriBase)
        {
            AdminUriBase = adminUriBase.Trim('/', '\\');
        }
        
        public string AdminAddHistoryUri => $"{AdminUriBase}/api/v1/history";
        public string AdminAuthorizeUri => $"{AdminUriBase}/api/v1/auth/token";
        public string AdminRegisterUri => $"{AdminUriBase}/api/v1/auth/register";
        public string AdminResetPasswordUri => $"{AdminUriBase}/api/v1/auth/resetpwd";
        public string AdminGetFreeStudentsUri => $"{AdminUriBase}/api/v1/freestudents";
    }
}