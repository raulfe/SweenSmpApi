#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Sween.API/Sween.API.csproj", "Sween.API/"]
COPY ["Sween.Core/Sween.Core.csproj", "Sween.Core/"]
COPY ["Sween.Infrastructure/Sween.Infrastructure.csproj", "Sween.Infrastructure/"]
RUN dotnet restore "Sween.API/Sween.API.csproj"
COPY . .
WORKDIR "/src/Sween.API"
RUN dotnet build "Sween.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sween.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sween.API.dll"]