## C# Extension Library for PHP

The `library` project is a sample C# project containing extension functions to be used in PHP compiled by Peachpie.

The `samplephp` project is written in PHP to demonstrate use of `library`.

## What does it do?

The PHP sources are compiled to .NET Core by Peachpie compiler which is seamlessly downloaded by *dotnet* itself.

The sample compiles C# project and references it by PHP project. C# declaration become available seamlessly to PHP code.

## Prerequisites

- .NET Core Sdk 2.1 or newer
- Optionally - Visual Studio Code or Visual Studio 2017

## How to run the project

1. `dotnet restore`
2. `dotnet run -p samplephp`
