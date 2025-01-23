kubectl apply -f ./src/infra/k8s/menu-maker-namespace.yml
kubectl apply -f ./src/infra/k8s/mm-api/mm-api.yml
kubectl apply -f ./src/infra/k8s/mm-frontend/mm-frontend.yml