FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy
EXPOSE 80
EXPOSE 443

WORKDIR /app
COPY . .
ENTRYPOINT ["dotnet", "MenuMaker.Api.dll"]