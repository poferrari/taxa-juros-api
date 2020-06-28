# taxa-juros-api #

API que retorna a taxa de juros

* Azure App Service: https://api-taxa-juros.azurewebsites.net/swagger/index.html

### comandos Docker ###

* docker build -t api-taxa-juros-imagem -f Dockerfile .
* docker images
* docker run --name api-taxa-juros -d -p 5007:80 --rm api-taxa-juros-imagem
* docker ps -a
* docker stop api-taxa-juros
* docker rm api-taxa-juros
* docker rmi api-taxa-juros-imagem:latest

### comandos Docker Compose ###

* docker-compose up
* docker-compose down

### comandos Azure CLI ###

* az login

* myResourceGroup=ApiJurosRG
* planappname=ApiJurosPlan
* webappname=api-taxa-juros
* gitrepo=https://github.com/poferrari/taxa-juros-api

* az group create --location eastus --name $myResourceGroup
* az appservice plan create --name $planappname --resource-group $myResourceGroup --sku FREE
* az webapp create --name $webappname --resource-group $myResourceGroup --plan $planappname
* az webapp deployment source config --name $webappname --resource-group $myResourceGroup --repo-url $gitrepo --branch master --manual-integration
* echo http://$webappname.azurewebsites.net/swagger/index.html
* az group delete --name $myResourceGroup --yes

### testes das API´s com Postman ###

* https://www.getpostman.com/collections/32c5916a0d98eb09599b
* Importar a collection APIJuros.postman_collection.json

### Referências ###

- https://docs.microsoft.com/pt-br/cli/azure/get-started-with-azure-cli?view=azure-cli-latest
- https://docs.microsoft.com/pt-br/azure/app-service/scripts/cli-deploy-github
- https://docs.microsoft.com/pt-br/azure/app-service/scripts/cli-continuous-deployment-github
- https://medium.com/@nelson.souza/net-core-api-versioning-d4f869fb9052
- https://medium.com/@renato.groffe/github-azure-app-service-deployment-automatizado-e-sem-complica%C3%A7%C3%B5es-de-web-apps-na-nuvem-4c0a0439e096
- https://docs.microsoft.com/pt-br/visualstudio/deployment/tutorial-import-publish-settings-azure?view=vs-2019
- https://medium.com/@renato.groffe/asp-net-core-apis-rest-na-nuvem-com-docker-e-azure-web-app-4a82f9f594a5