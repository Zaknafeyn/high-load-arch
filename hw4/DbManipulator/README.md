To build image, run this command:
docker build -t high-load-arch:db-reader --no-cache --rm .

Environment variables:
DB_PORT - custom port to connect MariaDb server
DB_SERVER - server address or dns host
DB_USER - db user to connect to DB
DB_PASS - password for specified user
DB_NAME - name of database