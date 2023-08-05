# base image
FROM node:18
# set working directory
WORKDIR /app
# add `/app/node_modules/.bin` to $PATH
ENV PATH /app/node_modules/.bin:$PATH

COPY . ./

RUN apt-get update

RUN npm install

RUN npm install -g local-web-server

RUN npm install koa-morgan

RUN npm run build

WORKDIR /app/build

COPY ./log.js .

CMD ["ws", "--stack", "lws-static","lws-spa", "log.js", "-p", "8888", "--static.maxage", "86400", "-s", "index.html"]