# Intro to databases!
see https://github.com/Ada-Developers-Academy/daily-curriculum/blob/master/topic_resources/database/intro_to_db.md

## persistence - outlives the process that created it.

## popular database paradigms:
 - Relational (RDB): we're focusing here.
 - Document
 - Key-value
 - Object
 - Graph, etc.

## RDB
Widely used, most straightforward to set up.
Structured data organized in tables. Data is stored in rows and columns.

- Schema - representation of the database structure.
- table - collection of closely related columns. Rows vary in column values.
- column - unit of named data in a table with a particular data type.
- row - set of related values for all of the columns declared in a given table.
- primary key - column or group of columns that uniquely identifies a row.
  - can have an autoincrementing identifier that increments with each row (like case number in SPSS)
- foreign key - One or more columns in a table intended to contain only values that match the primary key(s) in the referenced table. (In FarMar, market key in vendor csv is a foreign key)

## SQL - Structured Query Language
see https://github.com/Ada-Developers-Academy/daily-curriculum/blob/master/topic_resources/database/using_sqlite.md

= the language of RDBs
SQL statements - 2 categories:
  - DDL: data definition language. Create, drop (whole table), alter, etc. Changing schema itself, alterations to whole table structure.
  - DML: data manipulation language. Select, insert, update, delete - actions on one row of data.

sqlite3 in terminal - creates mini database that disappears... transient.
sql statements end in a ;
ctrl+D is how you get out of sqlite

sqlite> CREATE TABLE posts (  # create object, it is a table, call it posts
id INTEGER PRIMARY KEY,       # name column id, integer data type, make it
                              # primary key
title TEXT NOT NULL,          # column named title, data type: text, column must  
                              # have a value
body TEXT                     # column named body, data type: text
);

.schema - shows you the schema of the db

### Data Types. (Diff SQLs have different data types. These core types will always exist.)
  - NULL
  - integer
  - real - floating point number
  - text - string
  - blob - large piece of data stored exactly as it was input.

### To see whole table:
```
select * from posts;  # view all columns; substitute column title for * or
                      # multiple columns separated by , to view only some
                      # columns.
```
enter the following to make it look nicer/more helpful
```
.headers on
.mode tabs
select * from posts;
```
### inserting, updating, and deleting a record - see github file.
Insert notes: id automatically defaults to max id plus 1 unless otherwise specified.

Update/delete notes: WHERE keyword is VERY IMPORTANT. If you don't include it, it will override the value for EVERY unit. AHH!

To add a column:
ALTER TABLE posts ADD COLUMN colname INTEGER;

To view top 2 rows:
SELECT * FROM posts LIMIT 2;  # * because you want all columns; limit gives
                              # only the first 2.

can also sort. (but didn't show us how)

SELECT id,title FROM posts;  # just specified columns.
