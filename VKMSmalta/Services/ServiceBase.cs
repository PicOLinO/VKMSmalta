namespace VKMSmalta.Services
{
    public class ServiceBase<T> where T : new()
    {
        public static T Instance { get; private set; }

        public static void InitializeService()
        {
            if (Instance == null)
            {
                Instance = new T();
            }
        }
    }
}