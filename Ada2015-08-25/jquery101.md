# Playing With jQuery

jQuery is a JavaScript library for DOM (web page) manipulation and
cross-browser script compatibility. jQuery does most of it's magic
through a global function that it defines in the '$' variable.

## Selectors

You can use the jQuery function ($) to grab and manipulate elements of
your web page. jQuery uses CSS selectors to find the elements on the
page.

(Instead of `$` you can type `jQuery`.)

```javascript
$("body");     // returns (a jQuery object representing) the body element
$(".content"); // returns an array of elements with the "content" class
$("#someId");  // returns the element with id == "someId"
```

jQuery calls tend to return jQuery objects, and these tend to be collections (even if only one thing).

## Functions that take functions

Many jQuery methods take functions as parameters. These are often
referred to as "callbacks."

```javascript
$("#someId").click(function () { // this is an "anonymous function"
                                 // we define it here and pass it to the
                                 // .click() function. When a click happens,
                                 // this function is called.
  /* Do something here! */
});
```

The jQuery click() function waits for a user event--in this case the
user clicking the element with their mouse--and then calls the
function that you provide (the callback) when that event happens.

DOM = Document Object Model - Model of the document, i.e., of the website. Text translated into an object.
Nodes = CSS tags in the DOM are translated into Nodes, a type of object you can use in code. Chunk of the DOM as defined by a tag.

Example:
  <div class="constrain"> is a Node in a website's DOM. It may also have subnodes.

## jQuery Documentation

The many splendors of jQuery are explained in great detail here:

[http://api.jquery.com/](http://api.jquery.com/)

The following functions are of practical value. Look 'em up!

* .append()
* .prepend()
* .css()
* .html()
* .click()
* .submit()

## DOM Manipulation

Here's [an example](http://jsfiddle.net/wstfe20a/) on JSFiddle.

Play with the example:

* Change the document structure
* Change the CSS
* Change the click behavior

There is also a local HTML file with similar document structure that
pulls in jQuery via a script tag. Try opening the document in your
browser and doing the same manipulations in the JavaScript console.


Notes on example:
```javascript
$(document).ready(function () {   // .ready happens once. Means don't do  
                                  // anything until document has loaded.
                                  // Enclosed code will fire when doc is ready.
  $("#big-header-2").css("color", "#00ff00");

    $("#big-header-1").click(function () {
      $(this).toggleClass("red");
    });

    $("#post-1").click(function () {
      $(this).append("This is new text.");
    });
});
```

submit example
```javascript
$(".submit-me").click(function (event) {
  alert( "Handler for submit() called.");
  xxx
}
```

Other fun stuff
.fadeOut
.fadeIn

mine:
http://jsfiddle.net/sallyamoore/ru5bkbru/

Music Box
html <audio> tag
1. attach click event to appropriate buttons
2. and then figure out which note to play for that button
3. make the audio tag play
// to play, make a function that does this:
```javascript
var audio_tag = document.getElementById('aAudio');
audio_tag.current_time = 0;
audio_tag.play();
```

jnf solution
```javascript
$(document).ready( function() {
  $('.note').mousedown(function() {
    var note_id = $(this).text() + "Audio"; // gets the text contained in the element
    var note = document.getElementById(note_id);
    note.currentTime = 0;
    note.play();
  });
});
```

jnf with keypress
```javascript
$(document).ready( function() {

  $('.note').mousedown(function() {
    playNote($(this).text());
    });

  var note_letters = ['a', 'b', 'c', 'd', 'e', 'f', 'g']
  $('html').keypress(function(event) {
    var letter = String.fromCharCode(event.which);
    if (note_letters.indexOf(letter) > -1) {
      playNote(letter);

      $('.note.' + letter).addClass('active');
      setTimeout(function() {
        $('.note').removelass("active");
        }, 100);
      }
    })

  function playNote(note) {
    //play note looked something like this
    var note = document.getElementById(note_id);
    note.currentTime = 0;
    note.play();
  }
});
```

kari solution
```javascript
$(document).ready( function() {

  function playNote(note_letter) {
    var audio_tag = documents.getElementById(note_letter + "Audio");
    audio_tag.currentTime = 0;
    audio_tag.play();
  }

  $(".note").click(function() {
    // get assoc'd class
    var class_name = $(this).attr("class");
    var note = class_name.charAt(class_name.length - 1);

    playNote(note);
  }

  // logic for keypress
  $(this).keypress(function(e) { // e is short for event. Can call it anything, but e and event are typical.
    var key_code = e.which;

    // ensure key_code is in the correct range.
    if (key_code > 96 && key_code < 104) {
      var note = String.fromCharCode(e.which);
      playNote(note);
    } else {
      alert("Stop pressing weird keys!");
    }
  });
});
```
## HW REV EJS Ch 13 - the DOM
body has childNodes (e.g., h1, p) that are numbered using array index notation from top to bottom. Can navigate around in jQuery using methods like previousSibling, lastChild, parentNode, etc.

### get all children:
$('body').children();

### get children with p tags:
$('body').children('p');

### get first/last child:
$('body').children(':last-child');
$('body').children(':first-child');
- there's also nth-child

### get siblings, get parent:
var first_child = $('body').children(':first-child');
var siblings = first_child.siblings();
var parent = first_child.parent();

### is the parent a body?
console.log(parent.is("body"));

### is the parent a div?
console.log(parent.is("body"));

Example of usage:
Submit button is at bottom of form; would need to navigate up to get info on where submit should go.

## Modify!
### add a new <h2>
last_child.append("<h2>YAAAS</h2>") // but is nested within the p tag.

### add new <h2> to parent:
parent.append("<h2>BO$$</h2>") // adds to end of content, not end of element
                               // it's called on

### get class attribute:
children.attr("class");

### set class attribute:
children.attr("class", "not-classy");

### add a class:
children.addClass("some-font");

### toggle class on click:
$('h1').click(function() {
    $(this)toggleClass("some-font");
});

### get parent with specified class (works even if nested):
$(this).parents('.club');


# other helpful jquery functions
.reload()
.isNaN()
.val vs .text
  - val = jquery method that gets/changes value of an _input_ html object.
  - text = jquery method that gets/changes the text in a node.
  - innerhtml is a JavaScript function to get text in a node
