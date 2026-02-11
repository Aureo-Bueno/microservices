#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["Discount.API/Discount.API.csproj", "Discount.API/"]
COPY ["Discount.API/Discount.API.Domain/Discount.API.Domain.csproj", "Discount.API/Discount.API.Domain/"]
COPY ["Discount.API/Discount.API.Application/Discount.API.Application.csproj", "Discount.API/Discount.API.Application/"]
COPY ["Discount.API/Discount.API.Infrastructure/Discount.API.Infrastructure.csproj", "Discount.API/Discount.API.Infrastructure/"]
RUN dotnet restore "Discount.API/Discount.API.csproj"
COPY . .
WORKDIR "/src/Discount.API"
RUN dotnet build "Discount.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Discount.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Discount.API.dll"]
