/* Show_Credits.cs
 * Description:     Shows the credits and returns control to the main menu.
 *                  Called by:
 *                      Main_Menu.cs
 *                  Calls:
 *                      Main_Menu.cs
 *                  
 * Created by:      Brandon Bush (ebicastudios@gmail.com)
 * Last Modified:   12/19/2016
 * ExceptionSafety: Undetermined
 * License:         Ebica Studios Closed Source
 */

using UnityEngine;
using System.Collections;

public class Show_Credits : MonoBehaviour {

    float fade_time = 1.0f;                                                             // Factor controlling fade time for the fade functions
    float wait_time = 1.0f;                                                             // Factor controlling wait time for display

    Camera_Controller cam;                                                              // Holds Camera_Controller component for special camera functions (move)
    Global global;                                                                      // Holds Global component for special functions (FadeIn/FadeOut)

    void Awake()                                                                        // Acquire GameObjects, Scripts, and Initialize some variables
    {
        cam = GameObject.Find("Camera").GetComponent<Camera_Controller>();              // Acquire access to the Camera's Camera_Controller
        global = GameObject.Find("Functions").GetComponent<Global>();                   // Acquire access to global functions
    }
    public void Activate()                                                              // Activate the script
    {
        StartCoroutine(run());                                                          // Start CoRoutine
    }
    IEnumerator run()
    {
        cam.move("credits_1");                                                          // Move the camera to credits_1 position
        global.FadeIn("credits_1", fade_time);                                          // Fade In credits screen
        while (global.running_process) { yield return null; }                           // Wait for fade in to finish
        yield return new WaitForSeconds(wait_time);                                     // Wait for display
        global.FadeOut("credits_1", fade_time);                                         // Fade Out credits screen
        while (global.running_process) { yield return null; }                           // Wait for fade out to finish

        cam.move("credits_2");                                                          // Move the camera to credits_2 position
        global.FadeIn("credits_2", fade_time);                                          // Fade In credits screen
        while (global.running_process) { yield return null; }                           // Wait for fade in to finish
        yield return new WaitForSeconds(wait_time);                                     // Wait for display
        global.FadeOut("credits_2", fade_time);                                         // Fade Out credits screen
        while (global.running_process) { yield return null; }                           // Wait for fade out to finish

        cam.move("credits_3");                                                          // Move the camera to credits_3 position
        global.FadeIn("credits_3", fade_time);                                          // Fade In credits screen
        while (global.running_process) { yield return null; }                           // Wait for fade in to finish
        yield return new WaitForSeconds(wait_time);                                     // Wait for display
        global.FadeOut("credits_3", fade_time);                                         // Fade Out credits screen
        while (global.running_process) { yield return null; }                           // Wait for fade out to finish

        cam.move("credits_4");                                                          // Move the camera to credits_4 position
        global.FadeIn("credits_4", fade_time);                                          // Fade In credits screen
        while (global.running_process) { yield return null; }                           // Wait for fade in to finish
        yield return new WaitForSeconds(wait_time);                                     // Wait for display
        global.FadeOut("credits_4", fade_time);                                         // Fade Out credits screen
        while (global.running_process) { yield return null; }                           // Wait for fade out to finish

        cam.move("credits_5");                                                          // Move the camera to credits_5 position
        global.FadeIn("credits_5", fade_time);                                          // Fade In credits screen
        while (global.running_process) { yield return null; }                           // Wait for fade in to finish
        yield return new WaitForSeconds(wait_time);                                     // Wait for display
        global.FadeOut("credits_5", fade_time);                                         // Fade Out credits screen
        while (global.running_process) { yield return null; }                           // Wait for fade out to finish

        cam.move("credits_6");                                                          // Move the camera to credits_6 position
        global.FadeIn("credits_6", fade_time);                                          // Fade In credits screen
        while (global.running_process) { yield return null; }                           // Wait for fade in to finish
        yield return new WaitForSeconds(wait_time);                                     // Wait for display
        global.FadeOut("credits_6", fade_time);                                         // Fade Out credits screen
        while (global.running_process) { yield return null; }                           // Wait for fade out to finish

        string[] fade_what = new string[7];                                             // Need to fade multiple objects. This string array holds these objects
        fade_what[0] = "background_main_menu";                                          // Main Menu Background
        fade_what[1] = "main_cursor";                                                   // Main Cursor
        fade_what[2] = "new_game";                                                      // New Game Option
        fade_what[3] = "load_game";                                                     // Load Game Option
        fade_what[4] = "settings";                                                      // Settings Option
        fade_what[5] = "credits";                                                       // Credits Option
        fade_what[6] = "exit";                                                          // Exit Option

        cam.move("background_main_menu");                                               // Move the Camera to the Main Menu Screen position
        global.FadeIn(fade_what, fade_time);                                            // Fade in the Main Menu, Main Cursor, and Options
        while (global.running_process) { yield return null; }                           // Wait until the fade in is finished
        GameObject.Find("Functions").GetComponent<Main_Menu>().enabled = true;          // Turn over control to the Main Menu
        yield return null;
    }

}
