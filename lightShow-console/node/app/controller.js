// Pen: http://codepen.io/NateBen/pen/LyXQzV

var volume = {
  in: document.querySelector("input"), // the toggle it self
  out: document.querySelector("output") // the output, shows the volume
};

// Volume change handler
volume.out.value = volume.in.value;
volume.in.addEventListener("change", function() {
  console.log(this.value);
});

// Pads click handler
document.querySelectorAll(".pad").forEach(function(pad) {
  pad.addEventListener("click", function(e) {
    e.preventDefault();
    console.log(this);
  });
});
