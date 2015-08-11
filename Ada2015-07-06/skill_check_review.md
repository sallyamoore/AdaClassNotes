# redirect_to versus render:
redirect_to is a new request. render just shows the view.
good idea to redirect after database updates; otherwise you might re-submit data.

# index view for 3.4
<% @photos.each do |photo| %>
  <%= image_tag(photo.url, alt: photo.description) %>
  <caption><%= photo.description %></caption>
<% end %>

# Another couple of ways to do 4.2
Post.find(17).comments.best(5)
Comment.where(post_id: 17).best(5)

# More for 4.5
post.comments << comment
comment.post_id = post.id
