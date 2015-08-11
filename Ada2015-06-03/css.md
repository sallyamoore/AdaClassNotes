# Intro to CSS
see https://github.com/Ada-Developers-Academy/daily-curriculum/blob/master/topic_resources/intro-css.md

`selector { property: value; }`

examples of `selectors` - tag in html; e.g., you have a paragraph, p is a `selector`.  

commenting out in CSS */comment here/*

from Dabblet:
body {
  font-family: arial, sans-serif;
  font-size: 14px;    */must have px/*
  padding: 50px;      */padding the body tag/*
}

div {
  background: lemonchiffon; */ colors! Can be RGB, hex values, color words (discouraged). RGB includes an opacity argument as well. http://www.w3schools.com/tags/ref_colorpicker.asp /*
  margin: 0 auto;
  width: 400px;
  padding:20px;
}

h1 {
  color:orange;
}

Notice this style.
selector {
  declaration
}

octothorpe means "this is an id"

## The id selector. YOu can assign an id (unique w/in the page) and assign a style block to that id. E.g.,

```
#para1 {
  text-align: center;
  color: #3D3D5C;
}

```
then, in html, label section:
```
<p id="para1">HTML stands for <strong>H</strong>yper <strong>T</strong>ext <strong>M</strong>arkup <strong>L</strong>anguage</p>


```

## the class selector
### selects elements with a specific class attribute

```
.center {
  text-align: center;
  color: red
}

```
## css units
w3schools also has a nice page on CSS units. e.g., in font-size, 2em means 2x the size of the current font while px is the absolute size.  You'll usually see pixels or percentages (% of the page)


## file setup
create a .css file for your style info. A partner to your .html.

## css divide & conquer

### tables
- width/height
- border - size, line type (solid etc), color
- background-image (other background options too)
- border-collapse (removes padding between cells; otherwise, each cell will have a border)
- padding (space around text)

### display

display: type of display
- block - line break before and after element
- inline - keeps objects in the same flow from l to r. e.g., Text wrapped around. Can't change the width of the items (but you can for images)
- inline-block - in same flow, but can define width etc
- none - elements within elements are not displayed

defaults: lists are naturally block elements, images are naturally in the flow of the text.

### margins/padding
see box model

note that width/height sets width/height of contents (padding will add to size of container)

- margins - outside of container
- padding - inside of container

- options:
  - margin - in top right bottom left order, can specify all 4 values separately. one value, all sides equally; two values, top/bottom and l/r (clockwise is the pattern).
  - margin-left
  - margin-right
  - margin-top
  - margin-bottom
  - auto will take remaining space and divide it equally. Will center horizontally, but vertical is a whole nother beast.

resource: css-tricks.com/centering-css-complete-guide

- reset.css or normalize.css - Amira prefers normalize.

### font
websafe fonts! those that most os and browsers recognize. Workaround - use google fonts.

cssfontstack.com - shows all websafe fonts

descending priority - can list font id then class under assumption browser can display that font. If it can't, it'll go down a list and use the next one it can display. So, you can specify one font, this lists a second one after it. e.g.,

```
#cambria {
  font-family: "Cambria", "Georgia";
}
```
for font: you must have style then size, and other elements must follow an order as well.

line-height is one of jnf's fave css options

### links
pseudoclasses

tag:pseudoclass
a tag is anchor.

```
a:link {            # so saying, in a, when there's a link... do this
  color: #999999
  font-size: 150%
}

a:visited {
  color: #ff69b4
}
```

`#fancy:active` is how you'd apply to an id
etc

pseudoclass is applied to certain types of elements
- must go in order: link, visited, hover, active
- unvisited links vs visited links - can specify colors/style
- hover - must come after link and visited

### ordered and unordered lists

```
#one {
  list-style-type: katakana;
}

list-style-position: outside/inside (outside block or inside it)
list-style-type
list-style-image
list-style: position type image (in this order)

other examples: lower-greek, decimal_leading_zero, circle, list-style-image: url("1.png"), circle-inside (circle bullet inside the block)
default is disc

```
