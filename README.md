# dotnet_api

run the following cmd to install the tools needed for interacting with entity framework
`dotnet tool install --global dotnet-ef`

# Getting Started

## Using Docker

run `./docker.sh`
In a separate terminal
run `./migrate.sh`

## Not Using Docker

run `dotnet restore`
run `dotnet build`
run `dotnet run`

## To Accesss the database

run `./db.sh`
