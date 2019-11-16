## Test task for cource High Load Architecture

### Overview

The repository contains description of 2 docker images (server and attacker) orchestrated by docker-compose. **Server** is represented by Nginx with customized configuration, **Attacker** represents pyton script which generates unfinisshed requests to the server, doing Slowloris DoS attack.
The script for generating Slowloris is taken from [this](https://github.com/gkbrk/slowloris) repository.
Used containers:

- _nginx:alpine_ - for Nginx server
- _alpine:latest_ - for Attacker

Links, used to setup NGinx:

- https://blog.qualys.com/securitylabs/2011/11/02/how-to-protect-against-slow-http-attacks
- https://www.nginx.com/blog/mitigating-ddos-attacks-with-nginx-and-nginx-plus/
- https://hexadix.com/slowloris-dos-attack-mitigation-nginx-web-server/
- https://www.nginx.com/blog/rate-limiting-nginx/

### How to run

Clone repository  
`git clone https://github.com/Zaknafeyn/high-load-arch.git`  
then go to new folder  
`cd high-load-arch`  
build and up both containers  
`docker-compose build && docker-compose up`  
or in single command:

```
git clone https://github.com/Zaknafeyn/high-load-arch.git && cd high-load-arch && docker-compose build && docker-compose up
```

Server is available at address [http://localhost:8181](http://localhost:8181)

**Run separate container outside of docker-compose:**  
Attacker:

```
cd attacker
docker build -t prjctr:attacker .
docker run -it --rm --name attacker -e HOST=10.0.75.1 -e PORT=80 -e SOCKETS=1000 -e SLEEP_TIME=10 prjctr:attacker
```

Server:

```
cd server
docker build -t prjctr:server .
docker run --rm --name nginx-server -p 8181:80 -e HOST=server -e PORT=80 -e WORKER_CONNECTIONS=600 -e CONNECTION_TIMEOUT=5 -e ZONE_REQ_PER_SECOND=10 -e ZONE_REQ_PER_SECOND_BURST=20 prjctr:server
```

## How to configure

To modify run parameters, change parameters of docker-compose.yml and rebuild containers
If you want to run container without docker-compose, just add env variables to DOCKER RUN command e.g. docker run -e VAR1=val1 -e VAR2=val2

### Further improvements

To increase protection against Slowloris following technics could be additionally applied:

- limit number of requests allowed from single address per time frame
- after some experiments define the best connection timings that allows to return any content from the site and apply them
- drop requests with HTTP verbs that not supported by the web site
