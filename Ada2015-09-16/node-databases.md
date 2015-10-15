See database.js in javascript-practice/test-app
Also see jnf version: https://github.com/jnf/node-example-app

# Creating a reuseable module in Node
nodemon - keeps you from having to restart server:
$ nodemon bin/www

installed sqlite:
$ npm install sqlite3 --save

created js file:
$ touch database.js

## in database.js
added use strict, then required sqlite:
`var sqlite3 = require('sqlite').verbose(); `
verbose puts sqlite in verbose mode, so you get better stack tracks and server output. But slightly more memory intensive, FYI.

export file back into node ecosystem:
put below at end of file
`module.exports = Database;`

This is a typical set up for a js file use in node: add use strict, require dependencies, export.

Create class:
function Database() {   
}

To assign attrs to the prototype: 2 options:
1.
Database.prototype = {
  test: function() { console.log('yay! it works!');
}

OR
2. Database.prototype.test = function() { console.log('also yay'); }

But _don't mix and match_ or you can wind up wiping out your changes.

## in controller:

Require file in controller:
`var Database = require('../database');`

Then add function to indexController:
```
database_test: function(req, res) {
  var db = new Database(); // instantiates Database object
  db.test(); // can now execute db.test, the function assigned to the prototype

  return res.status(200).send("plain text message"); // must have a response.
},
```

## Add route:
Add a route in routes/index.js:
router.get('/database_test', function(req, res, next) {
  return index_exports.indexController.database_test(req, res);
});


## testing! with mocha
### install AND add to project:
`$ npm install -g mocha --save`
`install -g` - installs globally to get mocha in path.
`--save` - adds to this project

add test directory and file.
$ mkdir test
$ touch test/database_tests.js

to run tests:
$ mocha

### in test file
`var assert = require("assert"); `
// requires the assertion library called 'assert'
// there's another called 'should' that is more like rspec.

var Database = require("../database");
// requires our database controller file

```javascript
describe("Database", function () {
  // var db = new Database(); // downside of putting this here: if a test mutates it, it will stay mutated.

  // better pattern:
  var db;

  beforeEach(function() {
    db = new Database();
  });

  it("can be instantiated", function() {
    assert.equal(db instanceof Database, true)
  });

  it("has a 'test' property that is a function", function() {
    assert.equal(typeof db.test, "function");
  });

});
```

## Add actual Database stuff!
in database.js:
### tell sqlite where db is (sqlite is file-based, so must find file.)

```
function Database(path) {  
  this.path = path; // makes path an instance var
}
```

### make db query
```javascript
Database.prototype = {
  test: function() { console.log('yay! it works!'); }, // creates function 'test' that belongs to this class.
  query: function() {
    var db = new sqlite3.Database(this.path);

    db.serialize(function() {  // can also run parallelized - happening at once instead of serially
      // use .run to execute immediately
      var users = db.run("SELECT * FROM users;");

      // takes statement you want to execute multiple times with diff parameters
      var prepared = db.prepare("INSERT INTO users VALUES (?);");
      // then you run it:
      prepared.run("Jeremy!"); // would pass in more params if you have mult ?s
      prepared.run("Tacocat");

      // for each result row, execute function. That data will be in row object
      db.each("SELECT * FROM users;", function(err, row) {
        // row is a result from sql, e.g., { name: "Jeremy!", favorite_meal: "Brunch" }        
      });
    });
    db.close(); // must always close connection to db.
  }
}
```
Typical pattern for query shown above:
query is a function that 1) connects to db, 2) executes query, 3) closes db.


## Note: node almost always uses a callback pattern. When it does, the function params are (err, res), the error and the response.

## Create schema (using our project seed files)
make a schema file:
$ mkdir utils  
$ touch utils/schema.js

see schema.js

run task:
$ node utils/schema.js

use sqlite command line tool to check it out:
$ sqlite3 db/development.db
Adding a record from command line tool:
$ insert into movies(title, inventory) values("Jaws", 10);
$ .headers on
$ .mode tab

to drop and remake db, run
  $ node utils/schema.js
again.

## Seeding table
make utils/seeds.js file
get the .json file.
node will parse json files for you if you require them!

run it with
$ node utils/seed.js

## can then make these easily executable tasks!
Broken right now tho.... boo.
in package.json:
"scripts": {
  "start": "node ./bin/www",
  "reset": "node ./utils/schema.js",
  "seed": "node ./utils/seed.js"
},


## More about node project
Scripts in package.json (like rake in RoR):
```javascript
"scripts": {
  "start": "nodemon ./bin/www",
  "test": "clear; DB=test mocha --recursive", // sets test env, uses test db
        // runs nested folders (recursive)
  "db:schema": "node ./utils/schema" // call with npm run schema
  "db:seed": "node ./utils/seed"
  "db:setup": "npm run db:schema; npm run db:seed"
},
```
package.json is your own weird little place to set commands.


MODEL
```javascript
"use strict";

function Movie() {
  this.table_name = "movies"    // all was shared except table name!
}

Movie.prototype = require('../database');  // logic shared bt models is in
                                           // database

module.exports = Movie
```


database.js
```javascript
module.exports {
  find_by: function(column, value, callback) {
    var db = new sqlite3.Database('db/' + db_env + '.db');
    var statement = "SELECT * FROM " this.table_name + " WHERE " + column + " = ?"

    db.all(statement, value, function(err, res) { // waits to close db until complete - callback is sent only when complete.
      if (callback) callback(err, res);
      db.close();
    }
  }

  create: function(data, callback) {
    var db = new sqlite3.Database('db/' + db_env + '.db');
    var keys = Object.keys(data);
    var key_pairs = [];
    var values = [];

    for (var i = 0; i < keys.length; i++) {
      values.push(data[keys[i]]);
      key_pairs.push('?');
    }

    var statement = "INSERT INTO " + this.table_name + ...

    db.run...
  }

  save: function(data, callback) {
    if (data.id) {
      // save
    } else {
      callback({err: "Missing Key", message: "Can't save w/o id; use 'create'..."}) // not typical way to return error...
    }
  }

  // etc.
}
```

In testing, added ```javascript
  beforeEach(function(done) {  // this is a mocha thing. Event listener to
                              // wait for this to be done before moving on.
                              // way to make execution synchronous bc that's // needed for testing.
    movie = new Movie();

    db_cleaner = new sqlite3.Database('db/test.db');
    db_cleaner.serialize(function() {
      db.cleaner.exec(
        // deletes all movies.
        // inserts two fresh movies.
        // COMMIT;
        , function()...
        )
      })
  })
  ```
NOTE: npm is to node what gems are to ruby!!! Execept that npm is a company.
