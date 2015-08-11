# class Chair
#   def style
#     "Vilgot"
#   end
#
#   def weight_in_lbs
#     29
#   end
#
#   def type
#     "Swivel"
#   end
#
#   def color
#     "Black"
#   end
#
#   def max_height_inches
#     23.625
#   end
# end


# #Example 2:
# class Chair
#   def initialize(name, color) #sets parameters that must be passed into the method
#     @name = name
#     @color = color
#   end
#
#   def name # these are called _accessor methods_
#     @name
#   end
#
#   def color
#     @color
#   end
#
#   def name=(new_name) # these are called _reassignment methods_
#     @name = new_name
#   end
#
#   def color=(new_color)
#     @color = new_color
#   end
# end


#Example 3:
class Chair
  attr_reader :name, :color # does what accessor method did above
  attr_writer :name, :color # does what reassignment method did above

  def initialize(name, color) #sets parameters that must be passed into the method
    @name = name
    @color = color
  end

end

#Example 4:
class Chair
  attr_accessor :name, :color # does what accessor method did above

  def initialize(name, color) #sets parameters that must be passed into the method
    @name = name
    @color = color
    @hungry = true # can also add instance vars that are specified as parameters
  end

end
