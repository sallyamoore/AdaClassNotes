# Rails routes

```
Some::Application.routes.draw do
  root 'welcome#index'
  get "/users" => "users#index" # http verb (get) plus route
                                # (go from here to there)
  # all other routes go here
end
```
The first route it matches (exactly) is the one it takes.

So get `'products/:id' => 'catalog#view'` would match `/products/1` but not `/products`.

Note that methods in rails are referred to as "actions"

In config/routes.rb

To see your routes:
`$ rake routes`
