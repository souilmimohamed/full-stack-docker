FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["TestDotNetCore/TestDotNetCore.csproj","TestDotNetCore/"]
COPY ["Core.Weather/Core.Weather.csproj", "Core.Weather/"]
COPY ["Infrastructure/Infrastructure.Data/Infrastructure.Data.csproj", "Infrastructure/Infrastructure.Data/"]
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    build-essential \
    && rm -rf /var/lib/apt/lists/* 
RUN dotnet restore "TestDotNetCore/TestDotNetCore.csproj"
COPY . .
WORKDIR /src/TestDotNetCore
RUN dotnet build "TestDotNetCore.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "TestDotNetCore.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","TestDotNetCore.dll"]