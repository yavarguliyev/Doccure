#!/usr/bin/env bash

PROJECT_NAME="doccure"

docker network create doccure || true

docker-compose --project-name $PROJECT_NAME build --pull

docker-compose --project-name $PROJECT_NAME kill
docker-compose --project-name $PROJECT_NAME rm -f
docker-compose --project-name $PROJECT_NAME up -d
