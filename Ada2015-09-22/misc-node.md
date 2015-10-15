# Notes on livecode 2015-09-22
- debugger = like pry for node
- `DB=test npm run setup` -> set up schema and seed (using script) for test db.

Post test using supertest:
```javascript.md
it("can make a post", function(done) {
  agent.post('/movies').set('Accept', application/json)
    .field('title', 'RoboJaws')         // these set up the request.
    .field('release_date', 'tomorrow')

    .expect(200, function(error, result) {
      ...
    });
})
```

## To test post request (informally... not through mocha):
you can't use the browser. Browser always does a get // b/c it's a browser! Curl will let you actually complete the post.
`curl -X POST http://localhost:3000/<rest of path>`

PATCH: a bit different:
