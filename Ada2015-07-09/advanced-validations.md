# Custom Validations:
## Creating validations when the basic validations are not sufficient

http://guides.rubyonrails.org/active_record_validations.html#performing-custom-validations
see esp section 6.2


validate :method_name

def method_name
  if this_thing
    errors.add(:name_variant, "Blah")
  end
end

```
class Artist < ActiveRecord::Base
  # Associations ------------------
  has_many :albums
  has_many :labels, -> { uniq }, through: :albums

  # Validations ------------------
  validates :name, presence: true, uniqueness: true
  validate :uniqueness_of_names_containing_the

  def uniqueness_of_names_containing_the
    return unless name[0,4] == 'The '

    # now only dealing with names that start with the
    # check if already artist with preferred variant in db
    modified_name = name.gsub(/^The\s+/, '') + ', The'

    # raise an error if the modified_name is in the db
    if Artist.where(name: modified_name).count > 0
      errors.add(:name_variant, "We've already got #{modified_name}!")
    end
  end

end
```
## validates vs validate
rails uses validates when using built in validators and validate when using custom validators.

## section 6.1
Can create a new validator class. Useful if you have a lot or validations or if you have lots of dependent validations.
