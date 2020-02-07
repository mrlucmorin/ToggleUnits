/*
Luc Morin (MRN), STLM Inc., September 2016
http://www.stlm.ca/
Script to toggle EPLAN's grid units between mm and Inch and back.

This code is distributed under GNU GPL v3 license

*/


/*
The following compiler directive is necessary to enable editing scripts
within Visual Studio.

It requires that the "Conditional compilation symbol" SCRIPTENV be defined 
in the Visual Studio project properties

This is because EPLAN's internal scripting engine already adds "using directives"
when you load the script in EPLAN. Having them twice would cause errors.
*/

#if SCRIPTENV
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Scripting;
using Eplan.EplApi.Base;
using Eplan.EplApi.Gui;
#endif

/*
On the other hand, some namespaces are not automatically added by EPLAN when
you load a script. Those have to be outside of the previous conditional compiler directive
*/

using System.Windows.Forms;
using System.IO;

namespace EPLAN_Toggle_Units_Scripts
{

    class ToggleUnits
    {
        //Script entry point
        [Start]
        public void Run()
        {
            Settings set = new Settings();

            //Get the installation type.
            //Will be either "mm" or "inch"
            string InstallTypeSettingName = "STATION.SYSTEM.MasterdataLanguage";
            string InstallType = set.GetStringSetting(InstallTypeSettingName, 0); ;

            if(string.IsNullOrEmpty(InstallType) || (InstallType != "mm" && InstallType != "inch"))
            {
                MessageBox.Show(string.Format("Can't read the {0} setting: ", InstallTypeSettingName));
                return;

            }

            string BaseUnitSettingName = string.Format("USER.EnfMVC.DisplayUnitIDs.{0}.BaseUnit", InstallType);
            string DefaultGridSizeSettingName = string.Format("USER.GedViewer.{0}.DefaultGridSize", InstallType);

            string CurrentUnitSetting = set.GetStringSetting(BaseUnitSettingName, 0);
            if(string.IsNullOrEmpty(CurrentUnitSetting) || (CurrentUnitSetting != "mm" && CurrentUnitSetting != "inch"))
            {
                MessageBox.Show(string.Format("Can't read the {0} setting: {1}", BaseUnitSettingName, CurrentUnitSetting));
                return;

            }

            if (CurrentUnitSetting == "mm")
            {
                set.SetStringSetting(BaseUnitSettingName, "inch", 0);
                set.SetDoubleSetting(DefaultGridSizeSettingName, 12.7, 4);
                set.SetDoubleSetting(DefaultGridSizeSettingName, 6.35, 3);
                set.SetDoubleSetting(DefaultGridSizeSettingName, 3.175, 2);
                set.SetDoubleSetting(DefaultGridSizeSettingName, 1.5875, 1);
                set.SetDoubleSetting(DefaultGridSizeSettingName, 0.3175, 0);
            }
            else if (CurrentUnitSetting == "inch")
            {
                set.SetStringSetting(BaseUnitSettingName, "mm", 0);
                set.SetDoubleSetting(DefaultGridSizeSettingName, 8, 4);
                set.SetDoubleSetting(DefaultGridSizeSettingName, 4, 3);
                set.SetDoubleSetting(DefaultGridSizeSettingName, 2, 2);
                set.SetDoubleSetting(DefaultGridSizeSettingName, 1, 1);
                set.SetDoubleSetting(DefaultGridSizeSettingName, 0.1, 0);

            }
            else
            {
                MessageBox.Show(string.Format("Can't read the {0} setting", CurrentUnitSetting));
                return;
            }

            //Use a Command Line Interpreter to call the Action
            CommandLineInterpreter CLI = new CommandLineInterpreter();

            ActionCallingContext ctx = new ActionCallingContext();
            ctx.AddParameter("Id", "4");
            CLI.Execute("XGedSetGridsizeAction", ctx);

        }
    }
}
