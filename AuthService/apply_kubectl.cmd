@echo off

docker build -t auth-service:v1.0.0 .
docker push auth-service:v1.0.0

REM Apply deployment
kubectl apply -f auth-deployment.yaml

REM Apply service
kubectl apply -f auth-service.yaml

REM Add more kubectl apply commands for other resources as needed
