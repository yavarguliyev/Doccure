#!/usr/bin/env bash

PROJECT_NAME='doccure'

docker network create common || true

docker-compose --project-name $PROJECT_NAME up -d
