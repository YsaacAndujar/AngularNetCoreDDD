#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


# Prevent 'Warning: apt-key output should not be parsed (stdout is not a terminal)'
ENV APT_KEY_DONT_WARN_ON_DANGEROUS_USAGE=1



FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FrontApi/FrontApi.csproj", "FrontApi/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["infrastructure/Infrastructure.csproj", "infrastructure/"]
RUN dotnet restore "FrontApi/FrontApi.csproj"
COPY . .
WORKDIR "/src/FrontApi"
RUN dotnet build "FrontApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FrontApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FrontApi.dll"]