@echo off

REM Apply deployment
kubectl delete -f frontend-deployment.yaml

REM Apply service
kubectl delete -f frontend-service.yaml

REM Add more kubectl apply commands for other resources as needed
