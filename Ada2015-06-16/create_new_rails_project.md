# Step By Step - Create a new Rails project

## 1. Make a directory for the project. For us, this will be through project-forks. If you cloned the branch into project-forks and are in the clone, cd up a level into ONE LEVEL ABOVE the project root.

_Example_
sallymoore:C3Projects--TaskListRails~ 🐙   cd ..
sallymoore:project-forks~ 🐙


## 2. Create Gemset & specify ruby version
$ echo '<GemsetName>' > <ProjectRoot>/.ruby-gemset
$ echo '2.2.2' > <ProjectRoot>/.ruby-version

_Example_
sallymoore:project-forks~ 🐙   echo 'task-list-rails' > C3Projects--TaskListRails/.ruby-gemset
sallymoore:project-forks~ 🐙   echo '2.2.2' > C3Projects--TaskListRails/.ruby-version


## 3. cd back into project root to create gemset

_Example_
sallymoore:project-forks~ 🐙   cd C3Projects--TaskListRails/
ruby-2.2.2 - #gemset created /Users/sallymoore/.rvm/gems/ruby-2.2.2@task-list-rails
ruby-2.2.2 - #generating task-list-rails wrappers..........



## 4. Bundle install your gems  - NOT NEEDED - RAILS DOES THIS FOR YOU!
$ gem install bundler (if not there)


## 5. Install rails into gemset

$ gem install rails --no-rdoc --no-ri

  - to check: $ rvm gemset list

(Note: if you aren't starting from git, you could $ gem init . )

## 6. create new rails project in current folder.
Note: Below, "." means create in current folder, -T means don't use their testing suite.
$ rails new . -T

_Example_
sallymoore:C3Projects--TaskListRails~ 🐙 rails new . -T

### Can also check out .gitignore and add more files (e.g., .DS_Store) to it.

## 6.a. add gems as needed, then $ bundle
- Add better_errors gems to Gemset!!!

## rails generate rspec:install
  - for better formatting, add to .rspec : 
    --format doc

if using pg, will need to bundle without development
## 7. generate controller
$ rails generate controller <nameplural>

_Example_
sallymoore:C3Projects--TaskListRails~ 🐙 rails generate controller tasks

creates task_controller.rb

## 8. add route for first page
routes.rb, e.g., task#index

## 9. add corresponding method to controller
e.g., def index... end

## 10. add a view for this first page.
<name>.html.erb, e.g., index.html.erb

## 11. test in rails server. (if it works, commit!)

## 12. look at layout and change as needed/desired.

# Creating a Form page

## 1. Scaffold! What do you need to collect?

## 2. Create model
$ rails g model <name>
OR
$ rails generate model <name>
g is short for generate

Create db structure here, e.g., :
`rails generate model student name:string class:string birthday:datetime`


3. OR update schema for database in text editor.
  - atom .
  - in db/migrate/<new file with long name>, you will see a class structure with a change method.
  - in change, under create_table, add a line for each table column. Format as follows:
  _Example_
    t.string :task_name, null: false
    t.string :description
    t.string :completed
    t.datetime :date_completed

note: `null: false` disallows missingness for that column.
Specify type in t.xxx. t.string, t.test, t.datetime, etc.

4. Create DB
$ rake db:migrate
Migrate implicitly calls create, so don't need to do that separately.

It will be added to dir db and called "development" by default

5. Check database in sqlite3 if you want to confirm structure
_Example_
sallymoore:C3Projects--TaskListRails~ 🐙   sqlite3 db/development.sqlite3

6. Add route to route.rb
example:
get 'proposals/new' => 'proposals#new'
post 'proposals' => 'proposals#create'

7. Modify controller

8. Create view for page

9. Add link to page (from homepage or wherever)

10. Actually create form

### Use form helper form_for to make some form fields.
- need instance var to represent form.
- Add instance var to controller
e.g.,
```
def new
  @proposal = Proposal.new
end
```

- Add to view:
```
<%= form_for @proposal do |f| %>
<%> end <%>

```

### test in rails server

### create actual substance of form in view.
Example from live code - JNF proposal page for conference.
- In view:
```
<%= form_for @proposal do |f| %>
  <fieldset>
    <legend>Proposal Basics</legend>
    <%= f.label :title %>
    <%= f.text_field :title %>

    <%= f.label :abstract %>
    <%= f.text_field :abstract %>

  </fieldset>

  <fieldset>
    <legend>Proposal Details</legend>
    <%= f.label :length %>
    <%= f.text_field :length %>

    <%= f.label :subject %>
    <%= f.text_field :subject %>

    <%= f.label :intended_audience %>
    <%= f.text_field :intended_audience %>

    <%= f.label :presentation_format %>
    <%= f.text_field :presentation_format %>

    <%= f.label :av_needs, 'AV Needs' %> # to specify label.
    <%= f.text_field :av_needs %>  
  </fieldset>

  <fieldset>
    <legend>Contact Info</legend>
    <%= f.label :name %>
    <%= f.text_field :name %>

    <%= f.label :email %>
    <%= f.email_field :email %>  # special field types!

    <%= f.label :phone %>
    <%= f.phone_field :phone %>
  </fieldset>

  <%= f.submit 'Submit Proposal' %> # don't have to specify title, it will
                                    # autogenerate if you like the default
<%> end <%>
```

11. Define `create` method in controller.  
e.g.,
```
def create
  @proposal = Proposal.new(create_params[:proposal])
  @proposal.save

  render :thank_you  # to go to thank_you page; need a view for this too.
end

private

def create_params
  params.permit(proposal: [:title, :abstract])
end
```
### Need to add permissions to params.
see handwritten notes for 6/18/15
