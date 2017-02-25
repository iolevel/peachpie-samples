<?php

Urho\Desktop\DesktopUrhoInitializer::$AssetsDirectory = '.\Assets';
    
(new class (new Urho\ApplicationOptions("Data")) extends Urho\Application {
    function __construct(Urho\ApplicationOptions $options)
    {
    }

    function CreateLogo() : void
    {
        $cache = $this->ResourceCache;
        $logoTexture = $cache->GetTexture2D("Textures/LogoLarge.png");

        if (empty($logoTexture))
            return;

        $ui = $this->UI;
        $logoSprite = $ui->Root->CreateSprite();
        $logoSprite->Texture = $logoTexture;
        $w = $logoTexture->Width;
        $h = $logoTexture->Height;
        $logoSprite->SetScale(256.0 / $w);
        $logoSprite->SetSize($w, $h);
        $logoSprite->SetHotSpot(0, $h);
        $logoSprite->SetAlignment(Urho\Gui\HorizontalAlignment::Left, Urho\Gui\VerticalAlignment::Bottom);
        $logoSprite->Opacity = 0.75;
        $logoSprite->Priority = -100;
    }

    function Start() : void
    {
        $cache = $this->ResourceCache;
        $helloText = new Urho\Gui\Text();
        $helloText->Value = "Hello from Peachpie & Xamarin";
		$helloText->HorizontalAlignment = Urho\Gui\HorizontalAlignment::Center;
        $helloText->VerticalAlignment = Urho\Gui\VerticalAlignment::Center;
        $helloText->SetColor(new Urho\Color(0.0, 1.0, 0.0));
        $helloText->SetFont($cache->GetFont("Fonts/Anonymous Pro.ttf"), 30);
        $this->UI->Root->AddChild($helloText);

        $this->Graphics->WindowTitle = "Peachpie & Urho Sample";

        $this->CreateLogo();
    }

    function OnUpdate(float $timeStep)
    {
        //MoveCameraByTouches(timeStep);
        parent::OnUpdate($timeStep);
    }
})->Run();
