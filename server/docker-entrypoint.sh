#!/bin/sh
export ESC="$"

#substitute placeholders with env variables in nginx default.conf and nginx.conf files
envsubst < default.tmpl.conf > /etc/nginx/conf.d/default.conf
envsubst < nginx.tmpl.conf > /etc/nginx/nginx.conf

# Start nginx
nginx -g 'daemon off;'