#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ARG ENV
ENV ASPNETCORE_ENVIRONMENT=$ENV

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FamilyBudget.API/FamilyBudget.API.csproj", "FamilyBudget.API/"]
RUN dotnet restore "FamilyBudget.API/FamilyBudget.API.csproj"
COPY . .
WORKDIR "/src/FamilyBudget.API"
RUN dotnet build "FamilyBudget.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FamilyBudget.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FamilyBudget.API.dll"]

#, "--environment=Production"