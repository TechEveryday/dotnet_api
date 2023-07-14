# dotnet_api

Sample API for educational purposes.

## Setup

### Install Visual Studio

Click [here](https://visualstudio.microsoft.com/downloads/)

### Install NET Core SDK

Click [here](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.301-macos-x64-installer)

## Running the Application

Note

In `Startup.cs`, if you run this locally then you'll need to use line 46-47. Otherwise for deploying, use line 34-43.

For local development navigate to the project `/dotnet_api/DotnetApi` and run the following
```
dotnet restore
dotnet build
dotnet tool restore
```

After that, navigate to the root of the solution. `/dotnet_api` and run
```
./scripts/docker.sh
```
that will spin up the app and database in the docker container

Navigate to docker desktop, and turn the `app` service off

then in your terminal navigate back to the project `/dotnet_api/DotnetApi` and run
```
dotnet-ef database update
dotnet run
```

<!-- Run `./scripts/dotnet.sh`

This script will do the following

- build the postgres image
- build our application
- update our database
- run our application -->

Then navigate you should be able to navigate [here](https://localhost:5001/swagger/index.html) or [here](http://localhost:5000/swagger/index.html)

## Updating Schema

If you are in need of updating the schema for the database, then make sure after you make your changes to the model that
you navigate to the project directory so `/dotnet_api/DotnetApi` and run the following commands

```
dotnet-ef migrations add NameOfChangesHere
dotnet-ef database update
```

You should see new files added to `/DotnetApi/Migrations`

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
flyctl proxy 5432 -a connect-api-db
```

TODO NEXT SESSION

- new endpoints
- new service
- create repository
