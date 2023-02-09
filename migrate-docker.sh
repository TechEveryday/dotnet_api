#!/usr/bin/env bash
docker-compose -f docker-compose.yml up --build -d --remove-orphans migrations
docker exec -it dotnet_api-migrations-1 dotnet tool restore & dotnet ef database update --project WebApplication1
docker exec -it dotnet_api-db-1 psql -h localhost -p 5432 -U user -d localdb
# run --entrypoint="" migrations dotnet dotnet-ef update
