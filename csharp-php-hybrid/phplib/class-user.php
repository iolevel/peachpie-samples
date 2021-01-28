<?php

require_once 'functions.php';

/**
 * Our sample user object.
 */
class User
{
    /** User's name */
    protected $name;

    /** User's EMail */
    protected $email;

    /** User's URL */
    protected $url;

    /** Constructs the user object. Throws an exception if parameters are invalid. */
    function __construct(string $name, string $url, string $email) {
        if (!is_valid_email($email))
            throw new Exception("Email is not valid!");
        if (!is_valid_url($url))
            throw new Exception("URl is not valid!");

        $this->name = $name;
        $this->url = $url;
        $this->email = $email;
    }

    function __tostring() {
        return $this->name;
    }

	/**
     * Authenticates the user. Throws an exception in case authentication fails.
     */
    function Authenticate() {
        // TODO: Authenticate user's credentials
		System\Diagnostics\Debug::WriteLine("Hi FROM php !!!");
        echo "$this->name is authenticated";
    }
}