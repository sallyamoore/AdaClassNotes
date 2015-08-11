# Merge Sort
# base case: is size > 1 ?
# [4, 8, 3, 20, 9, 14, -2]
# Split list in half recursively
# when size = 1, ready to merge.
# merge with


def mergesort(a)
  # if the array size is 0|1 then the list is considered sorted, return sorted
  return a if a.length <= 1
  # split the list in half => result is 2 arrays
  l, r = split_array(a)
  # merge sort each half
  # mergesort.each do |a|
  #   array = split_array(a)
  # end
  l = mergesort(l)
  r = mergesort(r)
  # combine the sorted halves
  combine(l, r)
end

def split_array(a)
    # find the middle
    mid = a.length / 2
    # take = Returns first n elements from the array.
    # drop = Drops first n elements and returns the rest of the elements.
    # return left and right halves of array as separate arrays
    return a.take(mid), a.drop(mid)
end

# precondition: a and b are sorted. first pass, length = 1, so sorted.
# def combine(a, b)
#   return a if b.empty?
#   return b if a.empty?
#   # puts "a"
#   # print a
#   # puts "b"
#   # print b
#   # create []
#   if a.first <= b.first
#     a << b.first
#     b.shift
#   else
#     b << a.first
#     a.shift
#   end
  #
  # trying without recursion
  # combine(a, b)
  # take a.first and b.first
  # a.first <= b.first, << a.first into []

#   return a if b.empty?
#   return b if a.empty?
#   sorted = []
#   until a.empty? or b.empty?
#     if a.first <= b.first
#       sorted << b.first
#       b.shift
#     else
#       sorted << a.first
#       a.shift
#     end
#   end
#   return sorted
#
# end

# jnf' recursive solution
def combine(a, b)
  return a if b.empty?
  return b if a.empty?

  smallest = a[0] < b[0] ? a.shift : b.shift
  combine(a, b).unshift(smallest)
end

# crystal's
# def combine(a, b)
#   result = []
#
#   small_a = 0
#   small_b = 0
#
#   while small_a < a.length && small_b < b.length do
#     # push smaller elements in
#     if a[small_a] < b[small_b]
#       result.push(a[small_a])
#       small_a += 1
#     else
#       result << b[small_b]
#       result.push(b[small_b])
#       small_b += 1
#     end
#   end
#
#   # if there are leftover elements in a, move them to the result
#   while small_a < a.length do
#     result.push(a)
#     small_a += 1
#   end
#
#   # if leftover elements in b, move to result
#   while small_b < b.length do
#     result.push(b)
#     small_b += 1
#   end
#
#   return result
# end

# TEST IT
a = [6,23,53,1,2,5,62,61,33,21,14,6,23]
a = a.shuffle
puts "ORIGINAL \n" + a.to_s
a = mergesort(a)
puts "AFTER MERGESORT \n" + a.to_s
