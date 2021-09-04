#!/usr/bin/env bash

PROJECT_NAME='doccure'

docker-compose --project-name $PROJECT_NAME down

docker system prune -f
docker rmi -f $(docker images -a -q)
docker volume prune -f
docker image prune -f
