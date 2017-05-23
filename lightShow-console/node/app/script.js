function send(path, next) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            next(xhttp.responseText);
        }
    };
    xhttp.open("GET", path, true);
    xhttp.send();
}

function status(){
  send('/status', function(res){
    document.querySelector('#status').classList.add('blink');
    setTimeout(function(){
      document.querySelector('#status').classList.remove('blink');
    }, 1000)
  })
}

setInterval(status, 3000);

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
    padVal = this.getAttribute("data-sample");
    send('/'+padVal, function(res){
      console.log(res);
    })
  });
});
