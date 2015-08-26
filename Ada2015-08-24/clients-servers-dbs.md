# Clients, Servers, and Databases (George Murray & Dwayne Pryce from Indeed.com)

## Networking Architectures
- Client-server
PC asks for content, webserver sends back content (to same or other PC).
Chat rooms - example of pc to server to other pc

- Peer-to-peer
e.g., napster, bit torrent. Distributed system. PCs act as servers; send info b/t PCs

## Data storage from the server's perspective
Databases help servers manage the volume of requests to edit info.
How do we quickly find a user in a huge db? Use user index, half each time (divide and conquer).

DBs also help manage relationships
  - one to one (one 'about' section per user)
  - one to many (friends)

SQL Fiddle link:  http://goo.gl/tsDnWF

Count litters by species:
```SQL
SELECT COUNT(*), pet.species
FROM pet INNER JOIN event
WHERE pet.name = event.name
AND event.type = 1
GROUP BY pet.species
```

# How DBs help
- Atomicity: All or nothing. Will change all things or none of them; no risk of failure halfway through changing the Data
- Consistency: Data stays in the same structure
- Isolation: Queries can happen at the same time and be handled gracefully
- Durability: Protected against failure (power outages, etc.)

Referred to as ACID; see wikipedia

PC -> Indeed.com -> User service -> User Database Server

(3 servers -- why? If DB server needs to change, less to update. )

But actually, Indeed has MANY servers by location; route to closest data center.

# Sidenotes on Indeed  
~200 devs, Seattle 3rd largest office (Tokyo, Austin). Indeed is owned by Japanese co. ~5 person teams. Resume product is the only one that live in Seattle. May have another by Dec. Intern likely will work on Resume, not sure which team. Driven by metrics. 
