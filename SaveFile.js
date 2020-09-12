function FileSaveAs(filename, fileContent) {
  var link = document.createElement('a');
  link.style = "display: none";
  link.download = filename;
  link.href = "data:application/octet-stream;base64," + bytesBase64;
  document.body.appendChild(link);
  link.click();
  document.body.removeChild(link);
}