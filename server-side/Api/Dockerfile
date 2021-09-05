#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used for VS debugging on Docker
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
LABEL maintainer="Yavar Guliyev (yavar10gaucho@gmail.com)"

ENV ASPNETCORE_URLS=https://+:5001;http://+:5000

WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
RUN curl -sL https://deb.nodesource.com/setup_12.x | bash -
RUN apt install -y nodejs
WORKDIR /src
COPY ["src/Api/Api.csproj", "src/Api/"]
COPY ["src/Data/Data.csproj", "src/Data/"]
COPY ["src/Core/Core.csproj", "src/Core/"]
COPY ["src/Services/Services.csproj", "src/Services/"]
RUN dotnet restore "src/Api/Api.csproj"
COPY . .
WORKDIR "/src/server-side/Api"
RUN dotnet build "Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]