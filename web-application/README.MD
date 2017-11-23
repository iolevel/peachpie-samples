## Web Application Sample

The `website` project is written in PHP and compiled to .NET Core.

Supporting `App` initializes a web server running on localhost:5004 and passing requests to compiled PHP scripts.

## What does it do?

The PHP sources are compiled to .NET Core by Peachpie compiler which is seamlessly downloaded by *dotnet* itself.

The sample instantiates Kestrel - the opensource web server - and ASP.NET Core pipeline. The pipeline handles requests to PHP files using Peachpie `RequestDelegate` by calling corresponding compiled scripts in `website.dll`.

Note the original PHP sources (*.php files) are not needed to run the compiled application.

## Prerequisites

- .NET Core 2.0 or newer
- Optionally - Visual Studio Code 

## How to run the project

1. `dotnet run -p app`
