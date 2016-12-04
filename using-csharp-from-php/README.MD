## C# Interoperability Sample

The `CSharpLib` project is a sample C# project containing some public class and methods that we'll call in PHP.

The `phpapp` project is written in PHP and compiled to .NET Core.

## What does it do?

The PHP sources are compiled to .NET Core by Peachpie compiler which is seamlessly downloaded by *dotnet* itself.

The sample compiles C# project and references it by PHP project. C# declaration become available seamlessly to PHP code.

## Prerequisites

- .NET Core 1.0 or newer
- Optionally - Visual Studio Code 

## How to run the project

1. `dotnet restore`
2. `dotnet run -p phpapp`
