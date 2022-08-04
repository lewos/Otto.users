#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
# copiar todos los proyectos al directorio workdir
COPY . .

RUN dotnet restore "./Otto.orders/Otto.users.csproj"
RUN dotnet publish "./Otto.orders/Otto.users.csproj" -c Release -o /app

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./

CMD ASPNETCORE_URLS=http://*:$PORT dotnet Otto.users.dll