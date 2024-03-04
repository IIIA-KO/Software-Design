namespace _03_SingletonClassLibrary
{
    public sealed class Authenticator
    {
        private static Lazy<Authenticator> _instance = new Lazy<Authenticator>(() => new Authenticator());

        private static readonly object _instanceLock = new();

        private Authenticator() { }
        public static Authenticator Instance 
        {
            get
            { 
                if(_instance is null)
                {
                    lock(_instanceLock)
                    {
                        _instance ??= new Lazy<Authenticator>();
                    }
                }

                return _instance.Value;
            }
        }
    }
}