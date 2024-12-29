
#MM webapp
Write-Host "Building image"
docker build --no-cache -t 192.168.0.160:32000/menu-maker-webapp:latest src/frontend/menumaker-spa/
Write-Host "Image built"

Write-Host "Pushing image"
docker push 192.168.0.160:32000/menu-maker-webapp:latest