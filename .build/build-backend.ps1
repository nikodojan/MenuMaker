
#MMAPI
Write-Host "Cleaning project"
dotnet clean src/services/MenuMaker/MenuMaker.Api/MenuMaker.Api.csproj

Write-Host "Building project"
dotnet build src/services/MenuMaker/MenuMaker.Api/MenuMaker.Api.csproj -c Release

Write-Host "Building image"
docker build --no-cache -t 192.168.0.160:32000/menu-maker-api:latest src/services/MenuMaker/MenuMaker.Api/bin/Release/net8.0
Write-Host "Image built"

Write-Host "Pushing image"
docker push 192.168.0.160:32000/menu-maker-api:latest