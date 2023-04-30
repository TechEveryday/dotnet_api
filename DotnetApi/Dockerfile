#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

ENV DATABASE_URL=$DATABASE_URL

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

ENV DATABASE_URL=$DATABASE_URL

WORKDIR /app
COPY ["DotnetApi.csproj", "."]
RUN dotnet restore "./DotnetApi.csproj"
COPY . .
WORKDIR "/app/."

RUN dotnet build "DotnetApi.csproj" -c Release -o /app/build

FROM build AS publish

ENV DATABASE_URL=$DATABASE_URL

RUN dotnet publish "DotnetApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENV DATABASE_URL=$DATABASE_URL
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "DotnetApi.dll"]
