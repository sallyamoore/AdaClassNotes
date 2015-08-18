# Service-Oriented Architecture (SOA)

What is Software Architecture? How the underlying complexity of any underlying application is structured to make it scalable.

As projects scale, bottlenecks are discovered in code. (E.g., app is now getting more requests and can't handle them.)

Our projects thus far are monoliths; one service (rails) does almost everything. If one thing falls over, everything falls over.

Our current project (shipping service/bEtsy) is less of a monolith. It isolates shipping into its own service, reducing the likelihood that this will become a bottleneck. Consistent with single responsibility, it also makes code more flexible. To the user, bEsty is one thing, but it is actually made up of separate services.

SOA is building a few to many smaller services that each have a single responsibility.

Most developers focus on the trees; software architects think about the forest (so the devs can do their thing).

The other nice thing about this is that you can diversify your stack. You can pick the best language for that one job.

"Microservices" - new buzzword. Idea is that there are still too many dependencies, so make even tinier services. Each thing does a tiny job. But likely has a cost -- higher cognitive load for those who work with it.

# Shipping/bEsty project
Spinning up 2 rails servers
$ rails s => defaults to port 3000
$ rails s -p 3001 => assigns to a specified port
