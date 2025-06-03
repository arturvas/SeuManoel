# SeuManoel.API

## Como rodar
- Requisitos: Docker + Docker Compose
- Comando:
  docker compose up --build

## Endpoints principais
- Swagger: http://localhost:8080/swagger
- POST /api/Pedidos/empacotar: recebe lista de pedidos e retorna caixas recomendadas

## Exemplo de chamada
- Use o arquivo `entrada.json` em 'SeuManoel.API/temp/entrada.json' que foi fornecido no teste como corpo da requisição.
