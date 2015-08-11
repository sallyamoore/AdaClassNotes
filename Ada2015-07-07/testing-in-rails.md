# Testing in rails
https://github.com/rspec/rspec-rails

This link includes installation instructions and examples.

Rspec rails is a gem. Provides some special matchers for rails. We probably won't test views in rspec; we'll use another tool. It's great at testing models and controllers, though.

Example:
```
require "rails_helper"

RSpec.describe User, :type => :model do
  it "orders by last name" do
    lindeman = User.create!(first_name: "Andy", last_name: "Lindeman")
    chelimsky = User.create!(first_name: "David", last_name: "Chelimsky")

    expect(User.ordered_by_last_name).to eq([chelimsky, lindeman])
  end
end

```
User is the model name, and rspec is told this with :type => :model.

Later, we will use FactoryGirl (another gem) to make records to test, but for now we'll use syntax like above.

Data goes into a TEST database, not the actual db. Test env has its own db, etc. Typically, database is also rolled back after each test. Almost never persistent data in the test db (pros: saves time, focuses tests; cons: data interactions can have unusual results. There are workarounds to persist data).

Testing suggestions from JNF:
## Models
- Have a test for every scope you write. Or 2. JNF suggests 2 tests, a positive one (expect it to have xxx) and a negative one (expect it not to have xxx)
- Test validations
- Write positive and negative tests for any methods

These are _unit tests_, i.e., the tests are in isolation. Checks a single assumption on a unit of work. JNF just writes unit tests for his models.

_cucumber scenarios_: Cucumber is a gem. Adds custom and more explicit matchers to Rspec. We have been using these matchers. Cucumber is for behavior testing; we'll come back to this later.

## Controllers example
```
require "rails_helper"

RSpec.describe PostsController, :type => :controller do
  describe "GET #index" do
    it "responds successfully with an HTTP 200 status code" do
      get :index
      expect(response).to be_success
      expect(response).to have_http_status(200)
    end

    it "renders the index template" do
      get :index
      expect(response).to render_template("index")
    end

    it "loads all of the posts into @posts" do
      post1, post2 = Post.create!, Post.create!
      get :index

      expect(assigns(:posts)).to match_array([post1, post2])
    end
  end
end

```
_response_ is created by rspec in response to the request. It is the result of the "get" call. Creates a response object.

The first one here, testing success, is likely extraneous. The "have_http_status" part is useful, esp in larger tests.

.create! will always through an error, whereas create will sometimes through warnings rather than errors. Want it to fail if anything changes.

These are _integration tests_, they are about interactions. Create object in db then execute request from server, then have expectations about the response. Much more complicated.

Controller tests _do not actually render the views_. View-level testing will come later.

`assigns` object. If you create an instance var through controller, it is accessed through this object.

Controller tests test whether your app is actually doing what you want.


http://tutorials.jumpstartlab.com/topics/internal_testing/rspec_practices.html

Great tutorial. Read as hw.

`before :each` -  does what is specified before each test. JNF prefers `let`.

`before :all` - does what is specified once and it persists between all tests.

#LIVECODE - tests for the records example.
see handwritten notes

In spec file:
```
require 'rails_helper'

RSpec.describe Album, type: :model do
  describe "model validations" do
    it "requires a title, all the time" do
      album = Album.new

      expect(album).to_not be_valid
      expect(album.errors.keys).to include(:title)
    end

    context "validating released_year" do
      it "requires a year, all the time" do
        album = Album.new

        expect(album).to_not be_valid
        expect(album.errors.keys).to include(:released_year)

      end

      it "requires released_year to be a number" do
        album = Album.new(released_year: "lololol")

        expect(album).to_not be_valid
        expect(album.errors.keys).to include(:released_year)
      end

      it "requires released_year to be a integer" do

        album = Album.new(released_year: 3.14)

        expect(album).to_not be_valid
        expect(album.errors.keys).to include(:released_year)
      end
    end
  end
end


```

```
require 'rails_helper'

RSpec.describe Album, type: :model do
  describe "model validations" do
    it "requires a title, all the time" do
      album = Album.new

      expect(album).to_not be_valid
      expect(album.errors.keys).to include(:title)
    end

    context "validating released_year" do
      it "requires a year, all the time" do
        album = Album.new

        expect(album).to_not be_valid
        expect(album.errors.keys).to include(:released_year)

      end

      ["lololol", 10.0, 95].each do |invalid_year|
        it "doesn't validate #{invalid_year} for released_year" do
          album = Album.new(released_year: invalid_year)

          expect(album).to_not be_valid
          expect(album.errors.keys).to include(:released_year)
        end
      end
    end
  end
end
```

```
require 'rails_helper'

RSpec.describe Album, type: :model do
  describe "model validations" do
    it "requires a title, all the time" do
      album = Album.new

      expect(album).to_not be_valid
      expect(album.errors.keys).to include(:title)
    end

    context "validating released_year" do
      it "requires a year, all the time" do
        album = Album.new

        expect(album).to_not be_valid
        expect(album.errors.keys).to include(:released_year)

      end

      ["lololol", 10.0, 95].each do |invalid_year|
        it "doesn't validate #{invalid_year} for released_year" do
          album = Album.new(released_year: invalid_year)

          expect(album).to_not be_valid
          expect(album.errors.keys).to include(:released_year)
        end
      end
    end
  end

  describe "available_formats scope" do
    #positive test - includes expected, unique formats
    it 'has all the unique formats in alphabetical order' do
      album1 = Album.create(title: 'a', released_year: 1999, label_code: 'l', format: 'a format')
      album3 = Album.create(title: 'a', released_year: 1999, label_code: 'l', format: 'c format')
      album2 = Album.create(title: 'a', released_year: 1999, label_code: 'l', format: 'b format')

      correct_order = [album1.format, album2.format, album3.format]
      expect(Album.available_formats).to eq correct_order
      # expect(Album.count).to eq 3
    end

    #negative test - excludes duplicate formats
    it "excludes duplicate formats" do
      album1 = Album.create(title: 'a', released_year: 1999, label_code: 'l', format: 'a format')
      album3 = Album.create(title: 'a', released_year: 1999, label_code: 'l', format: 'a format')
      album2 = Album.create(title: 'a', released_year: 1999, label_code: 'l', format: 'b format')

      correct_order = [album1.format, album2.format]
      expect(Album.available_formats).to eq correct_order

    end
  end
end
```

```
require 'rails_helper'

RSpec.describe Album, type: :model do
  describe "model validations" do
    it "requires a title, all the time" do
      album = Album.new

      expect(album).to_not be_valid
      expect(album.errors.keys).to include(:title)
    end

    context "validating released_year" do
      it "requires a year, all the time" do
        album = Album.new

        expect(album).to_not be_valid
        expect(album.errors.keys).to include(:released_year)

      end

      ["lololol", 10.0, 95].each do |invalid_year|
        it "doesn't validate #{invalid_year} for released_year" do
          album = Album.new(released_year: invalid_year)

          expect(album).to_not be_valid
          expect(album.errors.keys).to include(:released_year)
        end
      end
    end
  end

  describe "available_formats scope" do
    #positive test - includes expected, unique formats
    it 'has all the unique formats in alphabetical order' do
      album1 = Album.create(title: 'a', released_year: 1999, label_code: 'l', format: 'a format')
      album3 = Album.create(title: 'a', released_year: 1999, label_code: 'l', format: 'c format')
      album2 = Album.create(title: 'a', released_year: 1999, label_code: 'l', format: 'b format')

      correct_order = [album1.format, album2.format, album3.format]
      expect(Album.available_formats).to eq correct_order
      # expect(Album.count).to eq 3
    end

    #negative test - excludes duplicate formats
    it "excludes duplicate formats" do
      album1 = Album.create(title: 'a', released_year: 1999, label_code: 'l', format: 'a format')
      album3 = Album.create(title: 'a', released_year: 1999, label_code: 'l', format: 'a format')
      album2 = Album.create(title: 'a', released_year: 1999, label_code: 'l', format: 'b format')

      correct_order = [album1.format, album2.format]
      expect(Album.available_formats).to eq correct_order
    end
  end

  describe "on scope" do
    before :each do
      @label = Label.create(title: 'Fancy Label')
      Album.create(label: @label, title: 'a', released_year: 1999, label_code: 'l', format: 'a format')
      Album.create(label: @label, title: 'b', released_year: 1999, label_code: 'l', format: 'b format')
      Album.create(label: @label, title: 'c', released_year: 1999, label_code: 'l', format: 'c format')

      some_other_label = Label.create(title: "Unfancy Label")
      @excluded_album = Album.create(label: some_other_label, title: 'd', released_year: 1999, label_code: 'l', format: 'd format')
    end

    # positive (& negative) test - includes only records on the provided label
    it "includes only the records on the provided label" do
      expect(Album.on(@label).count).to eq 3
      expect(Album.on(@label)).to_not include(@excluded_album)
    end

  end
end
```
```
require 'rails_helper'

RSpec.describe AlbumsController, type: :controller do
  describe "GET #index" do
    it "responds successfully with an HTTP 200 status code" do
      get :index

      expect(response).to be_success
      expect(response).to have_http_status(200)
    end
  end

  describe "POST #create" do
    # positive test - params are validate
    context "Valid album params" do
      let(:album_params) do
        {
          album: {
            title: "a title",
            label_code: "b label",
            format: "c format",
            released_year: '1985'
          }
        }
      end

      it "creates an Album record" do
        post :create, album_params
        expect(Album.count).to eq 1
      end

      it "redirects to the album show page" do
        post :create, album_params
        expect(subject).to redirect_to(album_path(assigns(:album)))

      end
    end

    # negative test - params are invalid

  end
end


```

# Shared Tests in Rspec
From Jumpstartlabs tutorial:
It is tempting to copy/paste the code to the Video examples. The RSpec framework provides functionality to assist with sharing characteristics across different models through shared_examples

```
shared_examples "a published document" do
  [ :author, :publish_date, :featured ].each do |attribute|
    it { should respond_to attribute }
  end
end

describe Article do
  it_behaves_like "a published document"
end

describe Video do
  it_behaves_like "a published document"
end
```

To make the shared_examples available across multiple spec files, you’d need to define or load it in the common spec_helper.rb.
