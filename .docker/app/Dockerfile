#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY WebApplication1/WebApplication1.csproj WebApplication1/
COPY WebApplication1/WebApplication1.sln ./
COPY config/dotnet-tools.json .config/dotnet-tools.json
RUN dotnet restore "WebApplication1/WebApplication1.csproj"

COPY . .

RUN dotnet publish "WebApplication1/WebApplication1.csproj" -c Debug -o /app
# Need to figure out how to run the update in the container
# RUN dotnet tool restore && dotnet dotnet-ef database update --project WebApplication1

WORKDIR /app

ENTRYPOINT ["dotnet", "/app/WebApplication1.dll"]
