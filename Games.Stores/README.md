# Games Store Minimal API using .NET 7

To be done.

## SQL Server Docker Container

```powershell
$saPassword="Sample@123$"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$saPassword" -p 1433:1433 -v gamesstoresqlvolume:/var/opt/mssql -d --rm --name gamesstoresqlserver mcr.microsoft.com/mssql/server:2022-latest
```

## Path to Docker Volumes

[\\wsl$\docker-desktop-data\data\docker\volumes](\\wsl$\docker-desktop-data\data\docker\volumes)

## EF Core Tool

```powershell
dotnet tool install --global dotnet-ef

Microsoft.EntityFrameworkCore.Tools
```
