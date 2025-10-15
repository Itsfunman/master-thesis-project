# ---- Build stage ----
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy only the csproj first (path includes the nested 'backend' folder)
COPY ./backend/backend.csproj ./backend/
RUN dotnet restore ./backend/backend.csproj

# Copy the rest of the source and publish
COPY ./backend ./backend
RUN dotnet publish ./backend/backend.csproj -c Release -o /out

# ---- Runtime stage ----
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS runtime
WORKDIR /app
COPY --from=build /out ./
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# DLL name follows the project: backend.csproj -> backend.dll
ENTRYPOINT ["dotnet", "backend.dll"]
