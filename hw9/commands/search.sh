#!/bin/bash

if [ "$1" != "" ]; then
    echo "Positional parameter 0 contains $1"
else
    echo "Positional parameter 0 is empty"
fi

curl -X GET http://vradchuk.info:9200/movies/_search?pretty \
-H 'Content-Type: application/json; charset=utf-8' \
--data-binary @- << EOF
{
    "query": {
        "match_phrase_prefix": {
            "title": {
                "query": "$1"
            }
        }
    }
}
EOF