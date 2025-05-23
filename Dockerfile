# Etapa 1: Construir Angular (solo si necesitas compilar algo)
FROM node:18 as angular-builder
WORKDIR /app
# (Esta etapa puede omitirse si solo usas archivos estáticos)

# Etapa 2: Construir .NET
FROM mcr.microsoft.com/dotnet/sdk:8.0 as dotnet-builder
WORKDIR /src

# Copia SOLO lo necesario para restaurar dependencias
COPY *.sln .
COPY TiendaKeytlin.Server/TiendaKeytlin.Server.csproj ./TiendaKeytlin.Server/

# Si realmente tienes un proyecto Client .NET (no Angular), usa:
# COPY TiendaKeytlin.Client/TiendaKeytlin.Client.csproj ./TiendaKeytlin.Client/

RUN dotnet restore "TiendaKeytlin.Server/TiendaKeytlin.Server.csproj"

# Copia TODO el código
COPY . .

# Si tienes Angular, copia los archivos estáticos
# COPY TiendaKeytlin.Client/dist ./TiendaKeytlin.Server/wwwroot

# Publica la aplicación
RUN dotnet publish "TiendaKeytlin.Server" -c Release -o /app/publish

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=dotnet-builder /app/publish .
ENTRYPOINT ["dotnet", "TiendaKeytlin.Server.dll"]