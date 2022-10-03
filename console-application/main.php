<?php

function main() {

    // \System\Diagnostics\Debugger::Break();

    $content = json_decode(file_get_contents("content.json"));
    echo $content->message;
    
}

main();