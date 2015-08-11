# Bootstrap

Bootstrap is an open source project started by Twitter. It is a front-end HTML,
CSS, & Javascript framework. It provides tools and standards for creating
common web elements. One of it's main features is a responsive (different size
screens) grid system. But it also includes things like default styles for
common elements, icons, and even javascript features such as modals, tooltips,
and image slideshows.

Installation
------------
There are many ways to install bootstrap, it is possible to use Less or Sass to
compile the CSS on the fly, this allows you to change the defaults within
bootstrap by simply changing variables. There is a ruby gem which enables this
but we're going to take the easy way out and just download the raw CSS. Go to
[Bootstrap](http://getbootstrap.com/getting-started/#download)
and click on the "Download Bootstrap" button. This will download all of the
CSS, JS, and fonts.

### References
[Bootstrap Docs](http://getbootstrap.com/getting-started/)
[W3Schools Tutorial](http://www.w3schools.com/bootstrap/default.asp)
[Bootstrap-Sass Gem](https://github.com/twbs/bootstrap-sass)  


Builds a fluid grid system:
http://getbootstrap.com/css/#grid
Based on 12 columns and aligns smaller (merges columns) to accomodate different window sizes.

Bootstrap styles are applied through css classes. Bootstrap gives you all of the classes and their functionality; you apply the classes to create your design.

There are class prefixes that correspond to the size of the device, so you can specify how it will look (and make it look different) depending on the device.

## livecode of applying bootstrap

Bootstrap uses divs to create framework of how page will look. These divs are _just_ for layout purposes.

### Bootstrap classes.
"container-fluid" - makes a fluid grid system based on screen size.
"jumbotron" - the giant component that runs across the entire screen. Often for headings.  
"row" - does not change display initially; enables any content within row to act as a cohesive unit. Says the markup is related in some way.
"col-sm-4" - small sized column. Numbers add up to 12, 12 columns in bootstrap. With 3 "col-sm-4"s, each col takes up equal space. "sm" is optimized for tablet size.
  - can also apply more than one. Will change depending on size.
  Example: `<div class="col-xs-4 col-sm-4">`  
"table" - pretty table options! Basic is "table"
"table table-striped" - to add more options, add more classes!
"col-sm-offset-3" - To center: use offsets.

"form"
"form-group" - contains the items that creas the item -- label and input.
"form-control" - directly on the input type or form field, creates the curved corners and blue highlighting when you click on it.
"btn btn-default" - button! btn is button, btn-default is an add-on style.
"btn-danger" = for deleting. etc. These are just classes.

# To install in Rails app as a gem
https://github.com/twbs/bootstrap-sass

### Customization
Never change the bootstrap css file. Instead, make a new class or make a new version of the class with the specific things you want.
