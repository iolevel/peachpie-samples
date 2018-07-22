<?php

use Peachpie\AspNetCore\Mvc\HttpContextExtension as Html;

class User
{
	var $Name = "John";
	var $Address = "Partial Street 123";
}

?>

<?= Html::Partial("_User", new User) ?>