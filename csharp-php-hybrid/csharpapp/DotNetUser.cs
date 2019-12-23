using Pchp.Core;

namespace csharpapp
{
    class DotNetUser : User
    {
        public DotNetUser(string name, string url, string email)
            : base(name, url, email)
        {

        }

        public override PhpValue Authenticate()
        {
            return base.Authenticate();
        }
    }
}