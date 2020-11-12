#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Start-App.Web/Start-App.Web.csproj", "Start-App.Web/"]
COPY ["Start-App.Service/Start-App.Service.csproj", "Start-App.Service/"]
COPY ["Start-App.Domain/Start-App.Domain.csproj", "Start-App.Domain/"]
COPY ["Start-App.Helper/Start-App.Helper.csproj", "Start-App.Helper/"]
RUN dotnet restore "Start-App.Web/Start-App.Web.csproj"
COPY . .
WORKDIR "/src/Start-App.Web"
RUN dotnet build "Start-App.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Start-App.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Start-App.Web.dll"]