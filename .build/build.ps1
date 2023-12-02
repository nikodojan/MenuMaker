
#MMAPI
Write-Information "Cleaning project"
dotnet clean src/services/MenuMaker/MenuMaker.Api/MenuMaker.Api.csproj

Write-Information "Building project"
dotnet build src/services/MenuMaker/MenuMaker.Api/MenuMaker.Api.csproj -c Release

Write-Information "Building image"
docker build --no-cache -t 192.168.0.110:32000/menu-maker-api-arm64:latest src/services/MenuMaker/MenuMaker.Api/bin/Release/net8.0
Write-Information "Image built"

Write-Information "Pushing image"
docker push 192.168.0.110:32000/menu-maker-api-arm64:latest