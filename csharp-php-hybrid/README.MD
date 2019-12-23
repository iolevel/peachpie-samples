## C# and PHP Interoperability Sample

The sample consists of a PHP project `phplib` and an executable C# project `csharpapp`.

`phplib` functions and class declaration 'User'

## What does it do?

The PHP sources are compiled to .NET Core by Peachpie compiler which is seamlessly downloaded by *dotnet* itself.

`csharpapp` drives the use of PHP code, inherits PHP class in C# and defines PHP function in C#. First it sideloads compiled PHP project, then it defines a PHP function written in C# as lambda and then it calls PHP functions from C#.

## Prerequisites

- .NET Core Sdk 3.0 or newer
- Optionally - Visual Studio Code or Visual Studio 2017

## How to run the project

1. `dotnet restore`
2. `dotnet run -p csharpapp`

## Further information

Read more about this particular sample in our corresponding [blog post]( http://www.peachpie.io/2017/01/csharp-php-interop.html) or watch the video here:

<a href="https://youtu.be/xnQTsdJhvtk
" target="_blank"><img src="http://img.youtube.com/vi/xnQTsdJhvtk/0.jpg" 
alt="C#/PHP interop" width="480" height="360" border="10" /></a>
