# DevOps - Guest Lecture by Andrew Temlyakov at Amazon
DevOps is a software development method that emphasizes communication and collaboration between devs and QA/test.

System Admin and QA benefit - get to write more code
Devs - less fun :( carry pagers and deal with headaches.

DevOps:
  - promotes ownership
  - devs feel the pain of their code and design decisions when tests and/or systems fail
  - QA/test and Systems Admin understand code base and architecture better
  - more collaboration -- they like each other more.

When devs maintain their systems:
  - they raise exceptions that are more helpful and specific.
  - logging, metrics, and performance become important to them.
  - try to write more optimal code.

With more code knowledge:
  - QA/test can do more precise testing
  - Systems Admin can streamline deployment

Pitfalls:
  - 'problem is now everywhere'
  - At Amazon - SDEs are responsible for testing, infrastructure, and deploying their code; wear pagers. Idea that each team functions like a startup.
  - devs write less code
  - overzealous alarming/monitoring leads to operational hell
  - systems with lots of issues - wind up ignoring alarms when fix is a low priority

DevOps role vs DevOps strategy
  - role usually means building infrastructure to support testing and deployment. Testing role.

Keys to functional DevOps:
  - Devs must design with Ops in mind. Release code ONLY when exceptions are informative.
  - QA must build tests in constant contact with devs. QA makes tests that make devs' lives easier. 
