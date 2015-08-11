# Algorithms

series of instructions for solving a particular problem (like my various research manuals!).

## Divide & conquer - history, usage, implementation (in pseudocode/visual), speed/complexity (big O?)
### Merge Sort
Created in 1945, one of the first methods for computer sorting. Divide & conquer strategy.

Divide in half until down to single unit.
Compare neighbors.
Sort within pairs.
Compare first place in one pair to adjacent pair and merge.
Do this recursively (now adding back symmetrically to how initially divided)
Get to 2 lists, then merge

Reliable, but not that efficient
Big o - n^(log n)

### Bubble Sort
compares 2 things at a time at beginning of list moving through to end
Repeat

Needs as much space as the object/list itself, no more. That's the one benefit.

Big O n^n - very cumbersome. Ok it your list is already almost sorted.

### Binary Search
Guess a number between 0 & 100 with only 6 guesses

Guess the midpoint each time, then half again. Start with a list that is sorted. You are looking for a value in that list. Keep cutting list in half each time.

Faster than mergesort or bubblesort for this purpose.

Can be used to debug (keep halving code until you find the problem.)
Git bisect - find problem in code through this method.

Machley of ENIAC fame was the first to coin the term.

Limit - must start with sorted list

Big O: log n

### MapReduce - us!
see my drawing. Google coined. Hadoop.

### Dijkstra's Algorithm
Shortest path Algorithm. Created simple transportation map for locations in Amsterdam.

Google maps uses this. Not very efficient because it's a blind search. Greedy algorithm - must do 1 step at at time.

Based on nodes - locations on the street, on passable routes. Constantly evaluating to figure out which would have been the shortest path. Assumes values are all infinity until in gets the info.

Used in internet routing. And versions are used in mapping, but they do it more efficiently.

Has to start over each time -- can't just go back one node and figure from there.

Once it has been through a pair of nodes, will store that info and use it to make the algorithm more efficient int he future.  

### RSA Algorithm
classified till 1997, but 3 people at MIT discovered it in the meantime

encryption using public key and private key. HTTPS uses rsa as part of ssl encryption process.

Public key (__,__)  # usually use huge #s, example with smaller
pick 2 random prime #s    a = 3, b = 11
multiply together         => 33
subtract 1 from each of the orig primes and multiple that together
                          (3-1)(11-1) => 20
choose a co-prime number  7
chose a number that, which multiplied by co-prime, %20 of that = 1
                        _3_ * 7 (% 20) = 1
public key is 7, 33
private key is 3, 33

now for the encryption: say you're encrypting m = 2
2 ^7 % 33 (m to the power of first public key modulo second key) = 29

private key 29 ^3 % 33 = 2 # private key found your number!
  (result of above) to the power of first priv key modulo second key = m
not fast, but secure.



# Computers!
Power of computers is measured in FLOPS, floating point operations per second. 
