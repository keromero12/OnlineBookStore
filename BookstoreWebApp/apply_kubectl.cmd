@echo off

docker build -t frontend-service:v1.0.0 .
docker push frontend-service:v1.0.0

REM Apply deployment

kubectl apply -f frontend-deployment.yaml

REM Apply service

kubectl apply -f frontend-service.yaml

REM Add more kubectl apply commands for other resources as needed
