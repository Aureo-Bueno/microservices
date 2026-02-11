#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["Bascket.API/Bascket.API.csproj", "Bascket.API/"]
COPY ["Bascket.API/Bascket.Domain/Bascket.Domain.csproj", "Bascket.API/Bascket.Domain/"]
COPY ["Bascket.API/Bascket.Application/Bascket.Application.csproj", "Bascket.API/Bascket.Application/"]
COPY ["Bascket.API/Bascket.Infrastructure/Bascket.Infrastructure.csproj", "Bascket.API/Bascket.Infrastructure/"]
RUN dotnet restore "Bascket.API/Bascket.API.csproj"
COPY . .
WORKDIR "/src/Bascket.API"
RUN dotnet build "Bascket.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bascket.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bascket.API.dll"]
