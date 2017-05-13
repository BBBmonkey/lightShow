const fs = require('fs');

function readFile(filename){
    return fs.readFileSync(filename);
}

function pack(){
  var data = '<html>\n\t<head>\n\t\t<style>\n';
  data += readFile('./app/style.css');
  data += readFile('./app/pure.min.css');  
  data += '\n\t\t</style>\n\t</head>\n\t<body>\n';
  data += readFile('./app/body.html');
  data += '\n\t\t<script>\n';
  data += readFile('./app/script.js');
  data += '\n\t\t</script>\n\t</body>\n</html>';

  fs.writeFileSync('./index.html', data);
}

pack();
