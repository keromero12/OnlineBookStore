@echo off

REM Apply deployment
kubectl delete -f book-deployment.yaml

REM Apply service
kubectl delete -f book-service.yaml

REM Add more kubectl apply commands for other resources as needed
