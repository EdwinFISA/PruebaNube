# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia archivos de solución y proyecto
COPY *.sln .
COPY TiendaKeytlin.Server/*.csproj ./TiendaKeytlin.Server/
RUN dotnet restore

# Copia el resto del código y publica
COPY . .
WORKDIR /app/TiendaKeytlin.Server
RUN dotnet publish -c Release -o /app/out

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "TiendaKeytlin.Server.dll"]
