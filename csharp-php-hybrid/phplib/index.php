<?php

require_once './inc/functions.php';
require_once './inc/class-user.php';

(new User("John", "http://example.org", "john@example.org"))->Authenticate();
