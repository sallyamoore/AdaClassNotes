#### Defining new helper methods

New helper methods are defined in within the `app/helpers` directory. All of the helper files within `app/helpers` will be available to any page, the only reason to have seperate files is to seperate concerns. The `application_helper.rb` is a great place to define methods that are not specific to a model.

Let's define a new method that transforms a date object into something readable:

    def readable_date(date)
      "<span class='date'>" + date.strftime("%A, %b %d") + "</span>"
    end

Then within any view I could use this method, and pass in any date or time object:

    <h1><%= @book.title %></h1>
    <%= readable_date(@book.created_at) %>

This would produce the HTML

    <h1><%= @book.title %></h1>
    <span class='date'>Wednesday, Jan 08</span>

Put these in app/helpers. If you want it to be available in all views, you put in application_helper.rb. Otherwise, create file structure like in views. So, a helper in products would be app/helpers/products/products_helper.rb

Partials vs view helpers
  - partials are larger. Whole blocks of display text.
    - header
    - form
  - view helpers are for distinct operations that you want to be reuseable.
    - format date
    - format text
