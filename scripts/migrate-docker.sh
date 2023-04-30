#!/usr/bin/env bash
# docker-compose -f docker-compose.yml up --build -d --remove-orphans migrations
docker exec -it app dotnet tool restore & dotnet ef database update --project DotnetApi
docker exec -it pgdb psql -h localhost -p 5432 -U user -d localdb
# run --entrypoint="" migrations dotnet dotnet-ef update
