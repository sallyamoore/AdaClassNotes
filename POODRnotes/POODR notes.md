# POODR NOTES

## Ch. 2
Leaky abstraction - something consuming the info depends on a very specific arrangement of that info. Easily breaks. E.g., if you rely on the index # in multiple locations, you are vulnerable b/c down the road index # might change and you'd have to change them all. Massive breakage! If you rely on the index in 1 place, return/assign something else that can more simply be fed to another method etc.

### Struct.
```
Wheel = Struct.new(:rim, :tire) # p. 28
```
Abstract anonymous object... Returns a class that you can treat like a class. Parameters passed in become accessors for that class, but it ONLY makes accessors. It doesn't do anything else. Basically equivalent to:
```
class Wheel
  attr_accessor :rim, :tire
end
```
JNF probably would have made a new class immediately rather than using this intermediate step.

Metaprogramming - creating methods and classes whose return values are methods and classes. Struct is used for metaprogramming - it is a feature that creates a class. Using code to dynamically create that class.

Struct will be evaluated immediately, unlike methods. Scope will be only within the larger order class.


## Ch 3
class coupling - way of describing dependence

dependency injection - reducing to a single dependency by relying on an intermediate variable rather than calling, for example, a second class from directly within a class.

abstract classes & designing with "factories"- for example, in BankAccounts, your Account would *only* be a skeleton that requires other account types to have a withdraw method and a deposit method. It would NOT define

defaults - because arguments for initialize are coming in as a hash, you can't use the usual default syntax. Instead, options are || or fetch.

UML - unified modeling language - way of modeling relationships among objects

pp. 50-51 - on designing with "factories"
  - as consumer of Gear object, with a wrapper, you don't need to know about changes in order to use Gear. You can use Gear and some other person whose job it is to maintain gear will make sure it does what it needs to do.
  - the wrapper instantiates Gear for you.
  - usually, wrapper would do a bit more with the Gear.
  - by using a hash to initialize Gear, you also don't have to order the Gear arguments. Wrapper uses a hash and orders args for you.

||= or equals, means if var exists, leave it alone; if is doesn't, set it equal to designated value. `check_use ||= 0` means if there's a check_use variable, take that value; if not, set it equal to 0. Carly used this in her checking account within the BankAccounts project.


## Ch 4
### Private methods
Great for things like validation of user input. If you wouldn't want the user to be able to directly call a method, it should be private. Expected NOT to be invoked by others.

### Public interfaces - expected to be invoked by others.

### Law of Demeter
- if you're using methods in a chain (dots) and you're changing the type of object, you've violating Demeter. If you stick with the same type of object, it's a-ok.
- When chaining, consider the type of object each method is returning. 
