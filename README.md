# dotnet_api

Sample API for educational purposes.

## Setup

### Install Visual Studio

Click [here](https://visualstudio.microsoft.com/downloads/)

### Install NET Core SDK

Click [here](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.301-macos-x64-installer)

## Running the Application

Note

In `Startup.cs`, if you run this locally then you'll need to use line 32. Otherwise for deploying, use line 31.


Run `./scripts/dotnet.sh`

This script will do the following

- build the postgres image
- build our application
- update our database
- run our application

Then navigate you should be able to navigate [here](https://localhost:5001/swagger/index.html) or [here](http://localhost:5000/swagger/index.html)

### Having Issues?

Try running the following set of cmds

```
dotnet dev-certs https --clean
dotnet dev-certs https
dotnet dev-certs https --trust
```

## Database

### To Accesss the database

run `./db.sh`

### Accessing database with Dbeaver

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

### Proxy db to local

Cd to root directory and run

```
flyctl proxy 5432 -a connect-pgdb
```

TODO NEXT SESSION

- connect api locally to proxy
- make models for our new EAV schema
- new endpoints
- new service
- create repository
