# HTTP and other protocols
see https://github.com/Ada-Developers-Academy/daily-curriculum/blob/master/topic_resources/networking.md

Http is a defined architecture. Because we all follow its rules, we can have the internet

## Client/server

Individual clients are not connected. All communication is routed through the server.

(there are other architectures that allow client/client communication)

A server these days is a cloud-based architecture; this means other people's servers in a big collection manage it.

Client - usually means computer, but also phones, atms, watches, other servers... Just means the consumer of the info. (APIs allow disparate servers to talk to each other)

### HTTPS - HTTP over a secure layer with encryption

### FPT, IMAP, SSH... other protocols.


# making an http request
```
Socket.tcp("localhost", 3000) {|sock|
  sock.print "GET / HTTP/1.1\r\n\r\n" # <= the request to GET written in Ruby
  sock.close_write
  puts sock.read
}

```

# Web server
program that knows how to respond to protocol requests (e.g., from HTTP)

# and the corresponding response
HTTP/1.1 200 OK
Content-Type: text/html       # notice that this is a HASH, series of key/values
Server: WEBrick/1.3.1 (Ruby/2.1.2/2014-05-08)
Date: Mon, 22 Sep 2014 19:19:57 GMT
Content-Length: 21
Connection: Keep-Alive

# Lock in upper left next to web address (in Chrome) tells you about security of the https site... Never enter personal info into site w/o https!
