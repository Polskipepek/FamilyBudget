#!/bin/sh
# wait-for-postgres.sh

set -e

host="$1"
shift
cmd="$@"

until psql -h "$host" -U "$DB_USER" -p "$DB_PORT" -c '\q'; do
  >&2 echo "PostgreSQL is unavailable - sleeping"
  sleep 1
done

>&2 echo "PostgreSQL is up - executing command"
exec $cmd
