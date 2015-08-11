# CSS with Cheri (teacher applicant)

## Inline vs block elements
inline - next to ea other. Subject to whitespace settings. Ignore top and bottom margin settings; ingnore width & height settings. Will apply l and r margins and padding. If floated L or R, becomes a block-level element. examples - span, sub, img, button, small, input, lable, select

block - whole row. Examples - p, h*, div, article, section, footer, nav, figure

In HTML5, there are more content categories... But mostly folks still just talk about block vs inline.

(inline-block - outside flows, inside behaves as a block?)

## Color units (http://colorpicker.com, http://hslpicker.com)
  - hexidecimal - falling out of favor b/c can't do opacity.
  - RGB, RGBA - RGBA has opacity as 4th #, b/t 0 and 1
  - HSL, HSLA - new! HSLA has opacity (like RGBA), hue (location on color wheel), saturation (0-1), lightness (0-1).

## Size units
  - pixels - absolute
  - percentage - of parent element's size
  - em - equal to the font size of the element, so part responsive and part absolute. Depends on the user's font size. But value of 1 em will differ across the page (e.g., if in an h1 v p)
  - rem - equal to the root font size. Like em but same size no matter where it is on the page.

## Conflicting rules
If there are conflicting styles, browser gives most weight to rules that are more recently defined and ones that are more specific.

## pre tag
used to display code instead of trying to render it

## Box model

## Box model hack!
element { box-sizing: border-box; }
tells browser what should be included in the height and width of the element so that your whole element including margin is the size you specify... rather than needing to add size of img plus margin plus border to get whole element size.

## Selectors
- Limit use of IDs on elements. Instead, use super specific selectors.

### nope:
`#header_image_of_cows`

### yep:
`.image`

Selector types: HTML element name, Class, ID, pseudo-class (e.g., `a:hover`), Pseudo-element (e.g., `li::first-child`, `p::first-letter`), element by attribute (e.g., `a[target="_blank"]`)

## floating
