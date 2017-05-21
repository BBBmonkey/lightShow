const fs = require('fs');

function readFile(filename){
    return fs.readFileSync(filename);
}

function pack(){
  var data = '<html><head><meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=0"><style>';
  data += readFile('./app/style.css');
  data += '</style></head><body>';
  data += readFile('./app/body.html');
  data += '<script>';
  data += readFile('./app/ajax.js');
  data += readFile('./app/controller.js');
  data += '</script></body></html>';

  fs.writeFileSync('./index.html', data);
}

pack();
