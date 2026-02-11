#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["Discount.Grpc/Discount.Grpc.csproj", "Discount.Grpc/"]
COPY ["Discount.Grpc/Discount.Grpc.Domain/Discount.Grpc.Domain.csproj", "Discount.Grpc/Discount.Grpc.Domain/"]
COPY ["Discount.Grpc/Discount.Grpc.Application/Discount.Grpc.Application.csproj", "Discount.Grpc/Discount.Grpc.Application/"]
COPY ["Discount.Grpc/Discount.Grpc.Infrastructure/Discount.Grpc.Infrastructure.csproj", "Discount.Grpc/Discount.Grpc.Infrastructure/"]
RUN dotnet restore "Discount.Grpc/Discount.Grpc.csproj"
COPY . .
WORKDIR "/src/Discount.Grpc"
RUN dotnet build "Discount.Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Discount.Grpc.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Discount.Grpc.dll"]
