using System;

namespace CSharpLib
{
    public class X
    {
        public static int DoSomething(string str)
        {
            return int.Parse(str);
        }

        public string GetSomething()
        {
            return this.GetType().ToString();
        }
    }
}
