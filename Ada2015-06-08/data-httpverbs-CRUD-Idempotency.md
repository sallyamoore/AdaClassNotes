# Data!!!
see https://github.com/Ada-Developers-Academy/daily-curriculum/blob/master/topic_resources/http-verbs.md

## HTTP Verbs
IDEMPOTENCY - request does not mutate or change the resource. If you can read data but not change it multiple times. No matter how many times you read it, it won't change. Super safe!
  - temperature - if you have something that tells you the temperature outside right now, it should be idempotent. The act of requesting does not change the data (although the actual value may be differnt every time.) Nothing about the request itself causes the data to change.
  - if you incremented a counter (counting each time temp is checked), it would not be idempotent, but it would still be safe... It changes the resource, the counter, as an effect of the request.
Does the request cause the requested resource to change? No = idempotent.

### get - we've used this one.
read or retrieve a representation of a resource, a unit of data. Used only to read data, not to write.

Returns a representation of data (in a format like HTTP, XML, JSON), and an HTTP response code of 200 (OK).

Safe request - just reads, doesn't change data. Doesn't have a side effect that changes the resource.

Most common. Internet is commonly used to read data.

### post
second most common. Used to CREATE resources; in particular, it's used to create subordinate resources. Subordinate resource = single instance of a parent resource. Defines data attribute of a particular instance. Could create data attributes of an instance but will not redefine the class.

Results in 201 status code - ok, i made that

Neither safe nor idempotent. Multiple requests lead to multiple new resources. Post is used to mutate info on the server (to create).

Used to create info on the server, so it changes. Twitter - a Tweet object is instantiated by a post request.

You give it info, and it uses that info to create a resource.

### put
Similar to post. Used the same way, except its used to UPDATE existing resources. Typically considered to be idempotent and are IDEALLY idempotent.

Once I collect info, it can be edited with put, but no matter how many times I update the info the same way, it will result in the same effect. E.g., collect name ("Sam"), and if you edit name 10 times to "Sally", you will get the same result. Just Sally.

### patch
The rails version of patch. Basically the same purpose as put. Update resource.

### delete
Deletes a resource.

Not safe! Destroys data. But is idempotent.

Returns HTTP status 200 (ok). 2nd time you call it, you will get 404 (not found) (which makes some argue that it isn't idempotent but we'll ignore that)

### Other http verbs include trace and info.

### CRUD - almost all we do on the web.
_C_ reate
_R_ ead
_U_ pdate
_D_ elete

When writing code for web software, ask yourself 1) what kind of operation is this? 2) is it safe? 3) is it idempotent

###HTTP response codes
200 - ok
201 status code - ok, i made that

300 family - this isn't where I think it is. It moved. Resource not longer here.

400 family - I can't find it.
404 - file not found
400 - asked for something but it didn't make sense to sinatra (route problem?)

500 family - You broke it.
