#!/usr/bin/env bash

docker kill $(docker ps -q)
docker rm -f $(docker ps -a -q)
docker rmi $(docker images -q)
docker volume rm $(docker volume ls -q)
docker system prune -f