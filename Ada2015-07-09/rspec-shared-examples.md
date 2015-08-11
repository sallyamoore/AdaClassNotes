# Shared examples in rspec
www.relishapp.com/rspec/rspec-core/docs/example-groups/shared-examples

Add Dir snippet to spec helper in the RSpec.configure do
  `**` means any folder. 2 * to include nested folders.
  `*` means any file in that folder

```
RSpec.shared_examples "some example" do |parameter|
  \# Same behavior is triggered also with either `def something; 'some value'; end`
  \# or `define_method(:something) { 'some value' }`
  let(:something) { parameter }
  it "uses the given parameter" do
    expect(something).to eq(parameter)
  end
end

RSpec.describe SomeClass do
  include_example "some example", "parameter1"
  include_example "some example", "parameter2"
end
```

```
require "set"

RSpec.shared_examples "a collection" do
  let(:collection) { described_class.new([7, 2, 4]) }

  context "initialized with 3 items" do
    it "says it has three items" do
      expect(collection.size).to eq(3)
    end
  end

  describe "#include?" do
    context "with an item that is in the collection" do
      it "returns true" do
        expect(collection.include?(7)).to be_truthy
      end
    end

    context "with an item that is not in the collection" do
      it "returns false" do
        expect(collection.include?(9)).to be_falsey
      end
    end
  end
end
```


'a collection' - descriptor for set of tests you want to do mult times. Could be anything. To tie it in to a model/controller, use:

```
RSpec.describe Array do
  it_behaves_like "a collection"
end
```
RSpec.describe AlbumController::Controller do... (?)

Use describe blocks for shared examples at OBJECT LEVEL 
