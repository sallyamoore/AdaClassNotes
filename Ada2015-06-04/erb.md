# erb
a preprocessor - works with ruby & html. Html is limited because it is static. Preprocessor allows us to use logic, etc, and still wind up with something the browser understands.

views folder houses all dynamic templates. In web dev lingo, a view is a reuseable template; in our case a combo of html and dynamically eval'ed ruby

<%= Time.now %> # goes in html file. <% tells erb to evaluate the enclosed expression with ruby. = indicates result should be outputed to browser. Before you give this to the browser, eval this statement and output it to the browser.

We now have a way to do logic! Yay!

sinatra supports ~30 preprocessors. Whoa! We'll just use erb.


# erb w/ sinatra
ROUTES are instructions to sinatra about what to do (these are the get commands in the .rb file)

```
get "/example/:name" do
  # the symbol (:name) tells sinatra to assign whatever the user gives in
  # that spot to the key :name in the params hash.
  # assign value inputted to key :name in params hash.
  # params hash will be available within the scope of this block. Can access
  # in your erb view, but it's dangerous. Others can inject into your template. So assign it to an instance variable.
  # you are in class my_site.
  # params is a method generate on initialization of the class
  # because we've only made sinatra aware of the /example/name path, it
  # shows up only when we go to example/put-name-here.
  # this makes code reuseable... can call methods and do add'l logic...
  @name = params[:name]
  erb :example
end

```

# the layout
layout.erb - html frame shortcut
sinatra will look to see if there's a layout.erb file. Will first parse the layout.

layout will set core features that are true across ALL of your pages so you don't have to, for example, put <html> on every page.

yield is a key word that pauses, goes to the page-specific content, then comes back to the layout. Yields to our view. Put your nav, head, etc., etc here

erb uses layout AUTOMATICALLY. Don't need to call it.

will only get called when you're using a view. Need a view folder

# jnf created module Kitties
kittes.rb contains a constant with all kitty names.

class Kitty initializes with @name = name and attr_accessor for name.
methods for:
  link_path - just sets path
  image_path - just sets path
  kitty_image_tag - just creates tag
  alt_tag - just creates alt_tag
  self.all_the_cats (so he can reference with @kitties = Kitties::Kitty.all_the_cats)


This is in jnf/layout branch for reference
