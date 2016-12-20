/* Show_Splash.cs
 * Description:     Shows the splash screens. After the built-in Unity
 *                  logo fades out, this script fades in the Ebica
 *                  Studios logo, waits for an amount of time, then
 *                  fades it out, fades in the tools splash screen,
 *                  waits, fades out, fades in to main menu, then
 *                  enables input and turns over control to the
 *                  Main_Menu Script.
 *                  
 * Created by:      Brandon Bush (ebicastudios@gmail.com)
 * Last Modified:   12/19/2016
 * ExceptionSafety: Undetermined
 * License:         Ebica Studios Closed Source
 */

using UnityEngine;
using System.Collections;

public class Show_Splash : MonoBehaviour {

    public bool debug = false;                                                                                          // If True, Debug mode skips this and heads straight to Main_Menu Control

    Camera_Controller camera_controller;                                                                                // Camera_Controller component for special Camera Functions
    Global global;                                                                                                      // Global component for fadeIn/fadeOut Functions

    public float fade_time = 4.0f;                                                                                      // Float controlling how long the fade time lasts
    public float wait_time = 2.0f;                                                                                      // Float controlling how long the wait time lasts

    
    void Awake()                                                                                                        // Acquire GameObjects and Scripts. Initialize variables.
    {
            camera_controller = GameObject.Find("Camera").GetComponent<Camera_Controller>();                            // Acquire Camera_Controller for special camera functions
            global = GameObject.Find("Functions").GetComponent<Global>();                                               // Acquire Global for special functions (fadeIn/fadeOut Scripts)
     }
    void Start()                                                                                                        // Executed upon start of the program (after Awake())
    {
        Activate();
    }
    void Activate()                                                                                                     // Called to activate the script
    {
            StartCoroutine(showSplash());                                                                               // Start the coroutine to fade in the splash screens. Activate script ends here.
    }
    IEnumerator showSplash()                                                                                            // CoRoutine to show the splash screens with wait.
    {
        if (!debug)
        {
            #region EBICA_SPLASH
            camera_controller.move("background_splash_ebica");                                                          // Move the Camera to the Ebica Splash Screen position
            global.FadeIn("background_splash_ebica", fade_time);                                                        // Fade the Ebica Splash In
            while (global.running_process) { yield return null; }                                                       // Wait for the FadeIn on Ebica Splash to finish
            yield return new WaitForSeconds(wait_time);                                                                 // Wait for display time
            global.FadeOut("background_splash_ebica", fade_time);                                                       // Fade the Ebica Splash Out
            while (global.running_process) { yield return null; }                                                       // Wait for the FadeOut on Ebica Splash to finish
            #endregion

            #region TOOLS_SPLASH
            camera_controller.move("background_splash_tools");                                                          // Move the Camera to the Ebica Splash Screen position
            global.FadeIn("background_splash_tools", fade_time);                                                        // Fade the Tools Splash In
            while (global.running_process) { yield return null; }                                                       // Wait for the FadeIn on Tools Splash to finish
            yield return new WaitForSeconds(wait_time);                                                                 // Wait for display time
            global.FadeOut("background_splash_tools", fade_time);                                                       // Fade the Tools Splash Out
            while (global.running_process) { yield return null; }                                                       // Wait for the FadeOut on Ebica Splash to finish
            #endregion
        }
            #region MAIN_MENU
            string[] fade_what = new string[7];                                                                         // Need to fade multiple objects. This string array holds these objects
            fade_what[0] = "background_main_menu";                                                                      // Main Menu Background
            fade_what[1] = "main_cursor";                                                                               // Main Cursor
            fade_what[2] = "new_game";                                                                                  // New Game Option
            fade_what[3] = "load_game";                                                                                 // Load Game Option
            fade_what[4] = "settings";                                                                                  // Settings Option
            fade_what[5] = "credits";                                                                                   // Credits Option
            fade_what[6] = "exit";                                                                                      // Exit Option

            camera_controller.move("background_main_menu");                                                             // Move the Camera to the Main Menu Screen position
            global.FadeIn(fade_what, fade_time);                                                                        // Fade in the Main Menu, Main Cursor, and Options
            while (global.running_process) { yield return null; }                                                       // Wait until the fade in is finished
            #endregion
        
        GameObject.Find("Functions").GetComponent<Main_Menu>().enabled = true;                                          // Turn over control to the Main Menu
        Destroy(this);                                                                                                  // Destroy this object to save on memory
        yield return null;
    }
}
