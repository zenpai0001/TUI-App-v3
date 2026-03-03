using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui.App;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace TUI_App_v3
{
    public class MainMenu : Runnable<string?>
    {
        public MainMenu()
        {

            
            //Make buttons. btnplay and btnexit. Give them some logic.
            var btnplay = new Button
            {
                Text = "Play",
                X = Pos.Center(),
                Y = Pos.Center()+2,
                Arrangement = ViewArrangement.Fixed
            };
            var btnexit = new Button
            {
                Text = "Exit",
                X = Pos.Center(),
                Y = Pos.Center()+4,
                Arrangement = ViewArrangement.Fixed
            };

            
            Add(btnplay,btnexit);

            btnexit.Accepted += (s, e) => 
            {
                MessageBox.Query((s as View)?.App!, "Exiting game", "Exit successful");
                e.Handled = true;
                App.RequestStop();
            };
            btnplay.Accepting += (s, e) => 
            {
            
            };


        }
    }
}
