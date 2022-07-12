# ASP.Net-AL-BE-Project

####  CREATE MIGRATIONS
```
 dotnet ef migrations add MigrationV1 --project Meter-API.csproj
```


#### List Unapplied Migrations
```
 dotnet ef migrations list --project Meter-API.csproj
```
#### Reflect Migrations in Db
```
dotnet ef database update MigrationV1 --project Meter-API.csproj
``` 



####  DOCKER-POSTGRES CONTAINER CREATE/UP
```
docker-compose up
```
