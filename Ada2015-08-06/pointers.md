Pointers - Data Approach

# Basics
========
- What is data?
- meaningful information (e.g., organized, ordered, structured)

- How does data relate to other data? Implicit vs explicit ordering
- What is a data structure?
- What is the connection between elements in a data structure?
- What kind of connections / references are there? Objects, Lists, Trees, Graphs can have different terms.
- Are there connections in ActiveRecord models? How are they defined?

In Ruby: If you have a class object like an Album with attributes (e.g., artist, title), the attributes point to the class object.
  Hashes, relational dbs also use pointers. An id is a pointer, essentially.

In CSS, this would be set up more like an array. It would understand the relationship through its order. Would have set aside space for a fixed size of the attributes.

Implicit vs explicit ordering. Native arrays rely on implicit ordering (inherently ordered; doesn't have to be specified), LinkedLists are explicitly ordered - each element needs to point to the next one; data contains info about the order. Explicit ordering -- kinda like a Choose Your Own Adventure novel.  

  Relational dbs are reliant on explicit and implicit ordering.

    _denormalization_ - moving to a less typically ideal data structure for performance reasonse. E.g., instead of having Comments in its own table separate from Posts, if you always need the first 3, you could denormalize by putting 3 comment columns into your Posts table.

Can also have native arrays that are grouped into a LinkedList. ("Ring buffer?")

# Linked List Impl.
===================
- Use Case - Blog post with comments
- Cannot use one-to-many association to implement comments - all comment look ups are by ID (use find_by_id). Can find ONLY with the id.
- How can we build a list of comments for a blog post with the above restriction?

make it a linked list - post points to its first comment, which points to its second, etc
  - How to denote end? Use a _sentinel_ or use null in table (which would be interpreted as nil by Ruby). A sentinel is a value to denote end, e.g., id 0 because there's no id 0.

- Bonus: Comment iterator, doubly-linked lists, and comment reverse iterator



- Linked Lists Support Interleaved Allocations

The linked list data structure, as opposed to fixed or native arrays, supports "interleaved allocations". If you have multiple linked lists and a large block of memory (an "arena") such as a table in a database, it is possible for all of the lists to share that arena. By using a shared data structure for tracking used memory, each list can grow and shrink independent of the others -- its "memory allocations" can be interleaved with other lists. Native arrays on the other hand, must be discarded and re-allocated in order to grow. This results in significant potential for fragmentation and costly defragmentation procedures.

# Beyond Pointers
=================
- References as the glue that allows data structures to work
- How references work with the web and web APIs.
- How pointers work at the "machine" level.
- Lisp as a language built entirely on linked lists.

Web is one big graph of nodes that point at other nodes! URLs are pointers. 
