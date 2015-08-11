module HarryPotter

  class Robe
    def initialize(color)
      @color = color
    end

    def wear
      puts "You wear it so well! #{@color.capitalize} is really a great color on you."
    end
  end

  class Wizard
    def initialize(favorite_color)
      @robe = Robe.new(favorite_color)
    end

    def wear_robe
      @robe.wear
    end
  end

end

# Need to specify module here because we are no longer inside the module.
uni_corn = HarryPotter::Wizard.new("rainbow")
uni_corn.wear_robe

sweet_robe = HarryPotter::Robe.new("glitter")
sweet_robe.wear
