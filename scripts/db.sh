docker-compose -f docker-compose.yml up --build -d --remove-orphans pgdb
docker exec -it dotnet_api-pgdb-1 psql -h localhost -p 5432 -U user -d localdb
