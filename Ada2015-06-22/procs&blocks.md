# Procs & blocks - review of ltp ch. 14

Procs and blocks are referred to as closures, anonymous blocks, and lambdas in other languages.

Procs are reuseable blocks - can be assigned to a var bc they are objects.

Procs are called with .call.

p.117
example of a method that _creates_ a proc using two other procs. Because it returns a proc, you will want to assign it to a variable. When we call the method, we say
`double_then_square = compose(double, square)`
`double_then_square.class => Proc`

now we need to call the new proc that was created:
`double_then_square.call(5) => 100`
proc1 (double) is called first because it is inside the ().

`proc2.call(proc1.call(x))` passes the result of proc1 into proc2 as a parameter.

Can't pass methods as parameters to other objects, but you CAN pass procs! Magic!

We will see these this week as _scopes_. Scopes create "lambdas", which are procs. In ruby, lambdas and procs are basically identical. They aren't identical to academics, but we're programmers, not academics. ;)
