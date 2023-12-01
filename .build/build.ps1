
#MMAPI
dotnet build src/services/MenuMaker/MenuMaker.Api/MenuMaker.Api.csproj -c Release

docker build --no-cache -t 192.168.0.110:32000/menu-maker-api-arm64:latest src/services/MenuMaker/MenuMaker.Api/bin/Release/net8.0

docker push 192.168.0.110:32000/menu-maker-api-arm64:latest