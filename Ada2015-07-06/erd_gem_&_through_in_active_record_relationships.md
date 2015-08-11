# Rails ERD gem - can autocreate an ERD for a rails project.
- add 'rails-erd' to Gemfile
- $ bundle install
- $ brew install graphviz
- $ erd # creates pdf file with erd.

# Active Record Relationships using 'through'
see record example in rails-practice

label has many artists, but you need to go through the album to connect them.

```
class Label < ActiveRecord::Base
  has_many :albums
  has_many :artists, -> { uniq }, through: :albums
end

```

in rails console, to view artist through label, must go through album...
$ label.albums.collect(&:artist).count
(the & is creating a proc. Equivalent to the following:)
  $ label.albums.collect { |album| album.artist }

... _unless_ you create this through relationship. THen, you can:
$ label.artists.count
to get the count.

then, by adding `{ uniq }`, the same syntax would get count of the number of unique artists. Otherwise, you'd get the count of all artists, not accounting for duplicates.

He also added a scope to album.rb:
`  scope :on, -> (label) { where(label: label) } `
Allows you to call `album.on(Label Name)` to get all the albums on that label.
Same as doing
```
label = "Your Choice Records"
Album.where(label: label)
```

so, this is a non-unique count:
```
2.2.2 :010 > label.albums.collect(&:artist).count
 => 27

```

and this is a unique count:
```
2.2.2 :011 > label.albums.collect(&:artist).uniq.count
 => 20

```

similarly, adding this to artist.rb
```
has_many :labels, -> { uniq }, through: :albums
```
... allows you to do something like:

```
artist = Artist.find(85)
artist.labels
```
