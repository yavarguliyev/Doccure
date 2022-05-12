#!/usr/bin/env bash

. ../common/bootstrap.sh

docker-compose --project-name $PROJECT_NAME down

docker rmi $(docker images -q)
docker volume prune -f
docker system prune -f