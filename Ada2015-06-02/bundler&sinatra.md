# Bundler
A gem whose job it is to manage other gems. Organizational tool. Tracks which versions of which gems were used in which projects. Defines gems necessary for a project _to other people_.



# Gemsets
are for you in your development process. Way to isolate the env of those projects so you know the combo of software (various versions) plays well together.

.ruby-gemset - how you define a gemset. Needs a companion .ruby-version
each contains a single line. gemset says name of gemset. version says ruby version. Below, we make a directory, name a gemset file (with the same name as directory, a simple convention but not req'd) containing name of gemset (ditto), & name a version file with the ruby version.

sallymoore:samo-ada~ 🐙   mkdir kittycat
sallymoore:samo-ada~ 🐙   echo "kittycat" > kittycat/.ruby-gemset
sallymoore:samo-ada~ 🐙   echo "2.2.2" > kittycat/.ruby-version
sallymoore:samo-ada~ 🐙   ls -la kittycat/
total 16
drwxr-xr-x   4 sallymoore  staff   136 Jun  2 10:16 .
drwxr-xr-x  31 sallymoore  staff  1054 Jun  2 10:15 ..
-rw-r--r--   1 sallymoore  staff     9 Jun  2 10:15 .ruby-gemset
-rw-r--r--   1 sallymoore  staff     6 Jun  2 10:16 .ruby-version

Then, when I cd in, it looks for these.

sallymoore:samo-ada~ 🐙   cd kittycat/
ruby-2.2.2 - #gemset created /Users/sallymoore/.rvm/gems/ruby-2.2.2@kittycat
ruby-2.2.2 - #generating kittycat wrappers..........

then `gem list`, and the list is *much* shorter.

we then `gem install sinatra` and it's installed only in the local dir. If I go up a level and `gem list`, the list will be long and will *not* include sinatra.
`rvm gemset list` will show your list of gemsets (not of gems)

sallymoore:kittycat~ 🐙   rvm gemset list

gemsets for ruby-2.2.2 (found in /Users/sallymoore/.rvm/gems/ruby-2.2.2)
   (default)
   bundle-me
   global
=> kittycat

For each gemset, you then must `gem install bundler`.

then touch Gemfile to create your gemfile and add source and relevant gems. See kittycat > Gemfile for example

Next, `bundle` in terminal

A new file is created called Gemfile.lock. You never mess with this file. It is just bundler tracking stuff.

At first, the Gemfile does not contain versions of the gems, which means download the most recent version of these gems and install them. BUT the most recent version in the future might not work with your stuff. So you gem lock it by then adding the versions to the file. see example Gemfile.

  - When doing this, you can use '>=1.0' if version is 1.0 to require a version greater than 1.0. `'~>2.2.4'` means anything in the 2.2 family but less than 2.3.
  - JNF usually locks with the ~>
  - if you need it to be one particular version (rare but happens), use =2.2.4

All this will be in the project root. All of this goes in your repo.

For sinatra project, this is all already there, so we just need to `bundle`

# Get combo through gemsets, share through bundler.

rvm gemset list - all gemsets


# Sinatra
- DSL - domain specific language - special ruby syntax.
see sinatrarb.com/intro.html

sallymoore:kittycat~ 🐙   ruby kitty-cat.rb
== Sinatra (v1.4.6) has taken the stage on 4567 for development with backup from Thin
Thin web server (v1.6.3 codename Protein Powder)
Maximum connections set to 1024
Listening on localhost:4567, CTRL+C to stop

- localhost is a port number. 80 is default internet location. port 443 is for more secure stuff. port 22 is ssh.
http://localhost:4567
- local web server created through thin.

(Chrome Shortcut to webdeveloper tool panel is cmd+option+I)

Rails and Sinatra do similar things. Middleware. Connect backend and frontend together.

Next you'd move it to a remote server so it isn't isolated to just your computer.



# Heroku
you push to Heroku like you push to git, except that you do it less frequently -- when you're ready to publish something to the interwebs

lots of plugins and add ons... you'd pay for some of these.

where to buy domains - see slack

Heroku has a nice info page on how to connect your page with  your purchased domain name.

`git push heroku sam/master:master`  

# if sinatra gets stuck running in terminal
TRY `killall rackup`
