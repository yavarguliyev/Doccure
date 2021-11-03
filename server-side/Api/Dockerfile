FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
LABEL maintainer="Yavar Guliyev (yavar10gaucho@gmail.com)"

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

ENV DOTNET_USE_POLLING_FILE_WATCHER 1

WORKDIR /app
COPY ["Api/Api.csproj", "Api/"]
COPY ["Data/Data.csproj", "Data/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["Services/Services.csproj", "Services/"]
COPY . .

WORKDIR /app/Api