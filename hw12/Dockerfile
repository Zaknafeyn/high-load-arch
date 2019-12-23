FROM karelbemelmans/nginx-geoip
MAINTAINER Valentine Radchuk "zaknafeyn@gmail.com"

# RUN apk add nano
COPY ${PWD}/nginx.conf /etc/nginx/nginx.conf

RUN rm /etc/nginx/conf.d/00-upstream.conf

EXPOSE 80
EXPOSE 443

# Start Nginx when the container has provisioned.
CMD ["nginx", "-g", "daemon off;"]