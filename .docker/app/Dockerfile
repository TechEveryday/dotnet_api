#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

ENV ASPNETCORE_URLS=http://+:5000
ENV DB_CONNECTION_STRING="Host=pgdb;Port=5432;Database=localdb;Username=user;Password=password"

WORKDIR /source
COPY DotnetApi/DotnetApi.csproj DotnetApi/
COPY DotnetApi/DotnetApi.sln ./
COPY config/dotnet-tools.json .config/dotnet-tools.json
RUN dotnet restore "DotnetApi"
RUN dotnet tool restore

COPY . .

RUN dotnet publish "DotnetApi/DotnetApi.csproj" -c Debug -o /app
# Need to figure out how to run the update in the container
# RUN dotnet dotnet-ef database update --project DotnetApi

WORKDIR /app

EXPOSE 5000

ENTRYPOINT ["dotnet", "/app/DotnetApi.dll"]
