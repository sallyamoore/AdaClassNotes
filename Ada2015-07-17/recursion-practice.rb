def fact(n)
  return 1 if n <= 1
  n * fact(n - 1)
end

# first - what are the patterns? Use concrete numbers.
# fib(1) = 1, fib(2) = 1      # two base cases
# fib(3) = fib(2) + fib(1)
# fib(4) = fib(3) + fib(2)
# fib(n) = fib(n-1) + fib(n-2)   # generalized recursive method
def fib(n)
  return 1 if n == 1
  return 1 if n == 2
  fib(n - 1) + fib(n - 2)
end

# pseudocode for Palindrome
# base case: if there's 1 or 0 letters, return true
# base case: if first and last don't match, return false

# if first letter and last letter match,
# => recurse on all but first and last letter => return that result

def pal(s)    # NOTE: Common tech interview question!!!
  return true if s.length <= 1
  return false if s.chars.first != s.chars.last
  # crystal: return false if s[0] != s[s.length-1]
  pal(s[1, s.length - 2])
end

# Factorial Tests
raise "factorial broke - fact(4)" unless fact(4) == 24
raise "factorial broke - fact(0)" unless fact(0) == 1

# Fibanocci Tests
raise "fib broke - fib(8)" unless fib(8) == 21
raise "fib broke - fib(20)" unless fib(20) == 6765
raise "fib broke - fib(1)" unless fib(1) == 1
raise "fib broke - fib(2)" unless fib(2) == 1

# Palindrome Tests
raise "pal broke - pal('racecar')" unless pal("racecar") == true
raise "pal broke - pal('helloworld')" unless pal("helloworld") == false
raise "pal broke - pal('')" unless pal("") == true

puts "All test passed"
