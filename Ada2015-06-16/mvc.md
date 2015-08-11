# MVC Pattern: Model View Controller
see https://github.com/Ada-Developers-Academy/daily-curriculum/blob/master/topic_resources/resources/intro-to-mvc.md

About division of responsibility, Way of defining responsibilities and their interaction

Esp well-suited to OOP bc focus is on the messages bt objects

3 Jobs:

## 1. The Model
- Models model data.
- Contains data for the app (often linked to a db)
- Contains state of app (e.g., what orders a customer has)
- No knowledge of user interfaces, so it can be reused.
- Think of a model ship or model car. Represents the thing; doesn't do the thing. Represents the data layer.

Provides a Ruby representation of that data.

Provides persistence layer.

If you post a form to create a new task (in TaskList), model would create the task.

## 2. The View
- Generates the user interface that presents data to the user. Human understandable representation
- Passive! Does NOT do ANY processing. Just shows things.
- View's work is done once the data is displayed to the user.
- Many views can access the same model for different reasons.
- In rails, functions like a template (ruby actually treats a view as an object... meaning it can process stuff)

## 3. The Controller
- Receives events from the outside world (e.g., from views)
- interacts with the model. Doesn't know how to do the model, knows how to interact with the model.
- Determine next step in the process flow
- Often responsible for notifying the View of state changes.
- Step-by-step instructions about how to complete a task.

See graphic!!!

---------------------------
| Browser -> Rails Router -> Rails controllers
|
| Controllers <-> views
| Controllers <-> models
|
| => Response -> Browser
---------------------------

(Browsers do little... except that they do CSS)

Many frameworks follow this basic patern (django, rails, others)


### Rails adds a lot of formal structure to this process, but we've already been doing it! Now we have names for the parts. 
