# Average AQI APP

An [application continuum](https://www.appcontinuum.io/) style project using C# and .NET
that includes a single web application with two background workers.

* Basic web application
* Data analyzer
* Data collector

### Technology stack

This codebase is written in a language called [C#](https://learn.microsoft.com/en-us/dotnet/csharp/) that is able to run on the .NET framework.
It uses the [.NET](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-7.0) web framework, and runs on the [kestrel](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-7.0) web server.
HTML templates are written using [React](https://react.js).
The codebase is tested with [xUnit](https://xunit.net) and uses [dotnet-cli](https://learn.microsoft.com/en-us/dotnet/core/tools/) to build the project.
The [dotnet-buildpack](https://github.com/jincod/dotnetcore-buildpack) is used to build a [Docker](https://www.docker.com/) container which is deployed to
[Heroku](https://heroku.com/) on Heroku's Platform.

## Getting Started

## Development

1.  Build a .NET Archive (.dll) file.
    ```bash
    cd applications/(...) && dotnet build
    ```

Run the servers locally using the below example.

### run application

```bash
cd applications/(...) && dotnet run
```

## Production

Building a Docker container and running with Docker.

## Docker

1.  Install [docker](https://docs.docker.com/get-docker/) CLI.

1.  run docker compose up
    ```bash
    docker compose up
    ```

That's a wrap for now.
