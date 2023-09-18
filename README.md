# Gerenciamento de Contas
Desafio Técnico para Desenvolvedor DotNet - Órama

**Para executar o docker compose com o RabbitMQ**
Navegue até a pasta /gerenciamento-contas.Api e execute o comando:
Execute o comando: 
sudo docker-compose up

**Para executar a API**
Navegue até a pasta /gerenciamento-contas.Api e execute o comando:
dotnet run 

**Para executar o projeto console/consumer, que consome a fila assíncrona**
Navegue até a pasta RabbitMQ.Consumer e execute o comando:
dotnet run amqp://guest:guest@localhost:5672  financial-assets



