class Product
  def initialize(name, cost)
    @name = name
    @cost = cost
  end

  def self.all # { |e|  }
    # get all the products
    # returns a collection [] or {} of product instances
  end

end

Product.all 
