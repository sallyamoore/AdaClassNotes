# RAILS!!!
see https://github.com/Ada-Developers-Academy/daily-curriculum/blob/master/topic_resources/rails.md

Rails is a DSL (domain-specific language).
Rails is a ruby-based MVC framework.

Rails boils down to: DRY and Convention over Configuration.
  -CoC means pick a way of doing something and DO IT THAT way

## Creating a new rails project
```
gem install rails --no-rdoc --no-ri  # rails is updated freq; good to re-install
rails new name_of_rails_project -T

```  
Must have bundler and rails gems. Check with `gem list`.

- Why `--no-rdoc` and `--no-ri` and `-T`?
  - saves time. Could include the rdoc and ri (which is a diff format of rdoc) or just access this through rails web info.
  - `-T` excludes the default test framework for rails. Takes up a lot of room and many folks don't use it. They use mini-test. You might decide to use it in the future.

`rails new` creates an entire package with a fully functioning web framework
Rails has a lot of opinions and conventions

Creates a structure similar to what we've been making up to now.

Great resource: guides.rubyonrails.org/getting_started.html
  - guide. also have screencasts available to walk you through. APIs library is very complete; can get the ruby docs for everything (api.rubyonrails.org). Getting started guide is good.

Migrations - ruby instructions about how to create database schema (instead of directly in sql.)

## Folder structure
- we will mostly be acting in the app/ folder. Contains the models, views, and controllers.
- log/ - we will learn a lot about how to read log files to understand errors
- Rakefile - used to enact indiv tasks that are about environment of app not app itself.
- test/ - for tests. Duh.


## `rails server`
does the rackup. Tells you what port to go to:

 -----
sallymoore:rails-blog~ 🐙   rails server
=> Booting WEBrick
=> Rails 4.2.2 application starting in development on http://localhost:3000
=> Run `rails server -h` for more startup options
=> Ctrl-C to shutdown server
[2015-06-16 11:30:05] INFO  WEBrick 1.3.1
[2015-06-16 11:30:05] INFO  ruby 2.2.1 (2015-02-26) [x86_64-darwin14]
[2015-06-16 11:30:05] INFO  WEBrick::HTTPServer#start: pid=93476 port=3000


Started GET "/" for ::1 at 2015-06-16 11:30:37 -0700
Processing by Rails::WelcomeController#index as HTML
  Rendered /Users/sallymoore/.rvm/gems/ruby-2.2.1/gems/railties-4.2.2/lib/rails/templates/rails/welcome/index.html.erb (1.5ms)
Completed 200 OK in 14ms (Views: 6.2ms | ActiveRecord: 0.0ms)
--------


rails generate -h: help file of what you can make.

routes.rb is located in config folder

Example in ruby-practice folder. Called it lunchtime.

Process
 1. made a route, called it root (special) (routes.rb; format controller#method)
 2. rails generate model ModelName
  this creates an instance and calls index (lunchtime_controller.rb)
 3. tell it which view you want it to render. It has an implicit renderer, but better to specify. In lunchtime_controller, render :index.
 4. Now will show up in your port. Yay! I'm a rails developer!


# Seed files
way to pre-populate with some data. Create seeds.rb file in db. 
rake db:seed
