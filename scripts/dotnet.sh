#!/usr/bin/env bash
# NOTE THIS SCRIPT DOESNT WORK. IDK WHY
docker-compose -f docker-compose.yml up --build -d --remove-orphans pgdb app
dotnet restore --project DotnetApi
dotnet build --project DotnetApi
dotnet tool restore
dotnet dotnet-ef database update --project DotnetApi
dotnet run --project DotnetApi
