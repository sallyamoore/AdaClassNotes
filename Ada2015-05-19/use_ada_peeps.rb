require 'csv'
require 'awesome_print'

# people = [[id,name][1,"Kari"], [2, "Jeremy"], [3, "Crystal"], [4, "Cynthia"]]
# CSV.open("ada_people.csv", "w") do |file|
#   people.each do |person|
#     file << person
#   end
# end

# ada_peeps = CSV.read("ada_people.csv")
# ap ada_peeps

ada_peeps = CSV.open('ada_people.csv', 'r', headers: true).each {|row| ap row}
ap ada_peeps
