#!/usr/bin/env bash
docker-compose -f docker-compose.yml up --build -d --remove-orphans pgdb
dotnet restore DotnetApi
dotnet build DotnetApi
dotnet tool restore
dotnet dotnet-ef database update --project DotnetApi
dotnet run --project DotnetApi
