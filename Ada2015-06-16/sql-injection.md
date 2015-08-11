# SQL injection
code injection technique used to attack data-driven applications. Uses forms to hack into a sequel database. Statement that hides a command to access database. Don't need to know exact structure to figure out how to hack you. Hackers test if vulnerable, then, if they got in, reconstruct database and hack it for info over time.

Way to prevent this: Sanitize user input!!!
```
def protected_insert(params)
  statement = "insert into tasks (name, description) values (?, ?)"
  values = [ params[:name], params[:desc]]
  query!(statement, values) #this is why the `*params` is in the query! method
end
```

question marks tell sql to take the info and put it in but with safety procedures in place. In the sqlite gem, ?s represent things that are dubious because they're collected from users.

SQL also protects by disallowing execution of multiple statements in a single string using `execute`. Instead you have to use `execute_batch`, meaning that the developer has to intentionally say that multiple statements are allowed.

Attempts to do sql injection usually show up as errors.

there's also a .prepare method that will Sanitize for you... didn't learn much about it because it isn't what JNF uses. #prepare is a good option tho.

JNF will make his example code available.  
