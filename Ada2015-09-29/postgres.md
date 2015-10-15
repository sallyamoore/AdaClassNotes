# Postgres!
Most iOS apps use sqlite. Sqlite is file-based.
Postgres is process-based. Communicate with it on the command line

# Why
Real float support
Date/time support
json queries.

SIDENOTE: `brew update` to get most recent brew stuff.

1. Installing
`brew install postgres`
(sidenote: `brew info postgres` -> shows info on your brew installation of pg)

You'll get:
```
To have launchd start postgresql at login:
    ln -sfv /usr/local/opt/postgresql/*.plist ~/Library/LaunchAgents
Then to load postgresql now:
    launchctl load ~/Library/LaunchAgents/homebrew.mxcl.postgresql.plist
Or, if you don't want/need launchctl, you can just run:
    postgres -D /usr/local/var/postgres
```
2. Starting up
3. Initial commands

Run first 2 suggested commands    

`psql` command line utility.
`psql -l` what databases pg knows about


`createdb sallymoore` creates db that you own
the `psql` will take you to the psql console.
to get out of console, `\q`


4. Converting a Rails project from Sqlite to Postgres
  - config/database.yml file - what you will modify in Rails project. NOTHING ELSE has to change for conversion (except gemfile).

in gemfile, replace sqlite gem with `gem: pg`, then bundle

in database.yml
```
default: &default
  adapter: postgresql
  username: records # wouldn't have this in production
  password: records # wouldn't have this in production
  host: localhost # will look like a url if you use AWS
  pool: 5 # how many connections this db cna support simultaneously. 5 is a good development number.

development:
  <<: *default
  database: records_development

test:
  <<: *default
  database: records_test

production
  <<: *default
  database: records_production
```

want to be able to use rake db commands. but username and password don't exist yet.
in command line:
```
createuser records
psql  # opens command line pg tool

# in tool:
ALTER USER records WITH PASSWORD 'records';
# OR
\password records

to grant permissions:
GRANT records createdb
ALTER USER records CREATEDB;

# now if you quit the psql tool, can rake db:create etc.
```

once created (rake db:create) and seeded, `psql records_development` if that's the name of the db

psql commands:
`\d` # describe - info on all tables
`\d tablenamehere` # info on 1 table

can use sql commands to select, count, etc

See Jeremy's example record collection app in github

# Dropping the db in postgres
- Must close servers and and open consoles.
- rake db:drop
- then will have to db:create, migrate, and seed
