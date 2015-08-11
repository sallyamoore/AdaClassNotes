- pronoucability encourages retention
- will create tool to generate a pronouceable password of any given length based on common letter combinations in English.
- will assess efficiency and attempt to create efficient code.
- 3 hours today, 1 tomorrow, and the weekend.
- due at end of the weekend.

- probability.csv - letter pairs and frequency data
  - pull out pairs, sort so we can grab whatever subset, dial in more and more specifically till you find combos needed
  - possible_next_letters will return an array
  - most_common_next_letter returns the absolute most comomn
  - common_next_letter returns a pseudorandom next letter based on most common ones.


- tuple - pairing of info in an expected pattern
- when you apply an array method on a hash, it converts it into an array

livecode
[1] pry(main)> a = [ 1, 2, 4, 5 ]
=> [1, 2, 4, 5]
[2] pry(main)> a.first
=> 1
[3] pry(main)> a.last
=> 5
[4] pry(main)> a.map { |a| a }
=> [1, 2, 4, 5]
[5] pry(main)> a.map { |a| a + 1 }
=> [2, 3, 5, 6]
[6] pry(main)> a.select { |a| a > 2 }
=> [4, 5]
[7] pry(main)> a.reject { |a| a > 2 }
=> [1, 2]
[8] pry(main)> pairs = [ 'ab', 'ac', 'ad' ]
=> ["ab", "ac", "ad"]
[9] pry(main)> pairs.sort_by { |c| c.chars.last == "c" }
ArgumentError: comparison of FalseClass with true failed
from (pry):9:in `sort_by'
[10] pry(main)> pairs.select { |c| c.chars.last == "c" }
=> ["ac"]
[11] pry(main)> pairs = [ 'ab', 'ac', 'ad', 'bc', 'bd' ]
=> ["ab", "ac", "ad", "bc", "bd"]
[12] pry(main)> b.select { |c| c.chars.first == 'a' }
NameError: undefined local variable or method `b' for main:Object
from (pry):12:in `__pry__'
[13] pry(main)> pairs.select { |c| c.chars.first == 'a' }
=> ["ab", "ac", "ad"]
[14] pry(main)> pairs.select { |c| c.chars.first == 'a' }.select { |c| c.chars.last == 'c' }
=> ["ac"]
[15] pry(main)> pairs = [ { 'ab': 5 }, { 'ac': 8 }, { 'qo': 1 }, { 'ad': 8 }, {'bc': 2 }, { 'bd': 1 } ]
=> [{:ab=>5}, {:ac=>8}, {:qo=>1}, {:ad=>8}, {:bc=>2}, {:bd=>1}]
[16] pry(main)> d = [ { pattern: 'ab', count: 1 } ]
=> [{:pattern=>"ab", :count=>1}]
[17] pry(main)> d.first[:pattern]
=> "ab"
[18] pry(main)> pairs2 = [ { 'ab' => 5 }, { 'ac' => 8 }, { 'qo' => 1 }, { 'ad' => 8 }, {'bc' => 2 }, { 'bd' => 1 } ]
=> [{"ab"=>5}, {"ac"=>8}, {"qo"=>1}, {"ad"=>8}, {"bc"=>2}, {"bd"=>1}]
[19] pry(main)> pairs2.select { |c| c.keys.include('c') }
NoMethodError: undefined method `include' for ["ab"]:Array
from (pry):19:in `block in __pry__'
[20] pry(main)> pairs2.select { |c| c.keys.first == 'ab' }
=> [{"ab"=>5}]
[21] pry(main)> pairs2.select { |c| c.keys == 'ab' }
=> []
[22] pry(main)> pairs2.select { |c| c.keys == ['ab'] }
=> [{"ab"=>5}]
  # NOTE: .keys returns an array, but in line 20 we are searching for a string. As a result, c.keys does not find it. If you put it in an array, however, or call .first on it, it will return the pairs with those keys.
  # .first with .select returns the first item (key) that fits the select
  # here, the ONLY purpose of .first is to make the array into a string. It works b/c each key is unique within the set of hashes, so only finds one. If there's > 1 hash that meets the criteria, it will return all.
[23] pry(main)> { 'ab' => 1, 'bc' => 2, 'qo' => 3 }
=> {"ab"=>1, "bc"=>2, "qo"=>3}
[24] pry(main)> { 'ab' => 1, 'bc' => 2, 'qo' => 3 }['ab']
=> 1
[25] pry(main)> { 'ab' => 1, 'bc' => 2, 'qo' => 3 }.first
=> ["ab", 1]
[26] pry(main)> pairs2.select { |c| c.keys.to_s == 'ab' }
=> []
[27] pry(main)> pairs2.select { |c| c.keys.first == 'ab' }
=> [{"ab"=>5}]
[28] pry(main)> pairs
=> [{:ab=>5}, {:ac=>8}, {:qo=>1}, {:ad=>8}, {:bc=>2}, {:bd=>1}]
[29] pry(main)> c.keys
NameError: undefined local variable or method `c' for main:Object
from (pry):29:in `__pry__'
[30] pry(main)> pairs2.select { |c| c.keys.first == 'qo' }
=> [{"qo"=>1}]
[31] pry(main)> pairs2
=> [{"ab"=>5}, {"ac"=>8}, {"qo"=>1}, {"ad"=>8}, {"bc"=>2}, {"bd"=>1}]
[32] pry(main)> pairs2 << {"ac" => 4}
=> [{"ab"=>5}, {"ac"=>8}, {"qo"=>1}, {"ad"=>8}, {"bc"=>2}, {"bd"=>1}, {"ac"=>4}]
[33] pry(main)> pairs2.select { |c| c.keys.first == 'ac' }
=> [{"ac"=>8}, {"ac"=>4}]

- For assignment, consider whether there is a more efficient way.
- Paul wrote tests for us. These tests tell us how to write the code. If we want to refactor, we would change the test to reflect the new way, then change the code to match.


class PronouceablePassword
  def initialize(probability_corpus)
    @probability_corpus = probability_corpus
  end

  def read_probabilities
  end

  def possible_next_letters
  end

  def most_common_next_letter
  end

  def common_next_letter
  end
end
