#!/usr/bin/env bash
docker-compose -f docker-compose.yml up --build --remove-orphans pgdb app
