## Test task for cource High Load Architecture

### Overview
The repository contains description of 2 docker images (server and attacker) orchestrated by docker-compose. **Server** is represented by Nginx with customized configuration, **Attacker** represents pyton script which generates unfinisshed requests to the server, doing Slowloris DoS attack.
The script for generating Slowloris is taken from [this](https://github.com/gkbrk/slowloris) repository.

### How to run
Clone repository 
```git clone <repo>```
then go to new folder
```cd <repo>```
build and up both containers
```docker-compose build && docker-compose up```
Server is available at address [http:\\localhost:8181](http:\\localhost:8181)

To modify parameters of run, change parameters of docker-compose.yml