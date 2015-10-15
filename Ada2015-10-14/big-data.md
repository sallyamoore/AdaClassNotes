# Big data
Guest Lecture by Chris from Moz Big Data Team

Three parts (at Moz): Crawling, Scheduling, and Processing
Crawling is hardest - what to crawl on internet??? Have to compensate for a TON of errors. Focus of talk today.
Scheduling - tells crawlers what to crawl. If a site is awful, will tell it not to crawl it again.

robots.txt tells crawlers NOT to crawl that area. BUT some ignore this (e.g., google) and instead have their own processes to ask not to be crawled.

## Crawlers
- Moz has 20 machines (ea with 2 crawlers)
- crawl 850 million pages/day
- crawl cycle = 4 hours
    - machines are staggered to run 6 min out of phase.
    - the 2 crawlers that share a machine are 2 hours out of phase.

## Crawl cycle
- 10 min: get schedule to crawl
- 45: check for robots.txt
- 2:15 crawl and collect data. Save as fast as possible.
- :30 do post-crawl Processing
- :20 Upload data to S3.

## Websites - average lifespan is 40 days!

## Crawler vs spider
Spider - downloads webpage, takes all links, crawls from there.
Crawler - given a set of urls to crawl (at Moz, by scheduler). Don't care what urls on page are.

## Scheduler depends on keywords provided by Moz customers

## Big Data must be resilient to failures!
Monitoring and alarming are critical to big data.
Can set up a crawler with a single command. Same with tearing down a crawler.
Crawlers are designed to fail and stop on error. (Try 10x, then send email and stop)
  - consistency checks on data
  - validate uploads and downloads
  - allows human intervention to fix and restart.

### Monitoring
Automated with Monitoring services (Zabbix, Dataloop, etc) and CRON jobs.
Zabbix usually managed/run by techOps folks. Runs internally.
Dataloop runs through web.  

### Alarms
Alarm when things are starting to go funny, NOT once there's a failure.
Send an 'ok' and turn off alarm if it resolves by itself.
If alarming too often, change alarm levels or improve service.

### Debugging is hard in Big Data.
Build lots of data files that explain the state of the system and learn to use excel to draw graphs.

Lots of log files. Don't always know how to use them UNTIL something goes wrong. Very useful then. Replay logs.

## Processing
Takes last 90 days, sorts, splits, merges across machines. MILLIONS of files.
Designed to fail and not corrupt everything.
Keep stack in a file rather than in memory so it is more resilient. can rewind state of stack manually.

Building a new system based on map/reduce. 
