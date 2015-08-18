# Deploying to Heroku for this project

OAuth developer strategy has NO security so can't be part of production/deployment.

config/environments
  - contains info for rails to use upon startup
  - config/environments/production has special things. Keeps rails from having to dynamically reload.

When you start rails, there's a Rails object where you can ask what environment its running

You can decide which ominauth strageties are initialized through environments
  - Rails.env.production? => will return t/f - started with production environment?

  omniauth initializer - we defined whcih strategies people can use to sign in.
  can use Rails.env.production? to tell it not to use developer in production

provider:developer unless Rails.env.production? in omniauth initializer

test by starting rails in production mode.
  `rails server -e production`

Bonus points: Conditionally create route so if someone tries to use developer strategy in production, something hilarious happens.
