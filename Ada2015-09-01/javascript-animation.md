# 3 types of animations in css:

##Transitions

Transitions take a defined css property (e.g., left ofset and top offset in 2048 project)
  .tile {
    transition: all 0.5s ease-in-out;
  }

  Properties of transition:
  - property (any valid css property; i.e., could just change background color, top offset, etc.),
  - transition (how fast, total travel time, does not depend on what happens),
  - easing (formula for change):
    - linear: constant rate of change over time. Feels wooden to users; not organic.
    -  ease-in: Starts slow and accelerates. Linear towards end. Finds constant rate about 50% into animation
    -  ease-out: Starts constant and slows to end. Linear at start. Constant rate until about 50% into animation.
    - ease-in-out: both!

Any css rule can only have 1 css transition. .tile can only be assigned one transition property.

# Keyframes

Can define custom animations for things that aren't always transitionable or for combinations of animations.

```css
.blinker {
  animation: blink 0.5s infinite alternate;
  /* properties
  keyframe name
  duration
  how long
  playback style - beginning, end, alternate */
}

@keyframes blink {
  /* Could also provide a from block. */
  to {
    opacity: 0;
  }
}
```

```css

/*could also alternate some .cell objects... */
.cell:nth-child(even) {
  animation-delay: 0.5s;
}

```

## Transformations
```css
{
  transform: scale(0); /* Change size. Many options! */
}
```

in 2048:
```css
.popper {
  animation: pop 1s;
}

@keyframes pop {
  0% {
    transform: scale(0);
  }

  50% {
    transform: scale(1.2);
  }

  100% {
    transform: scale(1);
  }

}
```


You can also attach this to a javascript event!
```javascript
function pop(tile) {
  $(tile)
  .addClass("popper")
  .on("animationend",
    function() { $(this).removeClass("popper"); }
  );
}
```
