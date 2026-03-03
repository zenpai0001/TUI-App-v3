using Terminal.Gui;
using System.Text.Json.Serialization;
using TUI_App_v3;
namespace TUIAppv3 
{
    //Make attribute serializable
    public class Program
    {
        //Creating fields to be used regularly
        public int userName;
        public int armorValue;
        public int weaponValue;
        public int level = 0;

        //Create the object
        public Program p = new Program();

        public static void Main()
        {
            LoginMenu.DisplayLoginMenu();
        }
        public void GameOnStart()
        {
            //Game on start. Gonna add some code for this later.
        }
        public void Save()
        {
            //Working on saving a game via JSON deserialization.
        }
        public void Load()
        {
            //Working on loading a game via JSON deserialization.
        }
    }
}