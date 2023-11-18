#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0-jammy-arm64v8 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0-jammy-arm64v8 AS build
WORKDIR /src
COPY ["MenuMaker.Api.csproj", "MenuMaker.Api/"]
RUN dotnet restore "MenuMaker.Api/MenuMaker.Api.csproj"
COPY . .
WORKDIR "/src/MenuMaker.Api"
RUN dotnet build "MenuMaker.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MenuMaker.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MenuMaker.Api.dll"]