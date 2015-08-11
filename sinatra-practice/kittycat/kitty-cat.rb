require 'sinatra'

get '/' do          # get is a method that takes a parameter and a block. String is url to which the webserver should respond and the block is what it should respond with. / is a route.
  'Hiiiii!!! ^_^' # this is the return value
end

# you just made a webserver.
# started a process. Sinatra has taken the stage.

get '/best_names' do
  send_file 'static/html-livecode.html' # use for a static file
end

get "/bye" do
  '<h1>Byeeeeeee!! :(</h1>'
end

# doesn't work until you take sintra off stage and put him back on
# We'll automate that step this afternoon.

get '/bye' do
  "<h2>Please don't go. :(</h2>"
end

# it uses the first match it finds, so it doesn't do anything with this second /bye chunk. If you move it up, it will work.
