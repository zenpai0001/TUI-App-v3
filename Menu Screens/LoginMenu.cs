using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;
using Terminal.Gui.App;
using Terminal.Gui.Configuration;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;
using static System.Net.WebRequestMethods;

namespace TUI_App_v3
{
    public class LoginMenu
    {
       
        public static void DisplayLoginMenu()
        {
            
            //Display the first menu
            Console.Title = "TUIAppV3";

            // Override the default configuration for the application to use the Amber Phosphor theme
            ConfigurationManager.RuntimeConfig = """{ "Theme": "Amber Phosphor" }""";
            ConfigurationManager.Enable(ConfigLocations.All);

            //Instantiate application instance with a using statement
            using (IApplication app = Application.Create().Init())
            {
                var username = app.Run<LoginWindow>().GetResult<string>();
            }
           
        }
        public static void DisplayMainMenu()
        {
            using (IApplication app = Application.Create().Init())
            { 
                //Runs Main Menu app inside the MainMenu class which uses Runnable.
                var MainMenu = app.Run<MainMenu>().GetResult<string>();

                //This will prevent the main menu from suddenly closing. That's my guess.
                app!.RequestStop();
             }
        }
       
        public class LoginWindow : Runnable<string?>
        {
            public string? User_name;
            public LoginWindow()
            {
                Title = $"TUIAppv3 ({Application.QuitKey} to quit)";

                // Create input components and labels
                var usernameLabel = new Label { Text = "Username:"};

                var userNameText = new TextField
                {
                    // Position text field adjacent to the label
                    X = Pos.Right(usernameLabel) + 1,
                    // Fill remaining horizontal space
                    Width = Dim.Fill()
                };
                // Create login button
                var btnlogin = new Button
                {
                    Text = "Login",
                    Y = Pos.Bottom (usernameLabel)+2,
                    X= Pos.Center(),
                    IsDefault = true
                };
                btnlogin.Accepting += (sender, e) => 
                {
                    if(userNameText.Text != "")
                    {
                        //Button login. This will have no password, just a dialog box that will open up.
                        MessageBox.Query(App!, "Logging in", "Successful");
                        Result = userNameText.Text;
                        App!.RequestStop();
                        //Allows for the button to change to the main menu.
                        DisplayMainMenu();
                    }
                    else
                    {
                        MessageBox.ErrorQuery((sender as View)?.App!,"Logging in","No username entered" );
                        Console.Beep();

                    }
                    //This will close the current window and hop on to another window.
                   e.Handled = true;
                   
                };

                Add(userNameText, usernameLabel, btnlogin);
            }
        }
    }
}
