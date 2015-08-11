# fibonnacci is a good example of recursion
require 'colorize'

class FibCounter
  attr_accessor :calls

  def initialize
    @calls = 0 # n of times method was called. To learn about our recursion
  end

  def fib(num) # method to give the nth fibonnacci number
    @calls += 1

    # guard clauses and base case. Would usually explain more.
    return 0 if num == 0
    return 1 if num == 1

    return fib(num - 1) + fib(num - 2) # number in the nth place is sum of preceding 2 numbers

  end
end

class MemoFib       # This is an example of memoizing.
  attr_accessor :calls, :memo_hash

  def initialize
    @calls = 0
    @memo_hash = {
      0 => 0,        # hash with numeric key. Codifies base cases.
      1 => 1,         # Used hash instead of array for clarify (don't have to  track indices)
    }
  end

  def fib(num)
    @calls += 1

    if @memo_hash.has_key?(num)   # guard clause
      return @memo_hash[num]
    end

    @memo_hash[num] = fib(num - 1) + fib(num - 2) # adds 2 fibs to stack. Adds it to the memo_hash. Memo_hash grows and adds to base cases.

  end

end


fibber = MemoFib.new
(1..500).each do |num|
  # fibber.calls = 0
  fib_of_num = fibber.fib(num)
  puts "The Fibonnacci of #{num.to_s.blue} is #{fib_of_num.to_s.green}. We called fib #{fibber.calls.to_s.red} times."
end
