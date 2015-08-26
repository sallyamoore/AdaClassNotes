# Exercises from reading:
Looping a triangle

Write a loop that makes seven calls to console.log to output the following triangle:

#
##
###
####
#####
######
#######

`for (var tri = ""; tri.length < 8; tri += "#")
  console.log(tri);`
​
- Browser determines what version of javascript
- Access JS in browser with developer tools -> console
- Like in Ruby, everything in JS is an object, even functions.
- JS code sets what is available. Functions get called in the browser depending on what the user does.

# Basic JavaScript

We try to separate concerns in web applications:

* HTML - Document structure and information. Your HTML mark up should
  be a semantic representation of the information in your document.

* CSS - Presentation. CSS controls the way that we present our
  information to the user.

* JavaScript - Behavior and interactivity. We use JavaScript to handle
  user interactions via events, and to add interactivity to our web
  apps.

## JavaScript basics

### Playing with JavaScript

Safai, Firefox, and Chrome all support a JavaScript console, which
allows us to write JavaScript directly in the browser. In Chrome, you
can access the console either via the menu (View > Developer >
JavaScript Console), or via the keyboard shortcut (Command - Option - J).

There are also several sites that allow you to live code JavaScript,
HTML, and CSS. The three most popular are [JSFiddle](//jsfiddle.net),
[CodePen](//codepen.io), and [JS Bin](//jsbin.com). We'll use
JSFiddle for demonstrations, but it's a matter of taste.

### Getting Help

The best JS doumentation is on the
[Mozilla Developer Network](https://developer.mozilla.org). ProTip:
add "mdn" to your Google searches about JavaScript
questions. W3Schools results will show up above MDN otherwise, and
their documentation is not as useful.

### Variables

Declare all variables with the var operator!

```javascript
var five = 5;
```

If you omit ```var``` you will get a global variable, which can lead
to all sorts of problems. __JUST DON'T DO IT!__

**Note** that each line of JavaScript code ends with the `;`.
This is optional for the code to work (sometimes, and the rules are inconsistent) but **not** optional when taking into consideration style guidelines.

### Types

[MDN Data Types and Data Structures](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Data_structures)

JavaScript supports similar basic types to Ruby: Boolean, Null,
Undefined, Number, String, Array, Object, and Function.

Open the JavaScript Console and try the following examples.

* Boolean is true or false

```javascript
var t = true;
var f = false;
```

* Null is the value null. This represents an "empty" value.

```javascript
var empty = null; // this is false in an if statement
```

* Undefined is the value undefined. When a variable which has not
  declared is accessed, JS returns undefined.

```javascript
if (blahblah) {  // blahblah has not been declared it returns undefined
                 // which is false-y
    // so, this won't happen
}
```

* Number is a numeric value including integers (1, 2, 3, etc.), floats
  (1.4, -40.1), infinity (+Infinity, -Infinity), and NaN which means
  "not a number." NaN is returned when you do a numeric operation on
  anything that's not a Number.

```javascript
var four = 4,     // Note the comma-separated variable declarations
    two = 2.0;

Infinity < Number.MAX_VALUE  // false
Infinity > Number.MAX_VALUE  // true

two == four / two; // true

// All JS numbers are floats, and floats are not 100% accurate...
0.1 + 0.2 == 0.3; // false!
0.1 + 0.2;

// To make this work:
parseFloat((0.1 + 0.2).toPrecision(2))
// 0.3
// You have to do parseFloat because toPrecision returns a string (wha?). The parameter passed to toPrecision is number of significant digits.

// In short, don't do heavy mathematical operations in JS.

"asdf" - 5; // NaN
```
If you try to do mathematical operations on non-numeric values, you will get NaN.

NaN spreads, meaning that everything with a mathematical operation thereafter is NaN.

NaN, undefined, and null are all "false-y." In a conditional, they will be treated as false most of the time.

Built in libraries: Math, Number (e.g., Number.MAX_VALUE)

* Strings a declared with "" or ''. They're basically the
  same. Pick one and stick with it!

```javascript
var str = "This is a string";
str.length;      // 16 - access the length property
str.substr(2,5); // "is is" - call the substr function
```
substr is like slice. Start at (first parameter), take (2nd parameter) places

JavaScript allows double- or single-quoted strings.



### Arrays
* [Arrays](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array) are similar to Ruby arrays. They are declared and accessed
  with square brackets ([]).

```javascript
var arr = [1, 2, 3, 4];
arr.length;  // 4 - access the length property
             // Note this *cannot* be accessed like a method with parenthesis
arr[0];      // 1
arr.pop()    // 4 - call the pop() function
             // Note this method *cannot* be used without the parenthesis
arr;         // [1, 2, 3]
```

### Objects
* [Objects](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Object) are like simple Ruby hashes. They are declared with braces
  (`{}`). You can access properties in an Object with bracket notation
  (like an array) or dot notation.

```javascript
var obj = {     // We can span lines; whitespace is mostly ignored.
  num: 5,
  str: "This is a string",
  subObject: {
    otherNum: 4
  }
};

obj.num;    // 5
obj['num']; // 5; note we use a string!
obj.subObject.otherNum; // 4
obj.foo;    // undefined

```

### [Conditionals](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/if...else)
* Conditions are surrounded by parenthesis `()` and each block is surrounded by brackets `{}`.
```javascript
var name = "kittens";
if (name == "puppies") {  // close } before next part of conditional (line 194)
  name += "!";
} else if (name == "kittens") {
  name += "!!";
} else {
  name = "!" + name;
}                     // no word "end"; } closes it instead.
name == "kittens!!"
```

Notable differences from Ruby: `else if` instead of `elsif`; no `end`; lots of {}; conditions require parentheses around them.

Always include braces and semicolons for maximum translatability of javascript.

* JavaScript also has the ternary operator
```javascript
var adult = (age > 18) ? "yes" : "no";
```

### Iterators
- Most common is the for-loop which has three parts:
  - `var i = 0` - **starter**  
    This executes at loop start.
  - `i < 5` - **loop condition**  
    The condition to check if loop is finished. It is checked after every execution of loop body.
  - `i++` - **increment**  
    An action to perform after every iteration, but before the loop condition is checked.


```javascript
for (var i = 0; i < 5; i++) {
  // Will execute 5 times
}
```

```javascript
var sum = 0;
var arr = [3, 9, 10, 1]
for ( var i = 0; i < arr.length; i++) {
  sum += arr[i];
}
  // var i = 0; is our STARTER - counter
  // i < 5; is the CONDITION - loop continues while condition is true.
  // i++ is the INCREMENTER - what happens to counter during each pass of the loop.
  //++ is similar to += 1.
  // {} encloses the block to execute in each pass.
```
loop table
|  i  |  sum  |
|-------------|
|  0  |  3    |
|  1  |  12   |
|  2  |  22   |
|  3  |  23   |
|  4  | <stop>|
|-------------|

the only var you set in the loop is the incrementer.

Another example:
```javascript
var animals = [ "cat", "dog", "bear" ];
for (var i = animals.length - 1; i >= 0; i--) {
  console.log(animals[i])
}
```

loop table
|  i  |output |
|-------------|
|  2  | "bear"|
|  1  | "dog" |
|  0  | "cat" |
| -1  | <stop>|
|-------------|

use jsfiddle.net to check out results of code. Note tat you have to have dev tools option to js console.

### Functions
* Functions in JavaScript are awesome. Rather than using the `def` keyword like we're used to, JavaScript uses the `function` keyword to declare a function.

```javascript
function (choice1, choice2) {
  if (choice1 == choice2) {
    return "This is the same!";
  }
}
```

They are more "pure" than Ruby
  methods and can be put in variables, and passed around like any
  other type. Understanding functions is the key to JavaScript
  enlightenment.

```javascript
var adder = function (a, b) {
    return a + b;   // You need to explicitly call return in JavaScript
}

// You need to use parens to call your function!
adder;        // this returns the function that you just declared
adder(1, 2);  // 3 - this executes the function and returns the result
```

# Exercises# JavaScript Exercises

### Exercise #1: Create a ToDo object, with the following properties:

- a task (a string) - a description of the thing to do
- assignee (a string) - the name of a person to do it
- done (a boolean) - is the task done or not?
- getDone (a method) - get the value of done, use "this" in the body of the method.
- setDone (a method) - set the value of done, use "this" in the body of the method.

```javascript
var todoList = {
  task: "I am a task",
  assignee: "jeremy",
  done: false,
  getDone: function() { return this.done; },
  setDone: function(state) { this.done = state; }
}
```

### Exercise #2: Find the biggest number in the array

- Utilize the stub code below to complete the problem:
 - `getBiggest`should accept an array as a parameter and return a numeric value which corresponds to the largest value

```javascript
var arrayOfNums = [2, 7, 7, 3, 9, 0, 1, 6, 8, 3, 8, 4, 7, 9];

function getBiggest(array) {

// your code goes here!!

}

//
// pass an array to getBiggest;
// get a return value that is the biggest number in the array
//
var biggest = getBiggest(arrayOfNums);
console.log("The biggest is: ", biggest);
```

```javascript
var arrayOfNums = [2, 7, 7, 3, 9, 0, 1, 6, 8, 3, 8, 4, 7, 9];

function getBiggest(array) {
  var biggest = 0;
	for (var i = 0; i < array.length; i++) {
        if (array[i] > biggest) {
            biggest = array[i];
	        console.log(biggest);
        }
	}
    return biggest
}

var biggest = getBiggest(arrayOfNums);
console.log("The biggest is: ", biggest);
```



## FizzBuzz - Common interview question!
```javascript
function fizzBuzz () {
  for (var i = 1; i <= 100; i++) {
    if (i % 3 == 0) {
      console.log("fizz");
    } else if (i % 5 == 0) {
      console.log("buzz");
    } else {
      console.log(i);
    }
  }
}

fizzBuzz();
```

```javascript
function fizzBuzz2 () {
  for (var i = 1; i <= 100; i++) {
    if (i % 3 == 0 && i % 5 == 0) {
      console.log("fizz... buzz... UNICORNS!!!");
    } else if (i % 3 == 0) {
      console.log("fizz");
    } else if (i % 5 == 0) {
      console.log("buzz");
    } else {
      console.log(i);
    }
  }
}

fizzBuzz2();

```

Refactor Solutions:
```javascript
function fizzBuzz () {
  for (var i = 1; i <= 100; i++) {
    var message = "";
    if ( !(i % 3) ) { message += "Fizz"; }
    if ( !(i % 5) ) { message += "Buzz"; }
    console.log(message || i);
  }
}

function fizzBuzz () {
  for (var i = 1; i <= 100; i++) {
    if (i % 15 == 0) {
      console.log("fizz... buzz... UNICORNS!!!");
    } else if (i % 3 == 0) {
      console.log("fizz");
    } else if (i % 5 == 0) {
      console.log("buzz");
    } else {
      console.log(i);
    }
  }
}

```

# CHESS BOARD

```javascript
function chessboard () {
  var grid_size = 8; board = "";
  for (var i = 1; i <= grid_size; i++) {
    if (i % 2 == 0) {
      board += "#_#_#_#_\n";
    } else {
      board += "_#_#_#_#\n";
    }
  }
  console.log(board);
}

chessboard();
```

```javascript

function chessboard (grid_size) {
  var board = "";
  for (var i = 1; i <= grid_size; i++) {
    if (i % 2 == 0) {
      board += "#_#_#_#_\n";
    } else {
      board += "_#_#_#_#\n";
    }
  }
  console.log(board);
}

chessboard(8);
```

Kari
```javascript
var grid_size = 8, board = "";
for (var i = 1; i < grid_size; i++) {
  for (var j = 0; j < grid_size; j++) {
    board += (i % 2 == j % 2 ) ? "_" : "#";
  }
  board += "\n";
}

console.log(board);
```

SM solution to specify size (lines) and width:
```javascript

function chessboard (grid_size, width) {
  var board = "";

  for (var i = 1; i <= grid_size; i++) {
    if (i % 2 == 0) {
      for (var j = 1; j <= width; j += 2) {
        board += "_#";
      }
      board += "\n";
    } else {
      for (var j = 1; j <= width; j += 2) {
        board += "#_";
      }
      board += "\n";
  	}
  }
  console.log(board);

}

chessboard(10, 16);
```

# More Exercises:
# Getting Started Exercises

<!--Use the js-playground to write the code in these exercises. You will need to create modules in the src/ directory for your solutions to the exercises.-->

## Reverse an Array

JavaScript provides an Array.reverse method. For practice, we're going to write something similar. Neither solution should use the reverse method.

<!--Create a module in src/ called reverser.js. This file should export a JS object with methods that are the functions defined in the exercises.-->



### First

Write a function called reverseArray() that takes an array, `ar` as an argument and returns a new array that has the same elements as `ar`, but in inverted order. Add this function to your reverser module.

```javascript

function arrReverse(ar) {
    var reversed = [];
    for (var i = ar.length - 1; i >= 0; i--) {
    	reversed.push(ar[i]);
    }
    return reversed;
}

console.log(arrReverse([ 1, 2, 3, 4, 5]));
```

### Added fun!

Write a function called reverseArrayInPlace() that takes an array `ar` as an argument and returns the same array modified to have its elements in reverse order.

```javascript
function dangerousArrReverse(ar) {
  var last = ar.length - 1;
  for(var i = 0; i < ar.length/2; i++) {
    var a = ar[i];
    var b = ar[last - i];

    ar[i] = b;
    ar[last - i] = a;
  }

  return ar
}
```

My solution:
```javascript
function arrReverseMutate(ar) {
    for (var i = 0; i < ar.length; i++) {
        var temp = ar.pop();
        ar.splice(i, 0, temp);
    }
    return ar;
}

var x = [ 1, 2, 3, 4, 5];
console.log(arrReverseMutate(x));
console.log(x);

console.log(arrReverseMutate([ "kitty", "puppy", "unicorn", "unigoat"]));
```

## Palindrome

Build a function that takes a string as a parameter and returns whether or not that string is a palindrome.


## HW Koans
To run, use `$ open KoansRunner.html`
Uses a testing framework, Jasmine, which is similar to Rspec but for JavaScript.
