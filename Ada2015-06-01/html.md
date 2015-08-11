# HTML
Tim Berners-Lee developed HTML at CERN and inadvertantly created the WWW.

  Is html a programming language? Doesn't matter unless you want to invalidate programmers... - Strand via Twitter

- Tag-based programming language. Structural not logical. No conditionals. No dynamic eval of vars.

- LIVECODE!

## Tag based
- all content has tags. Opening tag shown by <>, closing tag shown by </>
  - e.g., heading 1: <h1>Heading</h1>
- JNF rule of thumb: only one h1 per page.
- tag tells browser structural info about content and sets hierarchy to add organization
- Most important purpose is to highlight structural relevance of diff items.

## it is not html's job to control visual presentation. It's job is to control structure.

# HTML divide & conquer

## <li>lists (ol/ul/nav)</li>
nav specifies list of links to navigate to ... see our example.
## <li>anchor (a) & image (img)</li>
  anchor - link to another location, internal or external. a is the code used to specify the target. to ref a webpage <a href="http://www.google.com"> Google Search Page</a>
  An image can also be used as an anchor for your link. No closing tag (weird). The only req'd attribute is source (src). Can also put alt= which specifies what the text would be if the image didn't show up.
  <img src="my image here as url or file on drive" alt="Mt. Rainier" width "400" "300">
  <br> makes a line break. Also does not req a closing tag.

<li>table/thead/tr/th/td/tbody</li>
<table border="1">
thead - table header
th = table head
tr = table row
colspan - how man columns should the cell span?
tbody - body of table
td - table data. For each column.

simple table:
<table>
<tr>
<th>column1</th>
<th>column2</th>
</tr>
</table>


<li>div/section <> p</li>
<div> - holds things you want to _style_ differently. Any time it makes sense to have a section, use a section. Not semantically important. Often used on the backend to organize sections you need to make your code act on but that aren't important to the viewer.
<section> - thematically/semantically organized! Anything with a heading should be a section.
<p> - paragraph, used for lines of text that go together.
all are containers. all are block level elements.


<li>header/footer/article/aside</li>
used to organize your code. they don't format text or move it to specific places. tags for context/robots
article - only things that would be syndicated. RSS feeds use this. Shows this is the part with the article itself.

aside - for a sidebar or similar. related to main flow but not directly part of it. side comment. an aside.

header - used to delineate section you will use as a header

footer - used to delineate a section you will use as a footer.


<li>head/title/meta</li>
head - extra info/reference material for page. Doesn't show. Does not render to page. Provides add/l context, defines char set, requirements, etc.
title - what is shown in google search results, bookmarks, etc. Optimal length 50-60 char
meta - WHat follows the title on your google results. The two line summary. 150-160 characters. If you fail to provide a meta description, it will default to the first couple sentences on your webpage. <meta name="description" content="my content here for my meta"/> For metadata.
og is a tag specific to facebook. means open graph


HOMEWORK
- Make templates and fill these with content.
- Make pages using JUST html. No buttons, no forms, no nothing. (will use to build dynamic sites later)
- Include descriptions of some of the projects we've done here with links to the github pages for thsoe projects... and your thoughts and feelings assoc'd with project.
- Make it function like a website. Home links to about etc.
- Each thing is a separate page.
- 1000 words, ok to fill with loren ipsum.
- will not have its own repo, won't do a pull request.  


 -------
 starting shell for ALL html files.
 header and footer are IN body tag

 <!DOCTYPE html> <!-- b/c several versions of html; this says latest version. see w3schools.com/tags/tag_doctype.asp for how to reference other versions. -->
 <html>
  <head>
  <!-- puts dependencies and files maybe -->
  </head>

  <body> <!-- encapulates everything you want to be displayed -->
    <header>

    </header>


    <footer>

    </footer>
  </body>
</html>
