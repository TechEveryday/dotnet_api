#!/usr/bin/env bash
docker-compose -f docker-compose.yml up --build -d --remove-orphans pgdb app
