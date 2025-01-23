FROM node:18.20.5-slim

RUN mkdir /app
WORKDIR /app

COPY . /app

RUN npm install -g @angular/cli

RUN npm ci

EXPOSE 4200
EXPOSE 8080

CMD ["ng", "serve", "--host", "0.0.0.0", "--port", "8080", "--configuration", "production"]