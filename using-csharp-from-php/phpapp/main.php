<?php

function demo()
{
    // instantiate C# class:
    $x = new CSharpLib\X;

    // call C# instance method:
    var_dump($x->GetSomething());

    // call C# static method
    var_dump(CSharpLib\X::DoSomething("123")); 
}

demo();