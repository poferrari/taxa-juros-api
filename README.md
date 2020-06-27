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

### Referências ###

https://docs.microsoft.com/pt-br/cli/azure/get-started-with-azure-cli?view=azure-cli-latest
https://docs.microsoft.com/pt-br/azure/app-service/scripts/cli-deploy-github
https://docs.microsoft.com/pt-br/azure/app-service/scripts/cli-continuous-deployment-github