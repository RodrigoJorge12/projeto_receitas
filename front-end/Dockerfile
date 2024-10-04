# Use a imagem do Nginx para servir os arquivos estáticos
FROM nginx:alpine
WORKDIR /usr/share/nginx/html

# Copiar os arquivos do front-end (HTML, CSS, JS) para o Nginx
COPY . .

# Expor a porta 80 para servir o conteúdo
EXPOSE 80
