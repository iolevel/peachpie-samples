<html>
<head>
  <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
<?php

class ResourceDemo
{
  public function show() {
    echo "<img src='img/peachpie.png' />";
  }
}

(new ResourceDemo)->show();

?>
</body>
</html>
