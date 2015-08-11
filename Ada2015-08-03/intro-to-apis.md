Homework Review - https://zapier.com/learn/apis/#toc ch 1-3
===============

To make a valid request, the client needs to include four things:

  - URL (Uniform Resource Locator)
  - Method
  - List of Headers - part of response
  - Body - part of response

JSON - Javascript object notation - like Javascript. Similar to how we define hashes (but also different - formatting, structure, etc.). Key/value object store. Strict rules of structure/org.

XML - Extensible Markup Language - like html, but you define the tags

5 yrs ago, XML was the standard. Now, JSON is.

Just for data transport. Can be consumed by any language. You don't access the data within these; they are just for transport. These would be deserialize by, for example, ruby.

## Using AdaCooks as an Example
### Recipes
#### JSON
Keys must have double quotes. Colon must be between key and value. Colon right after key. Things at the same level are in {}. Each curly brace pair makes an _object_ (or _node_). Always use strings (b/c usually need strings and no reason to use integers). To use quotes within a string, escape them with \.
```
{
  "id": "1",
  "name": "brownies",
  "description": "yum",
  "preparation": "make these ...",
  "ingredients": [
    {
      "id": "1",
      "name": "chocolate"
    },
    {
      "id": "2",
      "name": "sugar"
    }
  ]
}
```

or
```
{
  "recipe": {
    "id": "1",
    "name": "brownies",
    "description": "yum",
    "preparation": "make these ...",
    "ingredients": [
      {
        "id": "1",
        "name": "chocolate"
      },
      {
        "id": "2",
        "name": "sugar"
      }
    ]
  }
}
```

#### XML:
```
<recipe>
  <id>1</id>
  <name>brownies</name>
  <description>yum</description>
  <preparation>make these</preparation>
  <ingredients>
    <ingredient>
      <id>1</id>
      <name>chocolate</name>
    </ingredient>
    <ingredient>
      <id>2</id>
      <name>sugar</name>
    </ingredient>
  </ingredients>
</recipe>
```
sets of <> and </> (tags) are _nodes_. Node keys (tag names) are user decided, not important to XML.


API 101
=======
https://github.com/Ada-Developers-Academy/daily-curriculum/blob/master/topic_resources/web-api-101.md

# Web API 101
In this lesson we will learn what an api is, the data formats that api's typically use, and how to consume a web api using Ruby.

example: openweathermap.org

## What is an API?
A web api is a programmatic interface to request and deliver data using HTTP. Typically api data is JSON or XML. Most modern web API's use JSON, but plenty of XML api's are still in use. There isn't much difference between an api and the applications we've been making so far, except the responses aren't in HTML and usually the request is not coming from a browser. A few example api's are:

#### Weather API

http://openweathermap.org/API is used for current weather data, forecasting, searching, and weather maps.

- **Documentation**: http://openweathermap.org/API
- **Base URI**: http://api.openweathermap.org/data/2.5/
- **Example**:
    - http://api.openweathermap.org/data/2.5/weather?q=Seattle
    =>
    {"coord":{"lon":-122.33,"lat":47.61},"weather":[{"id":721,"main":"Haze","description":"haze","icon":"50d"}],"base":"cmc stations","main":{"temp":291.69,"pressure":1014,"humidity":60,"temp_min":289.82,"temp_max":294.15},"wind":{"speed":1.5,"deg":170},"clouds":{"all":1},"dt":1438619088,"sys":{"type":1,"id":2949,"message":0.0049,"country":"US","sunrise":1438606203,"sunset":1438659599},"id":5809844,"name":"Seattle","cod":200}
    - http://api.openweathermap.org/data/2.5/forecast?q=Seattle
    - http://api.openweathermap.org/data/2.5/find?q=Seattle&mode=xml
Sidenote on query strings in url: key/values. q is key, value is Seattle. Separate query params with &.

#### Google Books API
The google books api is used to request and information about books.

- **Base URI**: https://www.googleapis.com/books/v1
- **Documentation**: [Google API](https://developers.google.com/books/docs/v1/using)
- **Example**: [https://www.googleapis.com/books/v1/volumes?q=twain](https://www.googleapis.com/books/v1/volumes?q=twain)

Requires an API key for authentication. Most APIs do.

#### Flickr API
Used to retrieve photos by album, collection, user, and search. REQUIRES an API key to even view the info. Each app you make will have its own API key. DON'T PUSH YOUR API KEY TO GITHUB

- **Base URI**: http://api.flickr.com/services/rest/
- **Documentation**: http://www.flickr.com/services/api/
- **Example**: http://api.flickr.com/services/rest/?method=flickr.interestingness.getList&api_key=INSERT_API_KEY_HERE&format=json


Common API usage - authentication, e.g., through facebook etc



Consuming an API with Ruby
==========================
### HTTP isn't just for browsers

Web api's are requested using HTTP, this means that many tools and any programming language can make requests. Ruby has **many** tools to make HTTP requests:

- [HTTParty](http://httparty.rubyforge.org): Super simple, great to use for learning and simple requests
- [Net::HTTP](http://ruby-doc.org/stdlib-2.1.0/libdoc/net/http/rdoc/Net/HTTP.html): Standard Ruby library.
- [Typheous](https://github.com/typhoeus/typhoeus): Advanced functionality such as parallel requests and streaming.

Here is an example of a simple HTTP request using the HTTParty gem.

    require 'httparty'
    r = HTTParty.get("http://amigoingtodie.org")

It's that simple. This HTTP request is exactly the same as a request coming from your browser, a form, link, button, etc...  The return value of the HTTParty `.get` method is an HTTParty instance

    #<HTTParty::Response:0x7fda1db7a238 parsed_response="<html>\n<head>\n  </head>\n  <title> am i going to die?</title>\n<body>...

This instance of HTTParty has methods to access the data from the request:

    r.body    # => Raw response of the HTTP body (the html in this case)
    r.code    # => The numerical code of the response (200)
    r.message # => The text message that corresponds to the code ("OK")
    r.headers # => A hash of data about the request (date, server, content-type)

So HTTParty is a tool to make HTTP requests, but HTML isn't a great way for computers to consume data, typically JSON or XML are used to represent data when it's not being displayed to humans. Let's look at an example of HTTParty with a JSON response:

    r = HTTParty.get("http://api.openweathermap.org/data/2.5/weather?q=Seattle")
    # => <HTTParty::Response:0x7fda1c9e2778 parsed_response={"coord"=>{"lon"=>-122.33, "lat"=>47.61}...

HTTParty will attempt to automatically parse any data that it knows how, it's very good at doing this with JSON

    r.parsed_response
    # => {"coord"=>{"lon"=>-122.33, "lat"=>47.61}, "sys"=>{}}

As you can see the `.parsed_response` returns a ruby `Hash`. HTTParty took the response JSON, and parsed it into ruby. This works similarly with XML.

### Parsing  JSON

When `HTTParty` isn't being used, you would need to parse the JSON using Ruby. Ruby provides a class to parse JSON, the class is called `JSON`, the method to parse is called `.parse`. First let's look at what some JSON looks like:

    '{"person": {"name": "Bookis"}}'

We can see it suspiciously similar to a ruby Hash, but it's wrapped in a String (JSON IS a string). To turn this into a ruby Hash:

    JSON.parse('{"person": {"name": "Bookis"}}')
    # => {"person"=>{"name"=>"Bookis"}}


### Dealing with the data

We've looked at what an api is, how to make a request to it using ruby, and the types of responses you can expect back. Let's look at an example of how we could use this [data](resources/weather.rb).

    require 'httparty' # If using Rails with a Gemfile, this require is not needed
    class Weather
      attr_accessor :city

      def initialize(city)
        @city = city
      end

      #Using HTTParty to get and parse a JSON request
      def current_weather
        HTTParty.get("http://api.openweathermap.org/data/2.5/weather?q=#{city}").parsed_response
      end

      def forecast
        HTTParty.get("http://api.openweathermap.org/data/2.5/forecast?q=#{city}").parsed_response
      end
    end

We can see this class is initialized with a city name, then the instance has two methods to access the weather api:

    seattle = Weather.new("seattle")
    seattle.current_weather
    seattle.forcast

With this class we can now easily use the weather api, the functionality can also be easy to test and extend, and even wrap in a gem to use in multiple projects.

### Practice

Try out a few api's using your browser and the [HTTParty gem](http://httparty.rubyforge.org), I've supplied one example request with each api, try to read through the api and figure out a different action to use:

- [Google Books](https://developers.google.com/books/docs/v1/getting_started)
    - `https://www.googleapis.com/books/v1/volumes?q=<search term>`
- [Open Weather Map](http://openweathermap.org)
    - `http://api.openweathermap.org/data/2.5/forecast?q=<search term>`
- [Meme Generator](http://version1.api.memegenerator.net)
    - `http://version1.api.memegenerator.net/Generators_Search?q=<search term>`
- [IP Address Lookup](http://www.hostip.info/use.html)
    - `http://api.hostip.info/get_html.php?ip=<ip address>`


LiveCode example
=================

1) in gemfile, add 'httparty', then bundle. (restart server)

2) require 'httparty' in Controller

3) create method in controller to retrieve query result and display it in a view.

in weather_controller.rb:
```
WEATHER_URI = "http://api.openweather.map.org/data/2.5/weather?mode=json&units=imperial&"

def city
  @city = params[:city]   # city name is in the route

  # get some weather data
  response = HTTParty.get(WEATHER_URI + "q=#{@city}")
  @current_temperature = response["main"]["temp"]
  @cloud_cover = response["clouds"]["all"]
end

```
could also add a class:

```

class Weather   # where should this go? Likely in model. Could
                # also go in lib. Would need comments and tests
                # to show what it does. Also ok in controller,
                # but only if this is the only one that uses it.
  attr_accessor :current_temperature, :cloud_cover,
  def initialize(city)
    @city = city

  end
end
```

4) Incorporate instance var into view.


.parsed_response makes it a hash.
print JSON.pretty_generate(@response) - make it easier to read (can use in console)


Sidenote: If you get weirdly formatted stuff, try:
JSON.parse(response)["results"]
or add format: :json. Example:
  artists = HTTParty.get(MUSIC_URI + "entity=musicArtist&term=#{@word}", {format: :json})



Endpoint - end of the URI that determines what you hit, what do I provide to users? These are routes for users to access. Some APIs have multiple endpoints.

URI vs URL - URLs refer to webpages (human facing results in a browser), URI specifically refer to data that is restfully routed (a direction). All URIs are URLs; not all URLs are URIs.
