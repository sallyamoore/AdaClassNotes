# 0 to API in node.js
Speaker: Jon Madison - works at Nordstrom as full-stack dev in shop by text. Used to own beats.com domain... :)

## Key takeaways:
- API first
- design APIs using tests
- look into node!

## Why API first?
Dependencies weaken your code.

Single page app (SPA):
  Web page -> API -> data store, other APIs, whatever else
Mobile app can also point to an API, as could an internet of things object

Power of APIs is in reuse and decoupling. Reduces dependencies.

## Why node.js
- minimal
- powerful
- additive, not subtractive.
- it's javascript, with all its quirkiness

Prefers node to Ruby on Rails. Why?
- Rails scaffolding gives you a lot of stuff; I don't need it all, but don't know what I can remove and not break stuff.
- Additive - you add the things you need (rather than removing what you don't). Helps with cognitive load.

## Start with an idea or job to be done
- data you want available to a mobile or web app?
- gather data from multiple clients (signing up clients? weather sensor?)
- mashing up multiple APIs

## Today's idea: Flowers!
plants.usda.gov - Natural Resources Conservation Service - Plant core data. No API, but can export as .csv.

_express_ - framework for Node. Fast, unopinionated, minimal framework for Node.js.
  - main driver -> bootstrapping your express (config server, routing, module)
                            ||            ||
                            \/            \/
        any amount of helper code        route -> controller -> db

_Mocha_ - testing framework - unit testing, command line tool.
_Supertest_ - testing framework (unit tests test modules; this tests larger order functionality/behavior). Makes sure the endpoint returns what it should. Pulls in app and makes calls to your api.
_Postgres_ - for DB (also likes MongoDB)

## DEMO
see https://github.com/jonmadison/zero-to-api-ft-example
What we did:
`sudo npm install -g nodemon`         // I had to add --python=python2.7
`sudo npm install -g express-generator`        
`express ft --git `   
`cd ft`
`rm -rf views`    
`rm -rf public/`

open editor

remove "jade": "~1.11.0” and "serve-favicon": "~2.3.0” from package.json file (don’t forget to remove the commas)

If you get access errors: Remove the `_locks` files.
`rm -rf '/Users/sallymoore/.npm/_locks'`

npm install

testing:
`npm install -g mocha`
`mocha`

## Representational State Transfer (REST) review - Architectural style
https://www.ics.uci.edu/~fielding/pubs/dissertation/rest_arch_style.htm
- resources are nouns (plant names, e.g., daisy), operations are HTTP verbs
- discoverable endpoints - Tree of API and endpoints should make sense!
- be consistent

## Demo endpoints:
- GET /plants -> all plants
- GET /plants/:id -> specific plant
- GET /plants?name=<term> -> plant where name matches term
- POST /plants  -> add a new plant (with json package of info on plant)
- PATCH /plants/:id -> Update a specific plant

## Example basic test
describe('basics',function(){
	it('should return 404 on /',function(done) {
		request(app)
		.get('/')
		.set('Accept','application/json')
		.expect(404,done);
	})
