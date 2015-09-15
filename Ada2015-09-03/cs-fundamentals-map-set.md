Data Structures

- Stack
- Queue
- (Native) Array
- Linked List
- Tree - logarithmic by nature.
    * Graph - group of nodes and edges. Tree is one type.
    * Heap - tree w particular properties.
      * max-heap - each parent must be > its children
      * min-heap - each child must be > its parent

- Hash - In general, means you can find data in _constant time_. (Hash in ruby  means something totally diff, more like a map.)
  f(x) = memory address. E.g., Memory address A has an associated data value. To find where that data is, pass through hash function that finds info at that memory process.
  f(x) is a hash function here. Give f(x) a unique identifier and it modifies to get a memory address that is associated with value.

  2 parts to a hash: hash function and hash value. Hash value is the memory address. Function maps the identifier to the memory location.

  Hashing is a mapping of a generic value to a data structure.

  Hash table is the dictionary of keys and values...

  Not ordered.
- Map - Key: value pairs. Unique keys. Ruby hashes are MAPS.
  In Java, there's:
    - hash map - constant time, no order
    - tree map - logarithmic order, but is ordered
- Set - unique data, not inherently ordered (may be given order, e.g., in a tree set)
  In ruby:
  ```ruby
  require 'set'
  s = Set.new
  s.add 12 # => Set: {12}
  s.add 12 # => NOT ADDED AGAIN. Unique values. Set: {12}
  s.add 1  # Set: {12, 1}
  ```
  Used when you need unique values. (Like a map -- or ruby hash -- with only keys).
  - hash set
  - tree set

In sum:
- Ruby Hash isn't a hash to other CS peeps. It's a map.
- Map - key/value pairs
- Tree - logarithmic time, ordered. You'd only pick tree over hash if you must have your data ordered.   
- Hash - constant time, not (necessarily) ordered
- Set - no duplicates

## Implementation vs interface
Hash vs tree = implementation.
  - e.g., hash can be an implementation of map.
Map vs set = interface aka abstraction
  - how you deal with the data. Contract. Rules that data has to follow. 
