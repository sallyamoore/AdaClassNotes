# Node

Express is to node what sinatra is to ruby.

## Dealing with the access errors:
$ npm config get prefix
=> /usr/local
// We changed ownership of /usr/local to whoami
$ sudo chown -R `whoami` /usr/local


(TO uninstall what we installed globally:
npm uninstall -g express)

//Create directory
$ express test-app

result is app containing app.js, package.json. These files coordinate the behavior of the app.

// cd into directory
$ cd test-app

$ npm install
// equivalent to bundling

$ npm start
// starts the server. Now can go to localhost:3000
``
This uses MVC pattern.

route file (index.js):
// GET home page.
// router takes 2 params: path to match, what to do with match.
// req = request object - all info about request, res = response object - info
// about response , next = what to do next -- callback or promise
router.get('/', function(req, res, next) {  
  res.render('index', { title: 'Express' });
});

// We're going to change this to use a CONTROLLER to isolate functionality.
$ mkdir controllers


see javascript-practice/test-app

Will require db file and then talk to db directly using sql.
Don't write sql queries in controller files. isolate them!
