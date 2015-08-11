# Active Record Relationships

Two classes can be associated to each other through an identifier field (what we call a _foreign _key_ in SQL). If we have two records like the following:

__markets__

|id|name|
|:----:|:-----:|
|1| Cap Hill Market|

__vendors__

|id|name|market_id|
|:----:|:-----:|:---:|
|1| Jules Produce|1|
|2| Verne's Flowers|1|

We would call this a _one-to-many association_. In rails, we would say that Market _has many_ Vendors, and each Vendor _belongs to_ a Market. The `market_id` column for a Vendor corresponds to the `id` of a Market record.

(Can also have one-to-one and many-to-many).

The Rails convention is that, when we have an association, we use lowercasename_id as the column name

## Defining an Association

ActiveRecord provides lovely methods to quickly create an association between two (or more!) models. We can use class methods within the models to make the definition.

```ruby
class Market < ActiveRecord::Base
  # plural because many vendors could be associated with this single market
  # would be singular if has_one
  has_many :vendors
end
```

```ruby
class Vendor < ActiveRecord::Base
  # singular because it belongs to only a single market
  # must define in both locations
  belongs_to :market
end
```

The `Vendor` class would need a `market_id` attribute to store the ID of the associated `Market`.

Must have 1) database definition and 2) the declaration in the class that formally defines the association.

__Note:__ ActiveRecord does _not_ require a formal `foreign_key` relationship defined at the database level in order to leverage these kind of associations, but it's usually a really good idea to create them in your migrations.

### These are specified in Models

## So what do these associations give us?

A whole slew of nice lookup methods that help us build queries for the associated model. Instead of my talking about them all day, let's head over to our sandbox and make a new app to play with...

Go to your sandbox and do this:

```bash
$ git clone git@github.com:jnf/records-example.git
$ cd records-example
$ gem install bundler
$ bundle
$ rake db:setup
```

### belongs_to :market
- `vendor.market`: get the Market associated with this Vendor. You _automatically_ now can call .market on vendor _without_ defining a market method anywhere. A lot like an attr_reader
- `vendor.market= market_object`: reassign this Vendor to a different Market
- `vendor.build_market(market_hash)`: instantiate a new Market object, associated with this vendor, using the provided hash
- `vendor.create_market(market_hash)`: just like `build_market`, but call `save` after instantiating the Market.

### has_many :vendors
- `market.vendors`: returns an array of all the Vendors associated with this market
- `market.vendors << vendor_object`: associate a Vendor with this market by adding it to the array of vendors
- `market.vendors= vendor_collection`: remove all prior Vendor associations and replace them with a new set of associations
- `market.vendors.find(id)`: find a specific Vendor, scoped to just those associated with this market (not very useful)
- `market.vendors.where(conditions_hash)`: get the Vendors associated with this market that also satisfy the conditions in the `where` hash (much more useful)
- `market.vendors.build(vendor_hash)`: instantiate a new Vendor with the provided attribute hash and associate it with this market
- `market.vendors.create(vendor_hash)`: instantiate a new Vendor with the provided attribute hash
and associate it with this market, then call `save` on the new vendor object.

## JNF's Records Example
See records-example in rails-practice.

Models contains 3 files, album, artist, and label that shows these associations.
Playing around in rails console:
- $ Artist.count (count artist records)

- $ artist = Artist.first
- $ ap artist.albums
    because "has_many," returns an array of active record objects. Now can do array things with it!
- $ ap artist.albums.map { |album| album.label }
  => new array of labels.

Say you want to know which label he has most records of:
- $ Label.all.max_by { |label| label.albums.count } => Fat Wreck Chords is most common label! Id 109.
- $ Label.find(109).albums.count => 27 records!

Play with it using example methods. If somethign goes wrong and you break the database, just do this!
- $ rake db:reset

Add a new record
Add a new label
  - add records to it
Try to create a better way to find the most frequent label. Better would require fewer queries.
 - $ x = Album.group(:label_id).count
   $ x.max_by { |key, value| value }


# Final Wave of Task List
rails generate model Person name:string
rake db:migrate
