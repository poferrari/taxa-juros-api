# taxa-juros-api
API que retorna a taxa de juros

# comandos Docker

docker build -t api-taxa-juros-imagem -f Dockerfile .

docker images

docker run --name api-taxa-juros -d -p 5007:80 --rm api-taxa-juros-imagem

docker ps -a

docker stop api-taxa-juros

docker rm api-taxa-juros

docker rmi api-taxa-juros-imagem:latest

