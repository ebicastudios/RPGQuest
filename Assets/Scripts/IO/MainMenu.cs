using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public bool enabled = false;                            // Enables input from user. Update is not executed if false
    public bool logging = false;

    public void newGame()
    {
        if (logging) { Debug.Log("Calling newGame() in MainMenu.cs - MainMenu UI"); }
    }

    public void loadGame()
    {
        if (logging) { Debug.Log("Calling loadGame() in MainMenu.cs - MainMenu UI"); }
    }

    public void settings()
    {
        if (logging) { Debug.Log("Calling settings() in MainMenu.cs - MainMenu UI"); }
    }

    public void credits()
    {
        if (logging) { Debug.Log("Calling credits() in MainMenu.cs - MainMenu UI"); }
    }

    public void exit()
    {
        if (logging) { Debug.Log("Calling exit() in MainMenu.cs - MainMenu UI"); }
    }

}
