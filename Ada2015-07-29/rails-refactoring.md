# Refactoring in Rails

**Consider the Object's Purpose**

A best practice in Ruby is for each logic regarding an object should be defined
within the object class. Let's talk about what each major piece of rails meant
to handle.

- **Views**: The views within rails are meant to handle the creation of HTML.
- **Controllers**: Controllers are responsible for directing the flow of HTTP
traffic
- **Models**: Models are meant to represent objects within the application

So let's define three questions you can ask to determine if the code within any
of these files is in the correct place.

- **Views**: Does the logic build HTML or determine which HTML is rendered?
- **Controller**: Does the logic determine what the HTTP response will be?
    - Is it an assignment for the view to use. If a variable isn't used in a
    view, it _should not_ be an instance variable.
- **Model**: Does the logic have to due with the idea of the object? Or
something within the object contextually?
  - e.g., set default values (rank = 0 in MediaRanker) (or you can do this at
    the database level)
  - if you change what's in the database, definitely use the model.

Rules
-----
Try to meet all of the following rules. Occasionally they can be broken, but
only if somebody else agrees.

1. Only call one method per line on any object in the view and controller (i.e.
  don't chain methods together). Really, just don't chain when you're changing
  the _type_ of object you're working with.
2. Don't use more than a single _method_ in a conditional (make local variables
  and compare those!)
3. Don't use operators (arithmitic, comparison, assignment) in views or
controllers.
  - Instead, do it as a self method in the model. Method call on the model
  object.
  - note: you can call a model from another model.
4. Don't do logic inside erb tags. If you have to set a var inside the view to
use it inside the view, DON'T. Set the var elsewhere.
  - Conditionals & iterators: Ok if it is logic that only changes what is viewed.
    - each on a var to display all of them
    - if logged in, display in this way


Do not attempt to code keeping all of these things in mind. Just refactor!

Example
-------

Using [this test repo](https://github.com/Ada-Developers-Academy/refactor-example), we will explore things to refactor. Initial red flags

1. Chaining [multiple methods](https://github.com/Ada-Developers-Academy/refactor-example/blob/master/app/views/orders/index.html.erb#L9) with a block arg

<% @orders.sort_by {|o| o.created_at }.reverse.each do |order| %>
  ...

Instead, @orders should come into the view _already sorted and already reversed_.

2. [Logic within erb tags](https://github.com/Ada-Developers-Academy/refactor-example/blob/master/app/views/orders/index.html.erb#L14).

<% total = 0 %>
<% order.order_items.each do |item| %>
  <% price = item.quantity * item.product.price %>
  <% total += price %>
<% end %>

Instead, put this in the Order model. Set total. Call order.total in the view.

3. [Arithmitic within a view](https://github.com/Ada-Developers-Academy/refactor-example/blob/master/app/views/orders/index.html.erb#L20)
<td><%= number_to_currency (total / 100) %></td>
Do the division elsewhere. total_in_currency method?

4. [Duplicated logic](https://github.com/Ada-Developers-Academy/refactor-example/blob/master/app/views/orders/show.html.erb#L8)
5. [More duplicated logic](https://github.com/Ada-Developers-Academy/refactor-example/blob/master/app/views/orders/show.html.erb#L16-L22)
