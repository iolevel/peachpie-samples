<?php

function is_valid_email($text) {
    return (bool)filter_var($text, FILTER_VALIDATE_EMAIL);
}

// function is_valid_url($url) : array {
//     $valid = preg_match('/^((?P<scheme>[^:\/?#]+):)?(\/\/(?P<authority>[^\/?#]*))?(?P<path>[^?#]*)(\?(?P<query>[^#]*))?(#(?P<fragment>.*))?$/', $url, $match);
//     return $valid ? $match : [];
// }