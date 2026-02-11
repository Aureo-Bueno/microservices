# Microservices

## Visao geral
Este repositorio contem quatro servicos principais, cada um organizado em camadas (Domain, Application, Infrastructure) dentro da pasta do proprio servico.

### Catalog.API
- Responsavel por produtos do catalogo (MongoDB).
- Camadas: `Catalog.Domain`, `Catalog.Application`, `Catalog.Infrastructure`.
- Swagger: `http://localhost:8000/swagger` (via Docker).

### Bascket.API
- Responsavel pelo carrinho de compras (Redis) e integra com Discount.Grpc.
- Camadas: `Bascket.Domain`, `Bascket.Application`, `Bascket.Infrastructure`.
- Swagger: `http://localhost:8001/swagger` (via Docker).

### Discount.API
- API REST de descontos (PostgreSQL).
- Camadas: `Discount.API.Domain`, `Discount.API.Application`, `Discount.API.Infrastructure`.
- Swagger: `http://localhost:8002/swagger` (via Docker).

### Discount.Grpc
- Servico gRPC de descontos (PostgreSQL).
- Camadas: `Discount.Grpc.Domain`, `Discount.Grpc.Application`, `Discount.Grpc.Infrastructure`.
- gRPC: `http://localhost:8003` (via Docker).

## Requisitos
- .NET 10 SDK
- Docker + Docker Compose

## Subir tudo com Docker Compose
Na raiz do repositorio:
```bash
docker compose up -d --build
```

Para parar:
```bash
docker compose down
```

## Subir um servico especifico com Docker Compose
```bash
docker compose up -d --build catalog.api
docker compose up -d --build bascket.api
docker compose up -d --build discount.api
docker compose up -d --build discount.grpc
```

## Rodar localmente (sem Docker)
Execute cada servico separadamente:
```bash
dotnet run --project Catalog.API/Catalog.API.csproj
dotnet run --project Bascket.API/Bascket.API.csproj
dotnet run --project Discount.API/Discount.API.csproj
dotnet run --project Discount.Grpc/Discount.Grpc.csproj
```

### Variaveis de ambiente recomendadas (local)
Se nao usar Docker, configure pelo menos:
- `Catalog.API`
  - `DatabaseSettings:ConnectionString=mongodb://localhost:27017`
- `Bascket.API`
  - `CacheSettings:ConnectionString=localhost:6379`
  - `GrpcSettings:DiscountUrl=http://localhost:8003`
- `Discount.API` e `Discount.Grpc`
  - `DatabaseSettings:ConnectionString=Server=localhost;Port=5432;Database=DiscountFb;User Id=admin;Password=admin`

## Portas no Docker Compose
- Catalog.API: `8000 -> 8080`
- Bascket.API: `8001 -> 8080`
- Discount.API: `8002 -> 8080`
- Discount.Grpc: `8003 -> 8080`
- MongoDB: `27017`
- Redis: `6379`
- Postgres: `5432`
- pgAdmin: `5050`
