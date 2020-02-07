# ToggleUnits
Script to toggle between mm and Inch units in EPLAN 2.4 and up.

Since version 2.4 of the EPLAN platform, the settings used to toggle the current grid units and to set the 5 grid sizes associated to toolbar button "A" to "E" have changed.

It is now imperative to verify which default units were selected when installing EPLAN, as this changes the name of the settings described above.

This scripts takes care of verifying what default units were selected during install, and use the correct settings name to toggle between Inch and mm.

## Run the script
This script is defined as what I call a "Run" script, because you have to go to

*Utilities > Scripts > Run...*

and then go to the folder where the script is located, select the script, and click OK to run it.

A Run script is does not remain in memory. It executes, and is unloaded at once.

Of course, it could be modified to be loaded permanently so that you call it from a menu or a toolbar button.
