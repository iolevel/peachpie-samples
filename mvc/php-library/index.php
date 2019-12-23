<?php

use Peachpie\AspNetCore\Mvc\HttpContextExtension as Html;

/** the user model object */
class User
{
	/** The user's display name. */
	var $Name = "John";

	/** The user's address. Can be empty! */
	var $Address = "Partial Street 123";
}

?>

<?= Html::Partial("_User", new User) ?>