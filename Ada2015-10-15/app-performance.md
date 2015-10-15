See https://github.com/andrewsg/web_app_performance_talk/blob/master/Performance%20presentation.ipynb
# Web application performance and scalability

## What is performance?
Generally, "performance" for a web application is how fast your app serves pages. But there are different ways to measure "fast":
- speed under no load (you may be doing something that's slow no matter how you cut it, like pinging a slow API, or making 1000 separate database calls)
- speed under heavy load (you may have a component in your platform that becomes overloaded under heavy use, like your database)
- speed under specific types of load (it's very common for a site to be very fast showing read-only content but very slow when many people are changing content at once)
- speed with large data sets (some applications handle small amounts of data quickly, but large amounts of data slowly -- that can be linear or it can be exponential)

Many apps will have many pages with no particular performance issues on their own, but a few pages with grave performance issues. For some sites, the most complex and worst-performing pages are the most-used, like a user's timeline. For others, the worst offenders might be infrequently used but high-impact pages; for instance, checkout or account signup on an e-commerce site.

## What is scalability?
Scalability is the ability of your app to use additional resources to handle load, and the overall ability to handle load without failing. For instance, if your app uses a lot of webserver CPU time, you can usually get bigger webservers (scale vertically) or add more webservers under a load balancer (scale horizontally). Even if your app is slow, it can still handle heavy load if you throw enough resources at it.

On the other hand, if your app is taxing a resource that you can no longer increase (for instance, a single database that is as large as you can make it, since you can't usually just add multiple databases to an application and integrate them seamlessly) then you have a scalability problem.

## Don't prematurely optimize
The first thing to remember about performance optimization is when not to do it.

### Code quality comes first
To optimize effectively, you must start with clean, expressive, concise code that fully implements its features.

- Optimizing is easier when your code is clean, just like any process of working with your code is easier when your code is clean.
- Optimizing a feature is impossible if your code does not fully implement the feature, because you won't know the full extent of the problem until the feature is complete, and because the code may have to change as the feature is finished.
- Optimizing may impact the correctness of your code, so tests that verify the correctness are critical.

This does not mean you have to finish your entire app before you work on performance. Performance problems are often localized to specific features. As long as your specific problem features are implemented and clean, you can work on making them faster.

### Don't optimize until you know you have a problem
Sometimes, code is slow because it is actually wrong, which means you can improve the correctness of your code and speed it up at the same time. And sometimes, code is slow because it is too complex, when means that you can improve the quality of your code and speed it up at the same time. But if your app is slow even after your code is correct and beautiful, than optimization may make it less correct and less beautiful.

The more you try to optimize, the more complex the code becomes. Fast is a feature and adding features to code increases complexity. So, don't implement fast, the feature, until you know you need it.

### Don't optimize until you know what the problem is
Since performance optimization often increases code complexity, you should approach slowness like you would approach any other problem: identify it, reproduce it, try to fix it, and roll back your changes if your fix doesn't work. If you take a "shotgun" approach to fixing performance problems, you may introduce a lot more complexity than you need to fix the problem (if you fix it at all).

Try to find out what the problem is exactly, and benchmark it. Benchmarking is very hard because real-world speed of a feature depends on a lot of details about your application's environment, so finding performance issues can be very frustrating. Still, you have to find some way to benchmark the problem, or else you won't know where to start or when you're finished. Fortunately, the bigger the problem is, the easier it is to reproduce and isolate.

## Backend issues
When the problem happens within the request/response cycle, before the browser has received the response, it's a backend issue.

Backend performance issues are often scalability issues, because performance problems on the backend eat up limited resources. Every visitor to a website brings their own frontend resources (i.e. a computer or mobile device with a browser), but they all use the same backend resources.

### Common backend problems
- Too many database requests
- Database reads are too slow or unreliable...
- ... because of joins
- ... because of unindexed sorts or searches
- ... because of frequent cache misses
- ... because the dataset is too large to cache
- Database writes are too slow or unreliable...
- ... because of row locks
- ... because of index updating
- Calls to foreign APIs are...
- ... too numerous
- ... too slow
- Code execution speed/CPU usage
- Anything that touches the disk directly
- Too many unnecessary requests in the first place

### Code execution speed (CPU usage) is rarely a big problem
Web applications generally run on time scales that make code execution speed and CPU usage irrelevant. In other disciplines such as games (which may need to, for instance, update the state of every object in memory 60 times per second) CPU usage is critically important, but web apps tend to have bigger problems.

Ruby, as an interpreted, high-level language with flexible typing, is extremely slow compared to other languages (often by factors of ten, 100, even 1000). Despite that, code execution speed is usually still small potatoes compared to properly slow actions like database queries or API calls.

Also, web server processes are usually scalable both vertically and horizontally, so when you do have execution speed issues, as long as they're not exponential, you may be able to solve them by increasing system resources.

Still, if you use the wrong algorithms to process data, you can still run into code execution speed issues, and sometimes they can even scale exponentially with the size of your data set. For instance, clumsy XML parsing, repeatedly searching large data sets in memory without proper sorting, etc.

### How to diagnose backend issues
- Load testing (ad-hoc with command-line tools like ab, or more comprehensively with cloud tools and interaction scripts)
  - Loadstorm - example of service to simulate concurrent users. Can try out for free.
- Console output in dev mode (turn database query logging on, for instance with ActiveRecord::Base.logger = Logger.new(STDOUT))
  - will spit out line in console with each db query.
- Performance monitoring systems like New Relic
  - new relic - shows performance by task
- Eyeballing the logs or using log parsing tools
- Monitoring system resources with command line tools
- Postgres EXPLAIN ANALYZE and process list (locally or through Heroku pg_extra tools)
    - postgres has detailed debug tools, but they're hard to use.

Other tools
  - google trace
  - asynch requests help if you're querying multiple apis.


### Backend problem examples
Let's set up a database to go over some backend troubleshooting techniques.
This database is stored in memory, which may make a performance tuning demonstration a little awkward since memory operations will be extremely fast. In a real-world web app where the database is in the same data center, but on a different machine from the web server, every individual database query will have a measurable round-trip time (RTT), plus the time it takes to serve the actual request. Additionally, if the database has to hit the disk to serve the request, that can add tens of milliseconds. These costs can quickly add up.


```ruby
require "active_record"
require "sqlite3"
require "benchmark"

ActiveRecord::Base.establish_connection(
  adapter:  'sqlite3',
  database: ':memory:',)

ActiveRecord::Base.logger = Logger.new(STDOUT) # ideally this would output inside the notebook,
                                               # but instead it comes out in the terminal

#We'll define a few simple tables that will illustrate core concepts here.
#Apparently, Rails table definitions do not customarily use foreign keys to express relationships

ActiveRecord::Migration.class_eval do
  create_table :posts do |t|
    t.string :title
    t.text :body
    t.integer :user_id
  end

  create_table :users do |t|
    t.string :username
    t.string :email
  end

  create_table :comments do |t|
    t.integer :post_id
    t.integer :user_id
    t.text :text
  end
end

class User < ActiveRecord::Base
  has_many :posts
  has_many :comments
end

class Post < ActiveRecord::Base
  has_many :comments
  belongs_to :user
end

class Comment < ActiveRecord::Base
  belongs_to :post
  belongs_to :user
end

#Now populate the user and post tables.  Since this is a performance demonstration, we'll make a lot of records.
#This population process itself is a huge performance issue, and will fire over 100000 INSERT requests.
#If it weren't a local, in-memory database it would take a very long time.  Even as it is, it takes several minutes.
#Making this process fast will require bulk inserts -- a standard feature on some ORMs, but not ActiveRecord
#as of yet. So, probably a lot of raw SQL would be required.
(1..100).each do |n|
  User.create username: "User #{n}", email: "#{n}@example.com"
end

User.all.each do |user|
  (1..100).each do |n|
    Post.create user: user, title: "#{user.username}'s post number #{n}", body: "Lorem ipsum, #{user.username}: #{n}"
  end
end

Post.all.each do |post|
  (1..10).each do |n|
    Comment.create post: post, user_id: n, text: "User #{n}'s comment to post #{post.id}"
  end
end

Comment.count

```
(See github notes for full code and output for examples)


## N+1 queries
Here's an example of a common issue in Rails where you have one database read to get a list of objects, but then N database reads to get specifics about those objects.

```ruby
Benchmark.measure do |x|
  Post.all.each do |post| # 1 query (Post.all) to get 10000 rows.
    post.user.username # we're not doing anything with this in this example, but the data will still be read. THIS is where the problem lies. Hidden db call to user table bc username is not already available.
  end
end
```
=>  6.350000   0.170000   6.520000 (  6.582814) # LONG TIME!

Even on an in-memory database, this takes a substantial amount of time to run.

The problem here is that Post.all fetches the list of posts, but peeking at post.user.username additionally fetches the user for each post -- one by one. This example is contrived, but in Rails applications, similar problems can be hard to spot because the list-fetching will probably happen in the controller, but the N individual fetches may happen in the view.

Whenever possible, avoid accessing the database in the view and instead access it in the controller and pass the data into the view. That will make performance troubleshooting more straightforward, as your database calls will be in the same part of your code. The view layer is for presentation, not for reaching out and fetching data from external resources.

In this example, "N+1" equals 10001. Because our example here has such fast (local, in-memory) database access, a large number is necessary to show the problem. In a web application it will be a smaller number, because the initial list you fetch will probably be paginated or limited in some way. However, even if N+1 is more like 51 (and frequently it's really something like 4N+1, because if you have one database call inside a for... each loop, you might have others), in a real web application those calls will have a significant performance penalty because of the round trip time to the production database.

How to improve?
- Make it one call with a join - request list of posts and each user initially (instead of in each loop)
- Without a join, can use `.includes` in Ruby. Tells ruby - fetch lists of posts and, in memory, tally user_ids for each post, get all unique. The includes gets you all the users at once. From N+1 (10001) to 2 requests. Like this:

```ruby
Benchmark.measure do |x|
  Post.all.includes(:user).each do |post|
    post.user.username # we're not doing anything with this in this example, but the data will still be read
  end
end
```
=> 0.590000   0.000000   0.590000 (  0.594021) # MUCH BETTER!

N+1=10001 is now down to 2. One to select all the posts, and one to select all of the users referenced by the posts.

This is actually one more than it could be -- you could offload some of this work to the database and instead make these 2 queries into 1, with a join. However, ActiveRecord idiomatically prefers this style of using includes and multiple calls over joins, unlike many other ORMs. You can still do joins in ActiveRecord, but since you need to specify SQL fragments, they are more trouble than it is worth to eliminate a single database call. You may need to use joins to solve more advanced problems, though.

Whether a join would actually be faster in this case depends on the round trip time among other factors. But the difference in this case will be negligible.

You may notice that the elapsed time as measured by Benchmark is much higher than the elapsed time shown in the database logs. The database is very fast in this example, but a lot of time is spent on ruby code to instantiate objects, only to throw them away. Normally you won't deal with 10000 objects in a request/response cycle, so this is not as big a problem as it might seem.

## Database indexes
When you have a lot of records in your database, it can become very expensive to fetch specific rows or order tables in certain ways. For instance:

Example - when you have a foreign key, you make it an index to improve performance

Like looking up a book in a card catalog. If a set of books is indexed with a #, its easy to look up that way. W/o a card catalog, if you need by title, it takes longer, b/c have to look at each. But in a card catalog, you can have another catalog organized by title, then get # and retrieve book. 2 lookups. Cost is up front -- takes longer to set up.

```ruby
#this is extremely fast
Benchmark.measure do |x|
  Comment.find(50)
  #Comment Load (0.3ms)  SELECT "comments".* FROM "comments" WHERE "comments"."id" = ? LIMIT 1  [["id", 50]]
end
```
=>   0.000000   0.000000   0.000000 (  0.001440)

#this is much slower
```ruby
Benchmark.measure do |x|
  Comment.find_by text: "User 50's comment to post 7841"
  #Comment Load (14.1ms)  SELECT "comments".* FROM "comments" WHERE
  #"comments"."text" = 'User 50''s comment to post 7841' LIMIT 1
end
```
=>  0.020000   0.000000   0.020000 (  0.015858)

```ruby
#this is slower still
Benchmark.measure do |x|
  Comment.order(:text).last
  #Comment Load (62.8ms)  SELECT "comments".* FROM "comments" ORDER BY "comments"."text" DESC LIMIT 1
end
```
=>  0.060000   0.000000   0.060000 (  0.058175)


Even the two "slow" examples may seem fast (14 and 62 ms respectively), but the problem scales with the size of the table, and a real-world database is likely to be slower unless the entire data set is loaded into memory (as opposed to only being available on disk). It does not take very much activity for a website that collects user activity to acquire tables big enough to matter here.

Setting the third example aside, look at the SQL for the first and second example. They are almost identical! Both of them are SELECT queries with single WHERE clauses for a single row. But, the second one takes much longer. The reason is because the first query is against an indexed column, and the second is not. In order to find the correct row in the first example, the database does a binary search on an index; in order to find the row in the second example, the database does a "table scan", an exhaustive search of every row. That's still pretty fast, as it's loaded into memory, but the index query scales as log(n) where the table scan query scales linearly with n.

The id column is indexed because all PRIMARY KEY columns are indexed. More generally, all unique columns (PRIMARY KEY columns being unique) are necessarily indexed, because otherwise the database would need to do a full table scan on each INSERT to check if the insertion violates uniqueness.

We can make the database index the text column, too:

```Ruby
ActiveRecord::Migration.class_eval do
  add_index('comments', 'text')
end
#(194.7ms)  CREATE INDEX "index_comments_on_text" ON "comments" ("text")
```

```Ruby
#Same query, but much faster
Benchmark.measure do |x|
  Comment.find_by text: "User 50's comment to post 7841"
  #Comment Load (0.2ms)  SELECT "comments".* FROM "comments"
  #WHERE "comments"."text" = 'User 50''s comment to post 7841' LIMIT 1
end
```

```Ruby
#An even bigger improvement here
Benchmark.measure do |x|
  Comment.order(:text).last
  #Comment Load (0.2ms)  SELECT "comments".* FROM "comments" ORDER BY "comments"."text" DESC LIMIT 1
end
```

=>  0.000000   0.000000   0.000000 (  0.000491)


All columns that you regularly search, on tables that you expect to get big (>100 rows), should probably be indexed.

There is a cost to each indexing, however: every time you insert or update data in the table, all of the indexes on the table must be updated. This is akin to writing and filing a different index card in every card catalogue in your library every time you file a new book. The process of filing the book becomes very cumbersome. But, as a result, you can search by a number of different methods to find the book later.

There is no point in indexing columns on tables that you do not expect to ever have more than a few hundred rows. The cost of referring to the the index is potentially larger than the cost of checking every row, in which case the database will simply ignore the index at read time.

## Caching and data denormalization¶
Sometimes you need information that you can only obtain in an irreducably slow way. This is common, but also a complex problem.

For instance, perhaps you want to display a list of users ordered by how many comments they have made. You could do it like this:

```Ruby
Benchmark.measure do |x|
  User.select("users.id, users.username, COUNT(comments.id) AS comment_count").
    joins(:comments).order("comment_count DESC").limit(5).each do |u|
    #User Load (33.9ms)  SELECT users.id, users.username, COUNT(comments.id) AS comment_count FROM "users"
    #INNER JOIN "comments" ON "comments"."user_id" = "users"."id" ORDER BY comment_count DESC LIMIT 5
      puts u.username
  end
end # for some reason the output here is not what I expect -- regardless, the correctish query seems to be firing
```

For each user in the table, the database has to individually count the comment rows associated with that user. Then sorts, in-memory, the users by their comment count. This didn't take very long in wall clock time, but the algorithm is very inefficient. As the numbers of users grows, the process slows.

The best solution here is probably to cache your comment count. The fully normalized comment count data is stored in the comments table -- it is the exactly the number of comment rows. But because it's so slow to find that out, you can cache (denormalize) the data by putting it elsewhere, such as a new integer column on the users table.

The problem is that once you put that data elsewhere, it exists in two places, and only one is canonical (the comments table). Any other place you put the comments count in is only a reflection of the true value, and you have to keep it updated whenever you change the canonical data store (again, the comments table). If the two get out of sync, the application could produce inaccurate results.

This is the _cache invalidation_ problem. In this case, the problem is not too bad -- we just update the cache every time we update the comments table. But even that is hard. For instance, it's straightforward to increment the cache, let's call ut User.comment_count, every time you insert a row. But you also have to do so when you delete a row. And when you edit a row and change the user_id field. If you decide later that you want to have a separate comment count ranking that only counts comments over 100 characters long, than that's an easy tweak to the fully normalized query above, but it would require a totally new cache with new code to regulate the cache.

In this specific, very common case, ActiveRecord has a feature called counter_cache that does the dirty work automatically. You can even index the counter_cache for even faster sorts. However, even slightly more complicated caching cases will require a lot of thoughtful code and a lot of careful testing.

This section is necessarily incomplete -- we could write an entire talk on cache invalidation alone. Suffice it to say that caching, say, the results of a slow API query that may change without warning is much harder, and requires some painful tradeoffs between speed and data consistency.

## Other potential backend problem examples
- Rolling result set cache for logged-out views
- Cache and buffer frequent writes (page view counts etc)

tools:
  - memcache
  - redis

## Frontend issues
If the problem happens after the HTTP response is received by the client, for instance before the browser has finished rendering the page, it's a frontend issue.
Frontend issues can be diagnosed with browser dev tools. Issues that are reproducible on all browsers are usually straightforward to diagnose, but some issues only happen on certain platforms, certain browsers, certain mobile devices or resource-constrained clients of any type.
As with all frontend issues, you may eventually have to accept that performance will be poor in certain client circumstances. For instance, modern websites perform poorly when downloaded over a 2G cellular modem, and trying to solve that problem is only worthwhile if mid-'00s mobile devices are truly a target platform for your app.
Common frontend problems:
JS too slow
fragmented statics
too many images
page is too big for browser
browser is slow under load
client network is slow or unreliable
ajax used unnecessarily
Perceived time
User perception is more important than elapsed time
Users want to see something right away, even if it's a placeholder
Big page loads can sometimes be split into multiple requests via AJAX
You can use progress bars, loading icons or even placeholders to excuse slow loads
Configuration issues
New database connection for every request
Blocking vs. asynchronous workers
Too many simultaneous database connections
Not enough memory
Database misconfigured
Worker processes misconfigured
Database simply not big enough


## Questions:
- Postgres - do you need to run db on a different server? Yes, almost always, so that you could spin up a new server at any time (without copying db and resultant complexity). However, for our apps, might not be needed.
