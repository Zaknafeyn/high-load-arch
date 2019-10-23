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

Server is available at address [http:\\localhost:8181](http:\localhost:8181)

To modify parameters of run, change parameters of docker-compose.yml
