# Active record
see https://github.com/Ada-Developers-Academy/daily-curriculum/blob/master/topic_resources/rails/active-record.md

Active record is an Object Relational Mapping technique. Map of a relational database. Way of representing a record in a database. Sets up database connections for us.

Interface between Rails and database.

We represent a model in rails as an instance of a class, which associates with a single record in a db.

example:
`rails generate model student name:string class:string birthday:datetime`
This generates a model (student) with three attributes (name, class, bday). Made 2 files, a model (app/models/student.rb) and a structure for the database through ruby.

.yml - YAML - Yet Another Markup Language - how rails configs connection to db.
  automatically creates 3 environments for connection: development, test, and production

Migration - a mutation of the schema

`rake -T` - list of all tasks rake knows how to do
  - `rake db:setup` catch all for setting up all pieces of db.
  - `rake db:create` create db called db/development.sqlite3 - called development bc not ready for production. This is used in the development environment. Create diff dbs for diff environments (development, testing, and production are typical environments. Staging is also common as an intermediatry bt testing and production). Create assumes you're working in development.
  - `rake db:migrate` - rails looked at our migrations, saw one it hadn't run yet, and ran it. Our migration created a data structure.
  - `rake db:migrate:status` - status of migrations. Shows migrations with id and name. Shows if its "up" -- has it happened? Down = hasn't happened.
  - must use .save to save updated database unless you use .create, which saves automatically
  - .all shows all records.
  - .count, .length (both return number of cases; count is preferred)
  - .order(:attribute) - sort by
  - .where() - Student.where(cohort: "c[2]") - select those that meet criterion
  - reload! - like reracking
Workflow: He typically has rails open in L tab (command is `rails server`), db open in R tab, other tab open in middle.

`rails console` - the irb of rails.

## Commands in Rails (from Rails for Zombies)
table name is lower case & plural version of class name. So, if class is Student, table is called students. Let's say the students table has columns for id, name, cohort, and birthday.

Create - call .new, then alter attributes by calling .attribute (column name). So, `s = Student.new` would make a new student on which you could then say `s.name = SaMo` and `s.birthday = 9/20/1979`.
  Then must call s.save to save new info to db.

  OR you can call .create and it will save automatically

Read - call .find on class, e.g., Student.find(4) would find instance with id of 4.

Update - assign to variable using .find, call .attribute, then .save on the object

Delete - assign to var using .find, then call .destroy on object

- Student.order(:name) - get all students ordered by name

## Back to Active Record
### Naming Conventions
- Model/Class(capitalized singular):  Post    LineItem      Deer
- Table/Schema(plural):               posts   line_items    deers
- Filename (singular lowercase):      post.rb line_item.rb  deer.rb

# Class methods vs instance methods in rails
Methods that pertain to a particular instance of student should be instance methods. Those that pertain to the whole class should be class methods.

# scope method
## Look up scope method in active record querying in guides.rubyonrails.org
```
class Student < ActiveRecord::Base

  # the next line does the same as the method def below. "->" is a special kind of ruby block called a proc. Says create a method that executes the code in {} when you call it. Generates a class method. 
  scope :all_c2_students, -> { where(cohort: "c[2]").order(:name) }

  def self.all_c2_students        # note on when to make it a class
                                  # method: Methods that pertain to a particular instance of student should be instance methods. Those that pertain to the whole class should be class methods.
    where(cohort: "c[2]").order(:name)
  end  
end

```
