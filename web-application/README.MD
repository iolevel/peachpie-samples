## Web Application Sample

The `website` project is written in PHP and compiled to .NET Core.

Project `App` initializes a web server running on localhost:5004 and passing requests to compiled PHP scripts.

## What does it do?

The PHP sources are compiled to .NET Core by Peachpie compiler which is seamlessly downloaded by *dotnet* itself.

The sample instantiates Kestrel - the opensource web server - and AspNetCore pipeline. The pipeline handles requests to PHP files using Peachpie `RequestDelegate` by calling corresponding compiled scripts in `website.dll`.

Note the original PHP sources (*.php files) are not needed to run the compiled application.

## Docker image

The docker image [`iolevel/peachpie-aspnetcore`](https://hub.docker.com/repository/docker/iolevel/peachpie-aspnetcore) compiles and exposes the `website` directory.

## Prerequisites

- .NET Core 3.1 or newer; https://dotnet.microsoft.com/download
- Optionally - Visual Studio Code; https://code.visualstudio.com/
- Optionally - PeachPie for VSCode; https://marketplace.visualstudio.com/items?itemName=iolevel.peachpie-vscode

## How to run the project

1. `dotnet run -p app`
