# Active Record Callbacks
http://guides.rubyonrails.org/active_record_callbacks.html
Callback = chunk of code that responds to an event.

In Ruby, when you save a model, a series of events are triggered. Ea of these events has a hook that allows you to intervene at that point.

THere are Callbacks around creating, updating, and destroying an object.

## Creating an object
In the process of saving, a bunch of callbacks happen. These are all places you can intervene.
- before_save
- after_save
- around_save - around when the save occurs; "wraps" the save and uses a yield method.

### After: Reporting uses a lot of afters. E.g., when you want to record what the user did. Doesn't matter when that recording happens in the process. Takes fewer resources & doesn't slow process. After is useful for "background jobs" - things the user doesn't need to see.

Save processes will occur with creation AND updating.

- before_create - create actions will occur ONLY when the object is created the first time.
- after_create - example: send confirmation email.

- before_validation - JNF says he uses this the most. Useful if you have transformations you want to perform on data. Yay!

- after_initialize
- after_touch - anytime something has been accessed.

# Skipping callbacks
There are methods you can use to skip callbacks as well.


# LIVECODE in records example
First wrote a spec

```
RSpec.describe Artist, type: :model do
context "normalizing and validating Artist.name" do

  it "transforms 'The Cure' into 'Cure, The'" do
    the_cure = Artist.new(name: "The Cure")
    the_cure.normalize_names_with_the!

    expect(the_cure.name).to eq 'Cure, The'
  end

  it "doesn't transform 'Thelonious Monk' into 'lonious Monk, The'" do
    thelonious_monk = Artist.new(name: "Thelonious Monk")
    thelonious_monk.normalize_names_with_the!

    expect(thelonious_monk.name).to eq 'Thelonious Monk'
  end

  it "transforms 'the cure' into 'The Cure'" do
    the_cure = Artist.new(name: "the cure")
    the_cure.normalize_casing_in_names!

    expect(the_cure.name).to eq 'The Cure'
  end

  it "treats 'the clash' and 'Clash, The' as the same artist" do
    Artist.create(name: "Clash, The")
    # the code should handle casing and names with 'the'
    the_clash = Artist.new(name: "the clash")

    expect(the_clash).to_not be_valid
    expect(the_clash.errors.keys).to include(:name)
  end
end

end
```

In the artist.rb model file, then added a callback:

```
# Callbacks --------------------
before_validation :normalize_casing_in_names!,
                  :normalize_names_with_the!

def normalize_names_with_the!
  # converts 'The Cure' to 'Cure, The'
  return unless self.name[0,4] == 'The '

  self.name = self.name.gsub(/^The\s+/, '') + ', The'
end

def normalize_casing_in_names! # added !s because method is mutative/destructive
  # converts 'the clash' to 'The Clash'
  self.name = self.name.titlecase # need self b/c referring to data attributes of the model...
end

```

Then removed the uniqueness validation bc no longer relevant
