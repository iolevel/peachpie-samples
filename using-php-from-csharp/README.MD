## C# and PHP Interoperability Sample

The sample consists of PHP project `phplib` and executable C# project `csharpapp`.

`phplib` contains script file `main.php` and global function `demo`.

## What does it do?

The PHP sources are compiled to .NET Core by Peachpie compiler which is seamlessly downloaded by *dotnet* itself.

`csharpapp` drives the use of PHP code. First it sideloads compiled PHP project, then it defines a global variable, calls the script `main.php` and then it calls PHP function `demo` directly.   

## Prerequisites

- .NET Core 1.0 or newer
- Optionally - Visual Studio Code 

## How to run the project

1. `dotnet restore`
2. `dotnet run -p csharpapp`
