# Filters!
Hook, kinda like a callback, on which you can hang functionality that should happen @ specific times for specific actions.

format = filter_call :name_of_method

## before
### example

```
class ApplicationController < ActionController::Base
  before_action :require_login # filter! Before _every action in every cntrlr_

  private

  def require_login
    unless logged_in?
      flash[:error] = "You must be logged in to access this section"
      redirect_to new_login_url # halts request cycle
    end
  end
end

```
bEtsy project involves building 2 or 3 kinds of users with diff capabilities. Will need to log them in, know what type, and limit actions.

before, after, and around filters.

## around
In the controller, the around_action call puts functionatlity around the method. Like when we yield in a layout, the layout wraps around the yield. In a controller, the around call includes a yield that tells when the action would occur.

### example

```
class ChangesController < ApplicationController
  around_action :wrap_in_transaction, only: :show  # says, for show action
      # only, perform wrap_in_transaction, and yield to show at the yield.

  private

  def wrap_in_transaction
    ActiveRecord::Base.transaction do
      begin
        yield     # will now perform the #show action.
      ensure
        raise ActiveRecord::Rollback
      end
    end
  end
end

```

Also wraps rendering: if yield yielded to action that rendered a view, it would still come back to this action and continue the wrap_in_transaction method. This would NOT happen for a redirect.

Allows you to still use your routes, not have to make a new route from the "yield" point.

If you need a before and an after that are interdependent, an around would be the best solution.

# after
Typically used when you need to do something not specifically related to the user flow. E.g., reporting features. If you put them earlier, could slow user experience.

# only and except
do <action> only with certain actions or except with certain actions

# skip_before_action
in this controller, skip the before action in this scope. JNF hates this option. IF you need to skip, action prob shouldn't be in your top-level controller.

# LIVECODE
## update routes to capture login/logout process.
- delete route requires an ID. Doesn't work with logout! No id anymore!
- note: you can test routes in your console.
$ app.logout_path
$ app.logout_url

```
# Better
get    "/login",  to: 'sessions#new', as: 'login'
post   "/login",  to: 'sessions#create'
delete "/logout", to: 'sessions#destroy', as: 'logout'
```
now can use logout_path in the view.

## Sidenote: PREFER links to buttons!!!

## Sidenote: Creating users in the console:
$ jeremy = User.new(name: '<3Jeremy!', email: "jeremy@fancy.guy")
$ jeremy.password = jeremy.password_confirmation = 'tacosauce'
$ jeremy.valid?
$ jeremy.save

## - implement a before_action filter so some actions require auth.
- added before action to the home controller.
  ` before_action :require_login, except: [:index]`

- since you'll prob need to login for other stuff too, put the `require_login` method into the application_controller. Works b/c inheritance.
  ```
  def require_login
    # this should prevent people from seeing stuff if they aren't logged in.
    # know logged in if they have a session connected to an id.
    redirect_to login_path unless session[:user_id]
  end
  ```


- added a route for a new view called `all_about_you`
  ```
  controller :home do
    get :all_about_you
  end

  ```

## More examples:
@user = User.find(params[:id])
if you're doing this a lot, put in a before_action.

diff types of users
- could create session identifier on a "roles" group
```
def require_admin
  redirect_to some_path, flash: { error: MESSAGES[:not_logged_in] } unless session[:user_role] == 'admin'
end
```
not great tho b/c accessible to user.

instead, could have role
```
def
  redirect_to some_path, flash: { error: MESSAGE[:not_logged_in] } unless @user.role == 'admin'
end
```

Note: MESSAGE constants would live in application controller if only used here. If they got chunky, you could just extract to a separate file, messages.rb, and put it in lib. Things in lib are loaded into rails when you spin up the server.
Sadly, didn't work... would have to play w it. 
