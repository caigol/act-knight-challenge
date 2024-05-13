# Use a imagem de base do Node.js
FROM node:16 AS build
WORKDIR /app

# Copie os arquivos do projeto e instale as dependências
COPY . .
RUN npm install

# Build do projeto
RUN npm run build

# Definir a imagem de base
FROM nginx:latest AS runtime
COPY --from=build /app/dist /usr/share/nginx/html

# Exponha a porta
EXPOSE 80

# O Nginx será iniciado automaticamente ao iniciar o contêiner
