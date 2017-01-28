## C# and PHP Interoperability Sample

The sample consists of PHP project `phplib` and executable C# project `csharpapp`.

`phplib` functions and class declaration 'User'

## What does it do?

The PHP sources are compiled to .NET Core by Peachpie compiler which is seamlessly downloaded by *dotnet* itself.

`csharpapp` drives the use of PHP code, inherits PHP class in C# and defines PHP function in C#. First it sideloads compiled PHP project, then it defines a PHP function written in C# as lambda and then it calls PHP functions from C#.

## Prerequisites

- .NET Core 1.0 or newer
- Optionally - Visual Studio Code 

## How to run the project

1. `dotnet restore`
2. `dotnet run -p csharpapp`
