# Conditional Validations
See http://guides.rubyonrails.org/active_record_validations.html#conditional-validation

Last week, we discussed basic validations (those rails provides) and custom validations.

You can along create validations that are conditional. Sometimes a validation only makes sense under certain conditions. Below, validating credit card # only makes sense if a cc was used to pay.

# Using a method
Example:
```
class Order < ActiveRecord::Base
  validates :card_number, presence: true, if: :paid_with_card?

  def paid_with_card?
    payment_type == "card"
  end
end
```
here, if accepts a boolean method.

(Don't do the option under section 5.2!!! Inefficient and often not secure.)

# Using a Proc
You can also provide a Proc (a method w/o a name):
```
class Account < ActiveRecord::Base
  validates :password, confirmation: true,
    unless: Proc.new { |a| a.password.blank? }
end
```

Prefer the first option. If it's important enough to wind up in validation, it deserves a method.

This is often used with password management. For example, when the user is editing a different piece of info (i.e., you can edit name and email, but not password), you might not validate the password (again).

## Using > 1 validation in a condition
 JNF says would be better to extract this into a method.
### Grouping conditions
You can also group these.

Here, there are two separate validations witihin an if. They are _grouped_ together.
```
class User < ActiveRecord::Base
  with_options if: :is_admin? do |admin|
    admin.validates :password, length: { minimum: 10 }
    admin.validates :email, presence: true
  end
end
```

Sidenote: .validates method can be called on a var

### Combining conditions
...And you can combine validation conditions, e.g., and if and an unless.
```
class Computer < ActiveRecord::Base
  validates :mouse, presence: true,
                    if: ["market.retail?", :desktop?],
                    unless: Proc.new { |c| c.trackpad.present? }
end
```
