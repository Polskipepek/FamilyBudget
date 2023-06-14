#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

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

ENTRYPOINT ["dotnet", "FamilyBudget.dll"]

CMD ASPNETCORE_URLS=http://+:80 dotnet FamilyBudget.dll --network=host