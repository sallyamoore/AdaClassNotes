require 'benchmark' # to compare methods

# factorial with recursion
def factorial_recursive(num = 0)
 # this is a guard clause
 return "Can not calculate factorial of a negative number" if num < 0

 if num <= 1
   1 # this is our base case
 else
   num * factorial_recursive(num - 1) # this is where the recursion happens
 end
end

# factorial without recursion - our solution

def factorial_iterative(number)
  return "Cannot calculate factorial of 0 or a negative number" if number <= 0

  factorial_count = number

  until factorial_count == 1
    factorial_count -= 1
    number =  number * factorial_count
  end

  return factorial_count

end

# factorial without recursion - another group's solution

def factorial_iter(num)
  return "Cannot calculate factorial of 0 or a negative number" if num <= 0

  result = 1

  until num <= 1
    result *= num
    num -= 1
  end

  return result
end

time_r = 0 # time for recursion
time_i = 0 # time for iteration
fac_i = 0
fac_r = 0

time_i = Benchmark.realtime do
  10.times {fac_i = factorial_iterative(500)}
end

time_i2 = Benchmark.realtime do
  10.times {fac_i2 = factorial_iter(500)}
end

time_r = Benchmark.realtime do
  10.times {fac_r = factorial_recursive(500)}
end

# puts factorial_recursive(500)
# puts factorial_iterative(500)
# puts factorial_iter(500)

puts "time elapsed for recursion: #{time_r * 1000} milliseconds"
puts "time elapsed for iteration: #{time_i * 1000} milliseconds"
puts "time elapsed for iteration2: #{time_i2 * 1000} milliseconds"
