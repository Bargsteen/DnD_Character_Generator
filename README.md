# DnD Character Generator

By: Kasper Dissing Bargsteen

## Restoring NuGet packages
I used the NuGet package `Newtonsoft.Json` for generating the JSON, which means that a restore of the packages are necessary before the project works. This can be achieved by:
  - Either running `nuget restore` in a terminal in the project folder,
  - or by using the NuGet package manager in your IDE.

## Notable features
  - The data entered is validated when you try to generate JSON, so the user will be told if he/she forgot to give the character a name or similar (currently, the message simply states that _some_ entries are missing).
  - I used enums for the classes, races etc. and the dropdown values are automatically set in the generic class `DropdownController.cs` based on the enums. This ensures consistency throughout the system.

## Notes
  - My primary focus was the code and design came secondary.
  - I had some issues with the components moving around in an unpredictable manner when using different screen sizes despite them being anchored. I hope it looks fine on your screen as :)
  - I attempted a drag'n'drop solution for the ability scores, where you could choose, which scores that would go to each ability, but there were some issues with the precision of dropping. I therefore decided to drop it for now (pun intended..).

## Attributions
I created all the artwork using Krita.

My singleton implementation was heavily inspired by [this Wiki.Unity3d.com example.](http://wiki.unity3d.com/index.php?title=Singleton&oldid=20231)
