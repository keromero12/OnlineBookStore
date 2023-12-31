@echo off

docker build -t book-service:v1.0.0 .
docker push book-service:v1.0.0

REM Apply deployment
kubectl apply -f book-deployment.yaml

REM Apply service
kubectl apply -f book-service.yaml

REM Add more kubectl apply commands for other resources as needed
