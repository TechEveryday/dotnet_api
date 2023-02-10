#!/usr/bin/env bash
docker-compose -f docker-compose.yml up --build -d --remove-orphans pgdb
dotnet restore WebApplication1
dotnet build WebApplication1
dotnet tool restore
dotnet dotnet-ef database update --project WebApplication1
dotnet run --project WebApplication1
