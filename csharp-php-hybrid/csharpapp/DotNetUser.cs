using Pchp.Core;

namespace csharpapp
{
    class DotNetUser : User
    {
        public DotNetUser(string name, string url, string email)
            // : base(ctx, name, url, email) // base constructor using specific `Context`
            : base(name, url, email) // use the default `Context` as provided with ContextExtensions.CurrentContext
        {

        }

        public override PhpValue Authenticate()
        {
            return base.Authenticate();
        }
    }
}