MinecraftSharp
==============

Custom Minecraft Launcher

Features
========

Some of these features are Work In Progress

* Allows users to add multiple minecraft accounts
* Offers Obfuscation to protect your minecraft accounts
* Offers Mod Packs from FTB, Tekkit, and ATLauncher
* Has MinecraftSharp.Login, which allows users to add all their accounts, and for premium accounts
* Impossible to bypass encryption, The client uses your username and password to encrypt, And the password are not stored on the computer
* EasyMod, makes it possible to add mods without any knowledge about modding. Just find and add!
* All features you expect from Mojang's patcher is in this patcher
* Allows you to add a tag to your minecraft accounts


Client
======

This will be worked on in the feature

* Direct Game Boosting with Rendar Game Enhancer
* Minecraft# Mod, A mod that boosts fps and reduces ram usage
* Minecraft# Client. This WILL MEAN YOU ARE USING A 100% CUSTOM CLIENT. No java will be used
* Minecraft++, A futureistic minecraft. Coded in c++, for max game performance [It will perform like c#, I am not a pro coder in c++ but I can still do it]
* JarlessM IDE, A IDK (C# IDE To Code C# LOL, I will move it to C++) designed to make it easy to make Minecraft# Mods. Creating a new block will be as easy as:

MinecraftSharp.Mod.Block NewBlock = new MinecraftSharp.Mod.Block();
//The Blocks name
NewBlock.Name = "FireIce";
//A discription for the block
NewBlock.Discription = "A new block that spawns in the neather that is like ice but deals dammage";
//how many hearts will it deal
NewBlock.PlayerPunch = 1;
//IsWearable
NewBlock.IsWearable = false;
//Use NewBlock.Wear = (1:Helm,2:Chest,3:Legs,4:Boots)
//Use NewBlock.Protect.[Helm/Chest/Legs/Boots] = 10000; (How much damage will it reduce from a punch)
NewBlock.Opacity = 0.9 //The opacity of the block
//Id to spawn in block on servers
NewBlock.Id = 156
//2'nd Id if you need to do /i 156:12
NewBlock.SId = 12
//Effects that you want to add
MinecraftSharp.Mod.Effect Effects = MinecraftSharp.Mod.Effect();
List<int> Potions;
Potions.Add(2);//Potion ID
Effects.Potion = Potions
Effects.Dammage = 0.5;
Effects.DammageSecond = 1;//How much time does it take to be killed
NewBlock.Effects = EFfects;

NewBlock.IsFluid = false;//Is is a fluid
//The Texture INDIVIDUAL ONLY PLEASE
NewBlock.TextureTop = "FireIce.Top.Png"
NewBlock.TextureFront = "FireIce.Front.Png";
NewBlock.TextureBottom = "FireIce.Bottom.Png";
NewBlock.TextureLeft = "FireIce.Left.Png";
NewBlock.TextureRight = "FireIce.Right.Png"
NewBlock.TextureBack = "FireIce.Back.Png";

//Where does the block spawn, use 0 for Unspawnable, 1 for overworld, 2 for neather
NewBlock.Spawn = 2;
NewBlock.BlockSpawn = 11;//Where does the block spawn by
NewBlock.SpawnHeight = 0; //0=Bedrock
NewBlock.BreakSpeed = 2; //How fast can you break it 0 means unbreakable
NewBlock.Glow = 0; //How much light does it give off
NewBlock.SilkTouch = true; //Do you need a silkTouch pick to break it
NewBlock.BreakReplace = 11; //If you break it will it drop a block. Use null to say no

MinecraftSharp.Mod.ModBlockControl Mod = new MinecraftSharp.Mod.ModBlockControl;
Mod.Name = "Nether Enhance"
Mod.AddBlock(NewBlock);
