# Casting a Wider Net
- Guest Lecture by Jeff Lembeck from npm

## How Browsers Work
Densest interview Q ever: what happens when you type an address in a browser?

1.  Find that IP address
DNS - system to make IP addresses more human-friendly.
Cache - checks cache for IP address, then cache in browser
If not there, calls out to ISP (internet svc provider)
If not there, there are 13 "root servers"
  - ISP checks at root server level: {a-m}.root-servers.net
  - Top-level domain (.com, .net, .biz, .edu, .asia)
    - Then searches at domain name level: ns1.nameserver.com. Gets IP address and port! Found!

2. Browser starts HTTP request

Aside: Telnet! In command line:
telnet www.google.com 80
Trying 173.194.33.81...
Connected to www.google.com.
Escape character is '^]'.
GET /index.html HTTP/1.1
host: www.google.com

3. Synchronize/Acknowledge
- back and forth between user and server
- Latency - [Grace Hopper clip on nanoseconds. Awesome.]

Aside: you can use $ traceroute to see path an address takes (`$ traceroute www.google.com`)

4. Response
limited to 14kb per request/response cycle.
TCP/IP - makes sure that if network fizzles in this process, TCP will get stuff that got dropped and piece it together correctly @ response
Response is in HTML.

5. Browser parses HTML
Creates DOM Tree
Grabs resources - CSS files/style tags
Builds CSSOM - CSS object model. Like DOM, this is a tree structure.  
  - Weight, then specificity, then order
    - Specificity - id is most specific, but styling on IDs is pretty brittle. Next level: classes! Next: Tags.
    - Order - what's next in line?

CSS blocks rendering. Page can't be viewed till css loads. Keeping CSS small makes page render faster.
  - positions elements
  - creates layers
  - renders

Javascript
- Parse + execution time
  - compilers - code goes to a Tokeniser, which returns a token. Token is passed through a parser, which returns a syntax tree.  Syntax tree passed through translator. Translator makes it binary. Binary passed through Interpreter, which creates native code for the browser. SLLLOOOOOOW
  - JIT compiler makes slow process only execute when called; makes js faster

Images - don't block rendering! Shows location for it till it loads.

Web Fonts - font sometimes takes time to load bc calling web fonts. Fonts native to the browser will be WAY faster. Safari will wait up to 60s before using the fallback font; in the meantime, page is empty!


TO MAKE FASTER
Asset tree setup
Minify (minifiers are helpful! Uglifier is one example)
gzip - cuts down what you're sending
  - Example: jQuery - 79(?) files! Process makes size MUCH smaller.
Scripts - block parsing!
  - If script is in the body, page is blank until script parses.
  - If script is in the head, page content loads. Or add 'async' or 'defer' to script tag.
Fonts - you can async load fonts!!! Async load everything not critical.
Server-Side rendering - Frontend frameworks build full dom WAY more quickly than browsers do.

Aside - Progressive Enhancement - Development technique. Premise: I want a totally useable page first; all else is secondary. When Javascript fails, page is still useable. Avoid having a "Single Point of Failure" - if this fails, all fails.

# Increasing Access:
REMEMBER: In the rest of the world especially, many people don't have fast internet!

Worldwide mobile browser usage: Chrome: 31%, Safari: 24%, Android: 15%, UC Browser (India & China): 13%, Opera: 11%, IEMobile: 2%

In Africa, Opera is most common (52%)
