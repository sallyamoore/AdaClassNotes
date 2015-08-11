class Pawn
  attr_reader :position

  def initialize(position) # here, this doesn't get called until the 'new' call below
    @position = position
  end

  # This is the class method, it starts with self.
  # It is only called on the class directly Pawn.make_row
  def self.make_row(side)
    if side == "white"
      num = 2
    else
      num = 7
    end

    ("a".."h").collect do |letter|
      pawn = new("#{letter}#{num}") # instantiates class, position now exists
      puts pawn.position # no instance here because this is a collection not an instance
    end
  end
end

pawns = Pawn.make_row("black") # class method
# => [Pawn.new("a7"), Pawn.new("b7"), ... Pawn.new("h7")]

pawn = Pawn.new("a7") # instance method. Wouldn't use it here, just for demo purposes.
