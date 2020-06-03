# ToggleUnits
Script to toggle between mm and Inch units in EPLAN 2.4 and up.

Since version 2.4 of the EPLAN platform, the settings used to toggle the current grid units and to set the 5 grid sizes associated to toolbar button "A" to "E" have changed.

It is now imperative to verify which default units were selected when installing EPLAN, as this changes the name of the settings described above.

This scripts takes care of verifying what default units were selected during install, and use the correct settings name to toggle between Inch and mm.

## Load the script
This script is defined as what I call a "Load" script, because you have to go to

*Utilities > Scripts > Load*

and then go to the folder where the script is located, select the script, and click OK to load it in EPLAN's environment.

A Load script remains in memory. It executes, every time you call its associated menu point.

Instead of a menu point, one could also call the script from a Toolbar Button. As long as the script is loaded in memory, the Action
it defines remains available to the user. In this case, the "ToggleUnitsAction".

In EPLAN, a great many deal of things we do when we interact with it, is actuall call Actions, either built-in Actions defined by the plattform, or user defined Actions like we're doing now.
