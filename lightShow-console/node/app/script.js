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

function doA() {
    send('/do-a', function(res){
      document.querySelector('#response').innerHTML = res;
    })
}

function doB() {
    send('/do-b', function(res){
      document.querySelector('#response').innerHTML = res;
    })
}

function status(){
  send('/status', function(res){
    document.querySelector('#status').innerHTML = res;
  })
}

document.querySelector('#doA').addEventListener('click', doA)
document.querySelector('#doB').addEventListener('click', doB)
setInterval(status, 1000);
