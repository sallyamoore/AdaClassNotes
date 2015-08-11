# User Authentication
https://github.com/Ada-Developers-Academy/daily-curriculum/blob/master/topic_resources/user-authentication.md

Docs: https://github.com/codahale/bcrypt-ruby

It's extremely common in a web application to have users, and with users comes
the responsibility of authenticating the user, typically via a password matched
with their email or username.

The real challenge is keeping this information secure. The user is trusting you
with their password. You need to be responsible with that information.

**What is the absolute safest way to keep data secure?**

Bcrypt - the kind of encryption Rails uses
-------
Bcrypt is an algorithm created in 1999. The algorithm takes some type of user input and creates gibberish out of it. Rails helper uses it.

```ruby
require 'bcrypt'
BCrypt::Password.create("some user input")
# => "$2a$10$2.HBQHXv8JOOKPj.AZqnm.1vXe7BLsdEvz1ncBShGtkm4v8lMDKG2"
```

Here we used the `BCrypt` ruby gem to turn the input `some user input` into gibberish.
This process is called hashing, similar to encoding or encryption, except hashing cannot be undone.

This is the key to the solution of not storing the users data. If we use hashing
to create gibberish out of a users password and store that gibberish, then not only are we
not storing their password, but since hashing is not reversible, even we as website owners
have no way of determining what their password originally was.

To install, just `gem install bcrypt`. See encryption.rb file for example.

If the data we are storing is not reversible, how do we use it to authenticate the user?
When the user puts their password in again (sign in) we can recreate the same gibberish and compare the two.

```ruby
hashed_password = BCrypt::Password.create("some user input")
# => "$2a$10$2.HBQHXv8JOOKPj.AZqnm.1vXe7BLsdEvz1ncBShGtkm4v8lMDKG2"
hashed_password == "some user input"
# => true
```

class of these objects is BCrypt::Password. There's special password behavior accessible to this class that allows these to be equivalent.

# Check out auth-example in your rails-practice folder. This is our practice file. Both bcrypt and bootstrap-sass are included in the gemfile. Added better_errors and binding_of_caller.

- Created a User model
$ rails generate model User name:string email:string password_digest:string
- Added has_secure_password to User model
```
class User < ActiveRecord::Base
  has_secure_password
end
```
- ran migration
$ rake db:migrate

- checked it out in rails console

```
2.2.1 :010 > user = User.new(name: "Mabel Ru", email: "mabel@m.com")
 => #<User id: nil, name: "Mabel Ru", email: "mabel@m.com", password_digest: nil, created_at: nil, updated_at: nil>
2.2.1 :011 > user.password = "newd00les"
 => "newd00les"
2.2.1 :012 > user.password_confirmation = "newdooles"
 => "newdooles"
2.2.1 :013 > user.save
   (0.2ms)  begin transaction
   (0.1ms)  rollback transaction
 => false
2.2.1 :014 > user.errors
 => #<ActiveModel::Errors:0x007fd01eaa20f8 @base=#<User id: nil, name: "Mabel Ru", email: "mabel@m.com", password_digest: "$2a$10$nEC2T5DC8cQOWsl8cypoNeYVupJqLV0185SAZd/Nuay...", created_at: nil, updated_at: nil>, @messages={:password_confirmation=>["doesn't match Password"]}>
2.2.1 :015 > user.password = "newd00les"
 => "newd00les"
2.2.1 :016 > user.password_confirmation = "newd00les"
 => "newd00les"
2.2.1 :017 > user.save
   (0.1ms)  begin transaction
  SQL (0.7ms)  INSERT INTO "users" ("name", "email", "password_digest", "created_at", "updated_at") VALUES (?, ?, ?, ?, ?)  [["name", "Mabel Ru"], ["email", "mabel@m.com"], ["password_digest", "$2a$10$7BwBbQI32Dk5p.mNtpBpFOcJTCtsWfjnsuDW7ZscfwM2vNulgvtD."], ["created_at", "2015-07-13 21:48:59.744004"], ["updated_at", "2015-07-13 21:48:59.744004"]]
   (3.0ms)  commit transaction
 => true
2.2.1 :018 > User.find(1).password_digest
  User Load (0.2ms)  SELECT  "users".* FROM "users" WHERE "users"."id" = ? LIMIT 1  [["id", 1]]
 => "$2a$10$7BwBbQI32Dk5p.mNtpBpFOcJTCtsWfjnsuDW7ZscfwM2vNulgvtD."
 ```

has_secure_password
-------------------

`has_secure_password` is built into Rails to utilize bcrypt in the exact way described above.
simply adding the line `has_secure_password` to any active record model (typically a `User`).
The `has_secure_password` functionality depends on the model having a column in the DB called `password_digest`

```bash
rails g model User username:string email:string password_digest:string
```

```ruby
class User < ActiveRecord::Base
  has_secure_password
end
```

The `password_digest` is the column which rails will save the gibberish created by bcrypt.

The `has_secure_password` gives us the functionality to create the gibberish in a concise way.

```ruby
user = User.new
user.password = "mypassword"
user.password_confirmation = "mypassword"
```

We are given these two methods `password=` and `password_confirmation=`, these two fields
are **not** stored in the database, they are only "virtual" attributes (just like regular ruby object, before we saved stuff to the database)

`has_secure_password` adds validations to the user, so if the password and password_confirmation do not match
the user will be invalid, so it will not save, nor will it create the `password_digest`.

```ruby
user = User.new(username: "Ada")
user.password = "password"
user.password_confirmation = "wrong_password"
user.save # => false
user.errors
# => {password_confirmation: ["doesn't match Password"]}
user.password_confirmation = "password"
user.save
user.password_digest
# => "$2a$10$qbOPN4cu5j5OxXmZ.1hNOOdXqnafGsCA5ptTlscFQtMkg0xH./oxq"
```

Now that the user object has a saved `password_digest`, we can check if a new input
given matches the hash, Rails gives a method to do this in an easy way.

```ruby
user = User.find_by(username: "Ada")
user.authenticate("wrong_password") # => false
user.authenticate("password")
# => returns user object itself if true
```

# authenticate will return a user object if authenticated or will return false if not.

```
user = User.find_by(name: 'mabel')
user.authenticate('wrongpassword') # => false
user.authenticate('newd00les') # => user
```

# Consider: How to validate password requirements? E.g., require numbers, require special chars, etc.


# Created a SessionsController with new, create, and destroy actions.
- login page is managed by SessionsController
- Sessions has _no model_, so it has no db and you can't use instance vars in form. No persistence.
```
<h3>Sign In Here!</h3>

<%= form_for(:session, url: sessions_path) do |f| %>
  <%= f.label :email %>
  <%= f.text_field :email %>

  <%= f.label :password %>
  <%= f.password_field :password %>

  <%= f.submit "Sign In" %>
<% end %>

```


# flash vs flash.now
if you have a flash and a redirect it will disply twice; flash.now fixes this. If you have a render, you can just use flash.
