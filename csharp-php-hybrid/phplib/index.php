<?php

include 'functions.php';
include 'class-user.php';
include $a_path_to_a_file;

(new User("John", "http://example.org", "john@example.org"))->Authenticate();
