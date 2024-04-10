#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# First stage: Copy the API.csproj and other necessary files into the image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-stage
WORKDIR /src
COPY ["../Backend/API/API.csproj", "API/"]
COPY ["../Backend/API/", "API/", "./"]

# Second stage: Perform the build and publish
FROM build-stage AS build
WORKDIR /src/API
RUN dotnet restore "./API.csproj"
RUN dotnet build "./API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./API.csproj" -c Release -o /app/publish

# Final stage: Set up the runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]