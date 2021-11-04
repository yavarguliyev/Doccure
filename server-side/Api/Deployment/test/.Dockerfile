#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
LABEL maintainer="Yavar Guliyev (yavar10gaucho@gmail.com)"
ENV ASPNETCORE_URLS=https://+:5001;http://+:5000
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:$HOME/.dotnet/tools/"

COPY ["Api/Api.csproj", "Api/"]
COPY ["Data/Data.csproj", "Data/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["Services/Services.csproj", "Services/"]
RUN dotnet restore "Api/Api.csproj"
COPY . .

WORKDIR /app/Api
RUN dotnet build "Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]