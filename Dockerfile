# syntax=docker/dockerfile:1

# ============ Etapa 1: compilar y publicar ============
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# 1) Solo el .csproj: la capa de "restore" queda en caché mientras no cambien los paquetes NuGet
COPY AggronomyProject/AggronomyProject.csproj AggronomyProject/
RUN dotnet restore AggronomyProject/AggronomyProject.csproj

# 2) El resto del código
COPY AggronomyProject/ AggronomyProject/
RUN dotnet publish AggronomyProject/AggronomyProject.csproj \
    -c Release -o /app/publish --no-restore /p:UseAppHost=false

# ============ Etapa 2: imagen final (solo runtime) ============
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_ENVIRONMENT=Production \
    PORT=8080
EXPOSE 8080

# No ejecutar como root (el usuario "app" ya viene en las imágenes de .NET 8+)
USER $APP_UID

# Escucha en $PORT: Railway lo define solo; en local queda 8080.
# "exec" hace que dotnet reciba las señales de parada (docker stop).
CMD ["sh", "-c", "exec dotnet AggronomyProject.dll --urls http://0.0.0.0:${PORT}"]
