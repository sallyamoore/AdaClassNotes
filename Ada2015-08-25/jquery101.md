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
