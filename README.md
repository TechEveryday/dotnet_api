# dotnet_api

Sample API for educational purposes.

## Getting Started

Run `./scripts/dotnet.sh`

This script will do the following

- build the postgres image
- build our application
- update our database
- run our application

Then navigate you should be able to navigate [here](https://localhost:5001/swagger/index.html)

## To Accesss the database

run `./db.sh`

## Accessing database with Dbeaver

Download and install via [here](https://dbeaver.io/download/)

Open DBeaver, and on the left hand pane in the "Database Navigate" click on the Plug with a + icon

Search for "postgres" ( the elephant one )

Click Next

Host: localhost
Port: 5432
Database: localdb
Username: user
Password: password

Click Finish

After adding the connection, right click on "localdb" in the left hand pane

Select "Connect"

right click on "localdb" again, select "SQL Editor" then click on "New SQL Script"

After typing out your query, highlight your query, then press "CTRL + Enter" to execute the query.
