<?php

function main() {

    $content = json_decode(file_get_contents("content.json"));
    echo $content->message;
    
}

main();