# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# copy csproj first for better layer caching
COPY master-backend/*.csproj ./master-backend/
RUN dotnet restore ./master-backend/master-backend.csproj

# copy the rest and publish
COPY master-backend/ ./master-backend/
WORKDIR /src/master-backend
RUN dotnet publish -c Release -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "master-backend.dll"]
