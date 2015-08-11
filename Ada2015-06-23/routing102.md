# Routing 102

## Order

Rails routes are matched in the order they are specified. This can present a problem when a wildcard is used.

```ruby
get "/products/:id", to: "products#show"
get "/products/new", to: "products#new"
```

In this example, when rails receives a request to "products/new", the routes will be matched top to bottom. Both of the routes above match "/products/new"!
Rails doesn't know what `:id` means, it's not looking for an integer,
it's just looking for anything, including the word `new`. "products/new"
in this case will route to the `ProductController#show` action. For the
desired routes reorder the declarations

```ruby
get "/products/new", to: "products#new"
get "/products/:id", to: "products#show"
```

Put more SPECIFIC routes below more general ones. Organize by specificity.


## REST

Representational state transfer (REST) is an architectual style. This is a recommendation for the structure and style in which
a resource (ruby object) can be represented and managed through a web server.

The core of this idea can be described through routing. We'll look at an example if we have a `Market` object we want to represent through a web server.

|PATH        | METHOD| DESCRIPTION|
|:----------|:-----:|:-----------|
| /markets       | GET    | Retrieves a collection of market objects|
| /markets       | POST   | Creates a market object on the server. |
| /markets/:id   | GET    | Retrieves an  individual market object through an identifying attribute, givin in the url path.|
| /markets/:id   | PATCH    | Updates an individual market object through an identifying attribute, givin in the url path.|
| /markets/:id   | PUT    | Updates an individual market object through an identifying attribute, givin in the url path.|
| /markets/:id   | DELETE | Removes an individual market object through an identifying attribute, givin in the url path.|

You can see that many actions can be performed on a market object using only two paths.
The paths represent the scope of the objects to operate on and the HTTP method indicates what type of action should be performed.

Routes are defined as the interface for the application (API) _whether it is designed for human or computer interaction._ Endpoints & routes are the messages that go between the systems.

## Named Routes for REST
Since the standard RESTful resource only requires to paths, all five actions can be represented by just the two named routes.

The conventional route names for this RESTful resource would be `markets_path` and `market_path`. We use the plural version when referring to a _collection_ of Market objects (`index` action), and the singular version when refrring to an _instance_ or _specific_ Market (`show`, `edit`, etc).

Here's an example:

```erb
<% @markets.each do |market| %>
  <%= link_to "Market Details", market_path(market) %>
<% end %>
```

Called a _url helper_. They are context aware... Rails guide for routing has a great explanation of these (section 3.6). If you use helpers, you almost by default fall into RESTful patterns.


## Resources
Rails routes has a magic method

```ruby
Rails.application.routes.draw do
  resources :albums
end
```

This `resources :albums` line is adding all of the RESTful routes, it is equivelant to the following:


```ruby
Rails.application.routes.draw do
  get    "/albums"          , to: "albums#index",   as: :albums
  post   "/albums"          , to: "albums#create"
  get    "/albums/:id"      , to: "albums#show",    as: :album
  patch  "/albums/:id"      , to: "albums#update"
  put    "/albums/:id"      , to: "albums#update"
  delete "/albums/:id"      , to: "albums#destroy"
  get    "/albums/new"      , to: "albums#new",     as: :new_album
  get    "/albums/:id/edit" , to: "albums#edit",    as: :edit_album
end
```

Gives you all needed routes. Creates ALL whether you need them or not, and each one is an opportunity for a bug or attack. If you don't need the 8 routes, don't use this. Exposes you.

You can use both resources and custom routes. We'll look at an example.

We will use path helpers and resources because it will save us from having to change every instance of a path in every page. Now that you can use market_path, if you change the market_path route, it will change them all. This is how you make apps with routes that don't break.

`as: :name` is naming the route. Gives it an explicit name. Resources does some of this.

livecode example
