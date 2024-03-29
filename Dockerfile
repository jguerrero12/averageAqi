FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Install node and npm
RUN apt-get update && apt-get install -y \
    npm \
    nodejs \
    && rm -rf /var/lib/apt/lists/*
# Restore as distinct layers
RUN dotnet restore "applications/webapp/src/webapp.csproj"
# Build and publish a release
RUN dotnet publish "applications/webapp/src/webapp.csproj" -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
ENV DOTNET_EnableDiagnostics=0
# Run the app. CMD is required to run on Heroku
# $PORT is set by Heroku
CMD ASPNETCORE_URLS="http://*:$PORT" dotnet webapp.dll