# Use the official Microsoft .NET image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "BookService.dll"]

ARG IMAGE_NAME=book-service
ARG IMAGE_TAG=v1.0.0
LABEL image.name=$IMAGE_NAME
LABEL image.tag=$IMAGE_TAG

EXPOSE 5002