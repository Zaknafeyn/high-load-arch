# Use the standard Nginx image from Docker Hub
FROM nginx
# The Dockerfile's author
MAINTAINER Valentine Radchuk
# Copy the configuration file from the current directory and paste 
# it inside the container to use it as Nginx's default config.
#COPY nginx.uk.conf /etc/nginx/nginx.conf

# Copy index data to nginx container
COPY http /usr/share/nginx/html
COPY http /usr/local/nginx/html
# Install purge module (which is unfortunately imcompartible with current version of Nginx)
# RUN apt-get update -y && apt-get install -y --no-install-recommends dialog apt-utils && apt-get install -y -q nginx-common && apt-get install -y libnginx-mod-http-cache-purge
#RUN apt-get update -y && apt-get install -yq nginx-common=1.14.2-2+deb10u1 libnginx-mod-http-cache-purge=1.14.2-2+deb10u1

EXPOSE 80

# Start Nginx when the container has provisioned.
CMD ["nginx", "-g", "daemon off;"]