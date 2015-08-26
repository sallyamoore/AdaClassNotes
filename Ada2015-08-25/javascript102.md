# Fun with JavaScript Functions!
Javascript's appeal and power and flexibility are in the myriad ways we can interact with functions.

### Functional expressions vs. Function declarations
* Functions are objects
* `var foo = function(bar){};` vs. `function foo(bar){}`
* In _many_ cases, the differences here are nominal, but it's important to understand the first example is an __expression__ while the second is a __declaration__.
* [This StackOverflow answer is one of the best I've seen in describing the difference and when it matters](http://stackoverflow.com/questions/3887408/javascript-function-declaration-and-evaluation-order).

Expression vs declaration is sometimes an important distinction. In compilation, code is first translated into byte code, then executed. Declarations are allocated in the first phase, and expressions in the second. Charles: You can think about it as _declarations are timeless_, while expressions are not. The expression happens in top-to-bottom code order, so, depending on what you're doing, you may be unable to assign an expression b/c you call it before it is created. Expressions involve setting a variable.

Declarations are kinda like using def in ruby. Expressions are kinda like procs.

### Functions, methods, constructor calls
```javascript
var foo = function() { console.log('nah'); }
var obj = {
  foo: function() {
    console.log('foo!');
  }
}
var Obj = function(){};
Obj.prototype.foo = function(){};
var o = new Obj();
```

### Prototypes
Prototypes in js are kinda like Ruby classes (but not completely).
```javascript
var Obj = function(){};
Obj.prototype.foo = function(){ console.log("taco") }; // Creates prototype and assigns foo to
// a function in that prototype
var o = new Obj(); // news up an instance of Obj. Creates a deep copy of the
// prototype
o.foo(); // calls foo on o. -> taco.
o.bar = function() {  console.log("Hi Charles"); }; // creates new function
// for o that Obj doesn't know about.  
// kinda like inheritance in Ruby. Called prototypal or prototypical
// inheritance
```

```javascript
// in console
Obj
// function Obj()
o
// Obj {}
  // bar: function()
  // __proto__: Obj
o.foo();
// taco
// undefined
```
### Calling functions directly
* `foo();`
* `obj.foo();`
* `o.foo();`

### Passing functions as variables
* Computer scientists call this _higher order functions_ and/or _first-class functions_.

```javascript
var talker = function( sum ){
  console.log( "Yo the sum is: " + sum );
};

var alerter = function(sum) {
  alert("Yo the sum is: " + sum);
}

var doMath = function( num1, num2, im_a_function ){
  var sum = num1 + num2;
  im_a_function( sum ); //Hey! let's execute the function we were given!
};

doMath(1000, 2, talker); //Hey! talker is a var whose value is a function!
doMath(1000, 2, alerter); //Hey! alerter is a var whose value is a function!
```

(Functional languages are _all about_ this -- creating functions and passing them between each other.)

#### Somewhat Practical Example: Array.prototype.sort

```javascript
var backwards = function(x, y){  // is a comparator function (compares values)
  if( x > y ){
    return -1;
  }
  if( x < y ){
    return 1;
  }
};
// this is similar to how sort compares, only backwards. It overrides how
// sort does the comparison. Just flips the signs (+/-), and now it works
// backwards!

[4, 2, 5, 1, 9, 5].sort(); //=> [1, 2, 4, 5, 5, 9]
// when you use [] to create an array, you are creating an instance of the
// Array prototype, so it has access to Array functions!
[4, 2, 5, 1, 9, 5].sort( backwards ); //=> [9, 5, 5, 4, 2, 1];
```

### Call vs. Apply
* `foo.apply( bar, [a1, a2, a3] )`
* `foo.call( bar, a1, a2, a3 )`
* The difference is that `apply` lets you invoke the function with __arguments as an array__; `call` requires the parameters be __listed explicitly__.
* The real power in `apply` and `call` is in the `bar` variable in the above examples. We will discuss it in detail in the next couple of lessons.

```javascript
function lunch_alert(name, food) {
    alert("My name is " + name + " and I am hungry for " + food + ".");
}
lunch_alert("Jeremy", "tacos");
lunch_alert.apply(undefined, ["Rosa", "tacos as well"]); // 1st arg is SCOPE
lunch_alert.call(undefined, "Raquel", "world domination");
```
Apply takes _up to 2_ parameters. Call takes at least 1 parameter. If you know how many parameters you'll need, use apply. If you don't, use call.

### Arguments!
* A pseudo-array of the arguments that are passed into a function

```javascript
var hello = function(name){
  var args = Array.prototype.slice.call( arguments, 1 ); // slices name from
  // arguments so you can call it separately below. Must use Array.prototype
  // instaed of just calling slice on arguments b/c arguments is a
  // _pseudoarray_, not an actual array. Weird.
  console.log( "Hello " + name + ", " + args.join( ' ' ) );
};

hello( "Jeremy", "what", "are", "you", "doing" ); //=> "Hello Jeremy, what are you doing"
```

### Let's make a .first method!
```javascript
Array.prototype.first = function() { return this.slice(0,1); };

var x = [1, 2, 3, 4]
// undefined
x.first
// Array.first()
x.first();
// [1]
```
Yay!


## Exercises from EJS ch 3:
### Minimum
Write a function min that takes two arguments and returns their minimum.

```javascript
function min(x, y) {
  return (x < y) ? x : y;
}

console.log(min(0, 10));
// → 0
console.log(min(0, -10));
// → -10
```

What if we want an unlimited number of parameters?
```javascript
function min() {
  var smallest = null; // this is weird...
  for (var i = 0; i < arguments.length; i++) {
    smallest = smallest < arguments[i]
    ? smallest : arguments[i]
  }
  return smallest;
}

console.log(min(0, 10, 50, -200, 7, -1));
// -> -200
```

Could also say:
```javascript
function min(starting_point) {
  var smallest = starting_point;
  for (var i = 1; i < arguments.length; i++) {
    smallest = smallest < arguments[i]
    ? smallest : arguments[i]
  }
  return smallest;
}
```

### Recursion

We’ve seen that % (the remainder operator) can be used to test whether a number is even or odd by using % 2 to check whether it’s divisible by two. Here’s another way to define whether a positive whole number is even or odd:

 - Zero is even.
 - One is odd.
 - For any other number N, its evenness is the same as N - 2.

Define a recursive function isEven corresponding to this description. The function should accept a number parameter and return a Boolean.

```javascript
function isEven(number) {
  number = Math.abs(number);
  if (number == 0) {
    return true;
  } else if (number == 1) {
    return false;
  } else {
    return isEven(number - 2);
  }
}

console.log(isEven(50));
// → true
console.log(isEven(75));
// → false
console.log(isEven(-1));
console.log(isEven(-20));
```

JNF solution:
```javascript
function isEven(number) {
  if (number < 0) { return isEven(Math.abs(number)); }
  if (number == 1) { return false; }
  if (number == 0) { return true; }
  return isEven(number - 2);
}
```


Brandi's solution:
```javascript
function isEven(x) {
	switch (Math.abs(x)) {
      case 0:
        return true;
      case 1:
        return false;
      default:
        return isEven(Math.abs(x) - 2);
    };
}
```
