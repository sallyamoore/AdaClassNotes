# Internationalization
i18n - short for Internationalization (i + 18 chars  + n)

Internationalization - providing written text in mult. langs.
Localization - formatting dates, currency, etc. for the specific place

Steps we went through:
# Rails set up - gems, ruby version, install rails.
  - rails new .
  - bundle

# config/locales/en.yml

in file, you'll see:

en:
  hello: "Hello world"

# generate controller & route, write index, touch view.

# in view
<%= t(:hello) %>
t is for translate
uses default (en)

# touch es.yml in same place
es:
  hello: "¡Hola!"

in view:
<h1><%= t(:hello, locale: :es) + " " + @name %></h1>

but if you want whole page to render in diff lang, should be done in controller.

# application controller
```
before_action :set_locale

private

def set_locale
  I18n.locale = params[:locale] || I18n.default_locale
end
```
can provide params to determine location or use default.

# must restart server

now if you go to
http://localhost:3000/?locale=es
you'll see the spanish version
Having language info in url is a good pattern


# fix punctuation diffs (e.g., Spanish !)

view:
<h1><%= t(:hello, name: @name)%></h1>

in en.yml:
en:
  hello: "Hello %{name}!"

# fix the ugly ? in url
in routes:

scope '/:locale' do # way to add param to all routes en masse...
  resources :hello # all routes for this controller
end

in app controller:

def default_url_options(options = {})
  { locale: I18n.locale }.merge options
end

changes default url options so routes respect locales

so if you add
<%= link_to "Hello Index", hello_index_path %>
to view, makes route http://localhost:3000/en/hello

but root path is different. Can't respond to just localhost3000/es.

so, in routes, add this BEFORE ROOT PATH:
get '/:locale' => 'hello#index', as: :switch # pick whatever name you want.

now, you can add this to view:
<%= link_to t(:switch_link, locale: :en), switch_path(locale: :en) %>
<%= link_to t(:switch_link, locale: :es), switch_path(locale: :es) %>
<%= link_to t(:switch_link, locale: :fr), switch_path(locale: :fr) %>

# resources
See rails-practice/i18n-practice
See guides.rubyonrails.org/i18n.html
Jeremy's example:

Jeremy's example also shows localization of dates.
