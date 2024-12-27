# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/EduTrail.WebUI/EduTrail.WebUI.csproj", "src/EduTrail.WebUI/"]
COPY ["src/EduTrail.Infrastructure/EduTrail.Infrastructure.csproj", "src/EduTrail.Infrastructure/"]
COPY ["src/EduTrail.Application/EduTrail.Application.csproj", "src/EduTrail.Application/"]
COPY ["src/EduTrail.Domain/EduTrail.Domain.csproj", "src/EduTrail.Domain/"]
COPY ["src/EduTrail.WebUI.Client/EduTrail.WebUI.Client.csproj", "src/EduTrail.WebUI.Client/"]
RUN dotnet restore "./src/EduTrail.WebUI/EduTrail.WebUI.csproj"
COPY . .
WORKDIR "/src/src/EduTrail.WebUI"
RUN dotnet build "./EduTrail.WebUI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EduTrail.WebUI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EduTrail.WebUI.dll"]