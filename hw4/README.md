To build image, run this command from folder DbManipulator:  
```
docker build -t high-load-arch:db-reader --no-cache --rm .
```

To run entire set of containers, run:  
```
docker-compose up --build -d
```   

#### Environment variables:  
- **DB_PORT** - custom port to connect MariaDb server
- **DB_SERVER** - server address or dns host
- **DB_USER** - db user to connect to DB
- **DB_PASS** - password for specified user
- **DB_NAME** - name of database

#### Run siege:  
```
siege -c 255 --internet --file siege-urls.txt --content-type="application/json" -b 
```