# HTML forms

## <form> - tag that says this is a form
## <fieldset> grouping of data that goes together, e.g., two lines of address. not used that often.

## <input> - use it for just about any type of input
  - <input type="text"> - single line
  - <input type="checkbox">
  - <input type="radio">
  - <input type="password">
  - <input type="file"> and <input type="image">
  - <input type="submit"> - submit button
  - <input type="reset"> (careful with this one) - clear form
  - <input type="hidden"> - hidden input, e.g., how twitter knows to attach the tweet to you.

## <textarea> - big text box
## <select> - e.g., dropdown menu
## <option> - every option in dropdown is tagged this way.
## <button>, and <input type="button"> are primarily used for JavaScript interactions. - makes a button, but not a submit button.

## <label> - how you associate an input field and the text that defines its purpose. HTML standard is to always have a label. Creates an association between the input and "username" label. etc. The `for` attribute pairs with an input ID so you know this label is associated with this input. Also makes it so that if you click on the label it will activate the form field.

Example text:
```
<form action="" method="post" accept-charset="utf-8">  
  <label for="username">Username</label>
  <input type="text" name="username" value="" id="username">

  <label for="fave-animal">Favorite Animal</label>
  <input type="text" name="fave-animal" value="" id="fave-animal">

  <input type="submit" value="Submit">
</form>
```
action - defines the url to which the form will go, goes to person responsible for processing the info. Blank post to the same url as the page the form is on.
method - verb.

label connects id with label. Always use labels with input tags.

value - sets default value.

names map to keys in params hash
in names, if you change to `fun[fave-animal]`, you create a hash in a hash, and you'd have to reference as params[:fun][:username]

--------
post "/my_first_form" do
  @username = params[:fun][:username]
  @animal = params[:fun][:"fave-animal"] # :( accidentally used a dash in name so has to do this ugly code thing
  erb :my_first_form

  Address.new(params[:addy]) # with nested hash, you can do this
  # you'd have an address class like:
  # class Address
  # => def initialize(options)
      # @addy_1 = options[:addy_1]
      # @addy_2 = options[:addy_2]
  #   end
  # end
end

hash would be like this:
{
  addy: {
    addy_1: "input text for addy1"
    addy_2: "input text for addy2"
  }
}

In html form:
<label for "address_1">Address 1</label>
<input type="text" name="addy[addy1]" id="address_1"

<label for "address_2">Address 2</label>
<input type="text" name="addy[addy2]" id="address_2"

<input type="submit" value="Submit">

### Note that if the structure of a form has changed, just refresh won't work. Must click in the address bar and hit enter. At least in Chrome. Otherwise it will try to repost the same form data and you'll get an error.
--------
# Sidenote:
## pre tag
text will appear exactly as you put it.


# Checkboxes
If checkbox is in a group of checkboxes:
name="toppings[]" <- will tell sinatra to return an array of selections

## fieldset tag - everything nested inside is assumed to be related. Good for groups of data (e.g., address), including groups of checkboxes. Puts a border around the group by default.

## legend tag - gives a heading to the fieldset.

## label tag - used to surround a single checkbox input _without_ adding the for attribute. Can put the form control inside the label element itself. But nesting it within, we create the same type of relationship as the for and id.


## Radio buttons
Structured the same way, but can only pick one. Don't need an array because you only pick one.
