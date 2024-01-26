# BedrollTweaker

I AM NOT CURRENTLY MAINTAINING THIS OR ANY OTHER MOD. PLEASE DO NOT OPEN ISSUES OR CONTACT ME REGARDING THIS OR ANY OTHER MOD.

A mod for The Long Dark    
CHOOSE THE CORRECT MOD VERSION TO MATCH YOUR GAME VERSION      

UPDATED FOR 2.12 / TFTFT BY PHAEDRUS; ADDITIONAL UPDATE BY THE ILLUSION      

## Mod features:
  * Separate settings for standard bedrolls and bearskin bedrolls
  * Adjust the warmth and weight of bedrolls
  * Adjust both the daily decay rate and the on-use decay rate of bedrolls
  * Enable bedrolls to "stack" warmth bonuses
      * In real life, you would be able to use extra bedrolls for additional warmth and use them with beds
      * If you have more than 1 bedroll, you can get extra warmth from the additional bedrolls
      * If you use a bed with 1 or more bedrolls in your inventory, you can get extra warmth from the bedrolls
      * Uses accurate warmth bonuses (not a flat value per bedroll)
      * Options to set how many bedrolls can provide extra warmth and how much warmth they can provide
  * Fully configurable and modular

  ## Limitations:
  * If you change the the warmth, weight or decay of bedrolls while in-game, you will need to change scene (e.g. go outside/inside) to apply the changes.
  * Compatible with [BlanketMod](https://github.com/ds5678/BlanketMod), but only one mod's settings for Bedroll Warmth & Weight will apply.
  * Compatible with [GearDecayModifier](https://github.com/Xpazeman/tld-gear-decay-modifier), but be aware that if you use BOTH to change bedroll decay, the efects are CUMULATIVE. 
      * E.g. set both mods to reduce bedroll decay by 50% and you will overall reduce decay by 75% (50% x 50%). 
      * If you only want Gear Decay Modifier to affect the decay rates, leave the Decay settings in Bedroll Tweaker at 'Unchanged'.
      * If you only want Bedroll Tweaker to affect the decay rates, leave the "Bedrolls decay rate" setting in Gear Decay Modifier at 1.

## Requirements
[MelonLoader](https://github.com/HerpDerpinstine/MelonLoader/releases/latest/download/MelonLoader.Installer.exe)

[ModSettings](https://github.com/zeobviouslyfakeacc/ModSettings/releases)

## Installation:
1. Download ```BedrollTweaker.dll``` from [releases](https://github.com/GruffCassquatch/BedrollTweaker/releases)
2. Drop ```BedrollTweaker.dll``` into your Mods folder
3. If you are updating from an older version, you may need to delete the ```BedrollTweaker.json``` file from your Mods folder as old json's can cause errors if the mod's Settings have been changed.

## Uninstallation:
Delete ```BedrollTweaker.dll``` and ```BedrollTweaker.json``` from your Mods folder

## Using The Mod:
1. Open the ```Options``` menu
2. Open the ```Mod Settings``` menu
3. Scroll across to the ```Bedroll Tweaker``` menu
4. Choose to Enable or Disable the mod
5. Mod Options:
  * Tweak Bedroll Warmth, Weight & Decay: allows you to set the warmth, weight and decay rates of the standard bedroll.
  * Tweak Bearskin Bedroll Warmth, Weight & Decay: allows you to set the warmth, weight and decay rates of the bearskin bedroll.
  * Bedroll Warmth Stacks:
	* Allows you to receive bonus warmth from additional bedrolls in your inventory. 
	* Applies when using a bed or bedroll.
  * Cap number of Bedrolls:
	* Limit the number of bedrolls that can provide extra warmth.
	* Bedroll warmth bonuses are applied from highest to lowest, so you will always be using the best available
  * Cap Total Warmth Bonus:
	* Limit the total warmth bonus you can receive from all extra bedrolls.
  * Partial Warmth Bonus:
	* Choose to only apply a flat percentage of each additional bedroll's warmth.
	* E.g. set to 50%:  1st extra bedroll provides 50% of its warmth, 2nd provides 50%, 3rd provides 50% etc.
	* This setting is applied BEFORE Diminishing Warmth is calculated.
  * Diminishing Warmth Bonus:
	* Choose to apply a diminishing percentage of each additional bedroll's warmth.
	* E.g. set to 10%: 1st extra bedroll provides 90% of its warmth, 2nd provides 80%, 3rd provides 70% etc.
	* This setting is applied AFTER Partial Warmth is calculated.    
5. Click ```CONFIRM``` to apply your changes or ```BACK``` to exit without applying changes

## Feedback, Questions & Troubleshooting
* I am active on [The Long Dark Modding](https://discord.gg/QvFE7VV4WZ) Discord server
	* **General questions and feedback:** post in my channel #cass
	* **Troubleshooting:** 
		* Post in my channel #cass or in #troubleshooting 
		* Or create an issue here on GitHub if you're not on Discord
