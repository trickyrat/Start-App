#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Start-App.Api/Start-App.Api.csproj", "Start-App.Api/"]
COPY ["Start-App.Service/Start-App.Service.csproj", "Start-App.Service/"]
COPY ["Start-App.Data/Start-App.Data.csproj", "Start-App.Data/"]
COPY ["Start-App.Domain/Start-App.Domain.csproj", "Start-App.Domain/"]
COPY ["Start-App.Helper/Start-App.Helper.csproj", "Start-App.Helper/"]
RUN dotnet restore "Start-App.Api/Start-App.Api.csproj"
COPY . .
WORKDIR "/src/Start-App.Api"
RUN dotnet build "Start-App.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Start-App.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Start-App.Api.dll"]