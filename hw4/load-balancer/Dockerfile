# Use the standard Nginx image from Docker Hub
FROM nginx
# The Dockerfile's author
LABEL Valentine Radchuk
# Copy the configuration file from the current directory and paste 
# it inside the container to use it as Nginx's default config.
COPY nginx.conf /etc/nginx/nginx.conf
# Copy static data to nginx container
COPY nginx-data /var/www/static/
# Install purge module (which is unfortunately imcompartible with current version of Nginx)
# RUN apt-get update -y && apt-get install -y --no-install-recommends dialog apt-utils && apt-get install -y -q nginx-common && apt-get install -y libnginx-mod-http-cache-purge
#RUN apt-get update -y && apt-get install -yq nginx-common=1.14.2-2+deb10u1 libnginx-mod-http-cache-purge=1.14.2-2+deb10u1

# Port 8080 of the container will be exposed and then mapped to port
# 8080 of our host machine via Compose. This way we'll be able to 
# access the server via localhost:8080 on our host.
EXPOSE 8080

# Start Nginx when the container has provisioned.
CMD ["nginx", "-g", "daemon off;"]