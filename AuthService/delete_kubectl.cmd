@echo off

REM Apply deployment
kubectl delete -f auth-deployment.yaml

REM Apply service
kubectl delete -f auth-service.yaml

REM Add more kubectl apply commands for other resources as needed
