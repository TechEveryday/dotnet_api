# docker-compose -f docker-compose.yml up --build -d --remove-orphans pgdb
docker exec -it pgdb psql -h localhost -p 5432 -U user -d postgres
