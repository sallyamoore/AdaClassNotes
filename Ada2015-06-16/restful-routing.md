# RESTful Routing
see https://github.com/Ada-Developers-Academy/daily-curriculum/blob/master/topic_resources/resources/restful-routes.md

REST = REpresentational State Transfer. Pattern to help organize the things app knows how to do, creates structure of how a user interacts with the app. Modern approach to web architecture. Identifies and understands what you're asking it to do using URL and HTTP verb. Normalized, predicatable pattern of web requests.

We're doing this in Sinatra. In Rails, there's a separate file of "things app knows how to do." Takes some getting used to.


## Example pseudocode
if you have a `user` resource at users/:id

### REQUEST       VERB      RESPONSE
/users/           GET       -> object: 'users', method: 'index'
/users/1          GET       -> object: 'users', method: 'show'
/users/new        GET       -> object: 'users', method: 'new'
/users/           POST      -> object: 'users', method: 'create'
/users/1/edit     GET       -> object: 'users', method: 'edit'
/users/1          PATCH     -> object: 'users', method: 'update'
/users/1          DELETE    -> object: 'users', method: 'destroy'

combo of verb and url tells web server (sinatra, in this example) all it needs to know to formulate action and response.This is a convention in the ruby community.

Patch and put are largely synonymous; patch is currently in favor.  

This is pseudocode; we'll look at what rails does to implement this.

Action attribute of form - string to request a url. (Empty string requests the same url)
