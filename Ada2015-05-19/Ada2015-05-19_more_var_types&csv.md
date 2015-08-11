# Random terminology
Munging - transforming something into something else. Munge data to make it presentable. Data wrangling.

Composition - another method of bringing functionality between classes

# Advanced variables
https://github.com/Ada-Developers-Academy/daily-curriculum/blob/master/topic_resources/advanced_variables.md

5 types of vars - local variables, instance variables, class variables (avoid!), global variables (avoid making your own!), and constants

  * local vars note: by convention, start with _ if you don't care about the var but have to declare it bc of syntactic constraints.
  * both classes and modules can have constants. To access constant CEMETARY in Ghost class, `Ghost::CEMETARY`. To access constant CEMETARY in class Ghost in module ScaryThings, `ScaryThings::Ghost::CEMETARY`
  * constants are members of top-level scope if placed at the top of the code. Would be limited to the class unless called if it appeared later.
  * In calculator, would have been useful to use constants for ADDITION etc, set to an array containing containing all accepted aliases.
  * Ruby-defined constants
    * __FILE__ # current file, useful in debug
    * __LINE__ # current line
    * __dir__ # current directory of execution. Lowercase for NO discernable reason.
  * Global vars - Avoid, generally avoid preset ones too. Of presets, the following are more useful: $stderr, $stdin, $stdout  


# CSV Databases

## CSV library in ruby!
Since its in a library, you must use `require 'csv'`

Class methods for CSV:
* read # reads as an array with read-only flag
* open # opens as an array, can write, can start at diff part of file,etc. Takes blocks. Requires at least one argument, filepath. 2nd arg is 'mode', which defaults to read-only.
  * modes will typically create the file if it doesn't exist.
  * watch out!!! w and w+ WILL DELETE THE CONTENTS OF THE FILE (assumes you want to write new stuff.
  * b = binary file mode, e.g., images. You wouldn't use this with CSV.
* Passing a block to open: Ruby will open, slide in file, execute the block, close file.
  * can iterate over each line using the `each` method.

* can set header: true, will then return a hash using headers as keys.
* in csv, everything is a string.

* use .methods to learn more about csv
  * CSV.open('ada_people.csv', 'r', headers: true).each {|row| ap row}
  => shows awesome_print'ed file contents.
