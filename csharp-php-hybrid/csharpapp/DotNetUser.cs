using Pchp.Core;

namespace csharpapp
{
    class DotNetUser : User {
        public DotNetUser(Context ctx, string name, string url, string email)
            :base(ctx, name, url, email)
        {
            
        }

        public override PhpValue Authenticate() {
            return base.Authenticate();
        }
    }
}