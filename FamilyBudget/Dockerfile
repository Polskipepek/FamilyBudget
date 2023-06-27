# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FamilyBudget/FamilyBudget.csproj", "FamilyBudget/"]
COPY ["FamilyBudget.Model/FamilyBudget.Model.csproj", "FamilyBudget.Model/"]
RUN dotnet restore "FamilyBudget/FamilyBudget.csproj"
COPY . .
WORKDIR "/src/FamilyBudget"
RUN dotnet build "FamilyBudget.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FamilyBudget.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN apt-get update && apt-get install -y libpq-dev

# Install PostgreSQL client
RUN apt-get install -y postgresql-client

# Set environment variables for connecting to the PostgreSQL server
ENV DB_HOST=localhost
ENV DB_PORT=5432
ENV DB_NAME=FamilyBudgetDatabase
ENV DB_USER=posgres
ENV DB_PASSWORD=CeP*kfc3&*n*35

# Wait for the PostgreSQL server to be ready before starting the application
COPY wait-for-postgres.sh /wait-for-postgres.sh
RUN chmod +x /wait-for-postgres.sh

ENTRYPOINT ["/wait-for-postgres.sh", "dotnet", "FamilyBudget.dll"]