#!/usr/bin/env bash
function build-image {
  docker build -f Dockerfile .
}

function dc {
  files="-f Dockerfile"
  docker compose --verbose $files $@
}

function dc-up {
  upArgs="--remove-orphans"
  REBUILD="${REBUILD:-0}"

  if [ "$REBUILD" == "1" ]; then
    upArgs="$upArgs --build"
  fi

  echo "up $upArgs"
}

function c-list {
  docker container ls
}

function c-inspect {
  docker container inspect $@
}

function i-list {
  docker image ls
}

function i-inspect {
  docker image inspect $@
}

subcmd=$1
shift

case $subcmd in
  "up")
    dc $(dc-up) $@
    ;;
  "build")
    build-image
    ;;
  "down")
    dc down --remove-orphans
    ;;
  "destroy")
    dc down --remove-orphans --rmi local
    ;;
  "cl")
    c-list
    ;;
  "ci")
    c-inspect $@
    ;;
  "il")
    i-list
    ;;
  "ii")
    i-inspect $@
    ;;
esac
