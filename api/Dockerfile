# Use uma imagem do .NET SDK para construir o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar arquivos do projeto
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /out

# Use uma imagem mais leve do .NET para rodar o projeto
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

# Expõe a porta 9000 (porta do backend ./api)
EXPOSE 9000
ENV ASPNETCORE_URLS=http://+:9000

# Comando para rodar a aplicação
ENTRYPOINT ["dotnet", "api.dll"]
