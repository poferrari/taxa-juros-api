# taxa-juros-api
API que retorna a taxa de juros

# comandos Docker

docker build -t api-taxa-juros-imagem -f Dockerfile .

docker run --name api-taxa-juros -d -p 5007:80 --rm api-taxa-juros-imagem

