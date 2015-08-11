# Factory Girl
see http://www.rubydoc.info/gems/factory_girl/file/GETTING_STARTED.md
see rails-practice/records-example factory-girl branch

is weird DSL - domain specific language -
  DSL - tools written in a lang we understand, like Ruby but are not structured in a way that is identical to that lang.

[Factory Girl Rails](https://github.com/thoughtbot/factory_girl_rails) is a fixture replacment (not that we've learned what fixtures are), basically what it does is allows you to define ActiveRecord object presets, then use the FactoryGirl syntax to initialize or create those object at any time and with additional attribute definitions. Each preset is called a "factory".

Note that there's also a factory girl gem for ruby projects that don't use rails.

To install add the gem to the `development` and `test` environments to your `Gemfile`:

  `gem "factory_girl_rails"`
  `gem "factory_girl_rails", "~> 4.0"`

Add the following line within the `config` block in `spec_helper.rb`

  'config.include FactoryGirl::Syntax::Methods'

Next create a file to define your factories,

    touch spec/factories.rb

Within this file lets define our first factory for a Book model

  ```
  FactoryGirl.define do
    factory :book do
      name "House of Leaves"
      author "Mark Z. Danielewski"
      description "House of Leaves is the debut novel by the American author Mark Z. Danielewski, published by Pantheon Books. The novel quickly became a bestseller following its release on March 7, 2000. It was followed by a companion piece, The Whalestoe Letters"
    end
  end
  ```
factory is a method that takes a sym and a block. Sym is usually name of the active record object. In the block, you define the default attrs.  name, author, and description are _method calls_; value is a parameter. Factory girl creates attr accessors for your attributes using these method calls.

you then tell it make one with
  `@book = create(:book)`

if you need 10, you can say `10.times { create(:book) }`. They'd be 10 identical books.

can also new without create/save with
  `@unsaved_book = build(:book)`


Will use the defaults unless you specify otherwise. To make a version with unique attributes:
  `@custom_book = create(:book, name: "Some other book Loraine thinks is awesome.")`

Now within our specs we can use the FactoryGirl syntax to create this Book object, which will be an ActiveRecord Book object that we defined in `app/models/book.rb`. FactoryGirl is just storing the default values.

    require 'spec_helper'

    describe Book do

      describe "validations" do
        it "is valid" do
          expect(create(:book)).to be_valid
        end

        it "is invalid without a name" do
          expect(build(:book, name: nil)).to be_invalid
        end

      end
    end

The `create` and `build` methods are going to be the most common FactoryGirl methods, these methods accept the same argument, but create will attempt to save the record, while build will not. The first argument is the name of the factory, which is the symbol after `factory` in the `factories.rb`, the next argument is an optional hash, where you can pass in additional attributes or attributes to override on the creation of the object.


# When there's a foreign key assoc

# Autoload
rails has this functionality to look for certain files in locatons with certain names without you telling it to. Factory girl does this too.

Put you stuff in spec/factories.rb and it will find it!
