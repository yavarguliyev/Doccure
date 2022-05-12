#!/usr/bin/env bash

. ../common/bootstrap.sh

docker network create common || true

docker-compose --project-name $PROJECT_NAME up -d

docker volume prune -f
docker system prune -f