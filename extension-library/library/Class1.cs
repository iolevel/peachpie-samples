using Pchp.Core;

[assembly: PhpExtension]

// Example:
public static class MyFunctions
{
    // declaration of a global PHP function 'mystrlen()'
    public static int mystrlen(string str) { return (str != null) ? str.Length : -1; }

    // declaration of a global PHP function 'myecho()' that requires a reference to current Pchp.Core.Context representing PHP runtime.
    public static void myecho(Context ctx, int value) { ctx.Echo(value); }

    // declaration of a global PHP constant 'MYCONST'
    public const int MYCONST = 456;

    // declaration of a global constant that is initialized dynamically
    public static readonly string MYCONST2 = System.Environment.MachineName;
}


// declaration of PHP class
[PhpType]
public class SampleClass
{
    // declaration of method
    public int foo() { return 123; }
}