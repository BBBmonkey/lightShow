const fs = require('fs');

function readFile(filename){
    return fs.readFileSync(filename);
}

function pack(){
  var data = '<html>\n\t<head>\n\t\t';
  data += '<meta name="viewport" content="width=device-width, initial-scale=1">';
  data += '\n\t\t<style>\n';
  data += readFile('./app/style.css');
  data += '\n\t\t</style>\n\t</head>\n\t<body>\n';
  data += readFile('./app/body.html');
  data += '\n\t\t<script>\n';
  data += readFile('./app/jquery.min.js');
  data += '\n\t\t</script>\n';
  data += '\n\t\t<script>\n';
  data += readFile('./app/script.js');
  data += '\n\t\t</script>\n\t</body>\n</html>';

  fs.writeFileSync('./index.html', data);
}

pack();
