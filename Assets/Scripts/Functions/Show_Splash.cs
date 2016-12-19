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
 * Last Modified:   12/18/2016
 * ExceptionSafety: Undetermined
 * License:         Ebica Studios Closed Source
 */

using UnityEngine;
using System.Collections;

public class Show_Splash : MonoBehaviour {

    public bool debug = false;                                                                                      // If True, Debug mode skips this and heads straight to Main_Menu Control

    // GameObjects and associated scripts
    Transform camera_controller;                                                                                    // Transform component for the camera
    Transform ebica_position;                                                                                       // Transform component for background_splash_ebica
    Transform tools_position;                                                                                       // Transform component for background_splash_tools
    Transform main_menu_position;                                                                                   // Transform component for background_main_menu
    SpriteRenderer ebica_studios;                                                                                   // SpriteRenderer component for background_splash_ebica
    SpriteRenderer tools;                                                                                           // SpriteRenderer component for background_splash_tools
    SpriteRenderer main_menu;                                                                                       // SpriteRenderer component for background_main_menu
    SpriteRenderer new_game;                                                                                        // SpriteRenderer component for new_game
    SpriteRenderer load_game;                                                                                       // SpriteRenderer component for load_game
    SpriteRenderer settings;                                                                                        // SpriteRenderer component for settings
    SpriteRenderer credits;                                                                                         // SpriteRenderer component for credits
    SpriteRenderer exit;                                                                                            // SpriteRenderer component for exit
    SpriteRenderer cursor;                                                                                          // SpriteRenderer component for main_cursor

    public float fade_time = 1.0f;                                                                                  // Float controlling how long the fade time lasts in seconds
    public float wait_time = 2.0f;                                                                                  // Float controlling how long the wait time lasts in seconds

    // Acquire GameObjects and Scripts. Initialize variables.
    void Awake()
    {
        if (!debug)
        {
            camera_controller = GameObject.Find("Camera").GetComponent<Transform>();                                    // Acquire Transform of the camera
            ebica_position = GameObject.Find("background_splash_ebica").GetComponent<Transform>();                      // Acquire Transform of the Ebica splash screen
            tools_position = GameObject.Find("background_splash_tools").GetComponent<Transform>();                      // Acquire Transform of the Tools splash screen
            main_menu_position = GameObject.Find("background_main_menu").GetComponent<Transform>();                     // Acquire Transform of the Main Menu background
            ebica_studios = GameObject.Find("background_splash_ebica").GetComponent<SpriteRenderer>();                  // Acquire SpriteRenderer of the Ebica splash screen
            tools = GameObject.Find("background_splash_tools").GetComponent<SpriteRenderer>();                          // Acquire SpriteRenderer of the Tools splash screen
            main_menu = GameObject.Find("background_main_menu").GetComponent<SpriteRenderer>();                         // Acquire SpriteRenderer of the Main Menu background
            new_game = GameObject.Find("new_game").GetComponent<SpriteRenderer>();                                      // Acquire SpriteRenderer of the New Game option
            load_game = GameObject.Find("load_game").GetComponent<SpriteRenderer>();                                    // Acquire SpriteRenderer of the Load Game option
            settings = GameObject.Find("settings").GetComponent<SpriteRenderer>();                                      // Acquire SpriteRenderer of the Settings option
            credits = GameObject.Find("credits").GetComponent<SpriteRenderer>();                                        // Acquire SpriteRenderer of the Credits option
            exit = GameObject.Find("exit").GetComponent<SpriteRenderer>();                                              // Acquire SpriteRenderer of the Exit option
            cursor = GameObject.Find("main_cursor").GetComponent<SpriteRenderer>();                                     // Acquire SpriteRenderer of the Main Cursor

            Color temp_color;                                                                                           // Temp Color Variable to assign alpha transparencies

            temp_color = ebica_studios.color;                                                                           // Set the Alpha Transparency of the Ebica Studios Splash to 0 (Transparent)
            temp_color.a = 0;
            ebica_studios.color = temp_color;

            temp_color = tools.color;                                                                                   // Set the Alpha Transparency of the Tools Splash to 0 (Transparent)
            temp_color.a = 0;
            tools.color = temp_color;

            temp_color = main_menu.color;                                                                               // Set the Alpha Transparency of the Main Menu Background to 0 (Transparent)
            temp_color.a = 0;
            main_menu.color = temp_color;

            temp_color = new_game.color;                                                                                // Set the Alpha Transparency of the New Game Option to 0 (Transparent)
            temp_color.a = 0;
            new_game.color = temp_color;

            temp_color = load_game.color;                                                                               // Set the Alpha Transparency of the Load Game Option to 0 (Transparent)
            temp_color.a = 0;
            load_game.color = temp_color;

            temp_color = settings.color;                                                                                // Set the Alpha Transparency of the Settings Option to 0 (Transparent)
            temp_color.a = 0;
            settings.color = temp_color;

            temp_color = credits.color;                                                                                 // Set the Alpha Transparency of the Credits Option to 0 (Transparent)
            temp_color.a = 0;
            credits.color = temp_color;

            temp_color = exit.color;                                                                                    // Set the Alpha Transparency of the Exit Option to 0 (Transparent)
            temp_color.a = 0;
            exit.color = temp_color;

            temp_color = cursor.color;                                                                                  // Set the Alpha Transparency of the Main Cursor to 0 (Transparent)
            temp_color.a = 0;
            cursor.color = temp_color;
        }
    }

    void Start()
    {
        Activate();
    }

    // Called by Game Manager Script
    void Activate()
    {
        if (!debug)
        {
            Vector3 camera_position = new Vector3(0, 0, 0);                                                             // Move Camera to the first splash screen position, but pulled back so no clipping occurs.
            camera_position = ebica_position.position;
            camera_position.z = -100f;
            camera_controller.position = camera_position;
        }
        StartCoroutine(showSplash());                                                                               // Start the coroutine to fade in the splash screens. Activate script ends here.
    }

    IEnumerator showSplash()
    {
        if (!debug)
        {
            while (ebica_studios.color.a < 1)                                                                           // Fade-in screen over time determined by fade_time
            {
                Color alpha;                                                                                            // Color variable to adjust the alpha transparency of the screens for fading
                alpha = ebica_studios.color;                                                                            // Get current color value of Ebica Studios Splash
                alpha.a += 1 / 255f;                                                                                      // Add 1/255 to the alpha transparency (255 discreet steps)
                ebica_studios.color = alpha;                                                                            // Assign new alpha channel to Ebica Studios Splash
                                                                                                                        //Debug.Log("Fade Loop Running with alpha value: " + ebica_studios.color.a.ToString());
                yield return new WaitForSecondsRealtime((float)(fade_time / 255.0f - 0.2f));                                   // Wait for the amount of time determined by fade_time divided by 51 steps
            }

            yield return new WaitForSeconds(wait_time);                                                                 // Wait for the amount of time determined by wait_time

            while (ebica_studios.color.a > 0)                                                                           // Fade-in screen over time determined by fade_time
            {
                Color alpha;                                                                                            // Color variable to adjust the alpha transparency of the screens for fading
                alpha = ebica_studios.color;                                                                            // Get current color value of Ebica Studios Splash
                alpha.a -= 1 / 255f;                                                                                      // Subtracts 1/255 to the alpha transparency (255 discreet steps)
                ebica_studios.color = alpha;                                                                            // Assign new alpha channel to Ebica Studios Splash
                                                                                                                        //Debug.Log("Fade Loop Running with alpha value: " + ebica_studios.color.a.ToString());
                yield return new WaitForSecondsRealtime((float)(fade_time / 255.0f - 0.2f));                                   // Wait for the amount of time determined by fade_time divided by 51 steps
            }

            Vector3 position;                                                                                           // Vector used for positioning the camera
            position = tools_position.position;                                                                         // Set position to the location of the tools splash screen
            position.z = -100f;                                                                                         // Pull it back a bit so no clipping occurs
            camera_controller.position = position;                                                                      // Assign new camera position to hover over tools splash screen

            while (tools.color.a < 1)                                                                           // Fade-in screen over time determined by fade_time
            {
                Color alpha;                                                                                            // Color variable to adjust the alpha transparency of the screens for fading
                alpha = tools.color;                                                                            // Get current color value of Ebica Studios Splash
                alpha.a += 1 / 255f;                                                                                      // Add 1/255 to the alpha transparency (255 discreet steps)
                tools.color = alpha;                                                                            // Assign new alpha channel to Ebica Studios Splash
                                                                                                                //Debug.Log("Fade Loop Running with alpha value: " + ebica_studios.color.a.ToString());
                yield return new WaitForSecondsRealtime((float)(fade_time / 255.0f - 0.2f));                                   // Wait for the amount of time determined by fade_time divided by 51 steps
            }

            yield return new WaitForSeconds(wait_time);

            while (tools.color.a > 0)                                                                           // Fade-in screen over time determined by fade_time
            {
                Color alpha;                                                                                            // Color variable to adjust the alpha transparency of the screens for fading
                alpha = tools.color;                                                                            // Get current color value of Ebica Studios Splash
                alpha.a -= 1 / 255f;                                                                                      // Add 1/255 to the alpha transparency (255 discreet steps)
                tools.color = alpha;                                                                            // Assign new alpha channel to Ebica Studios Splash
                                                                                                                //Debug.Log("Fade Loop Running with alpha value: " + ebica_studios.color.a.ToString());
                yield return new WaitForSecondsRealtime((float)(fade_time / 255.0f - 0.2f));                                   // Wait for the amount of time determined by fade_time divided by 51 steps
            }

            position = main_menu_position.position;                                                                         // Set position to the location of the tools splash screen
            position.z = -100f;                                                                                         // Pull it back a bit so no clipping occurs
            camera_controller.position = position;                                                                      // Assign new camera position to hover over tools splash screen

            while (main_menu.color.a < 1)                                                                           // Fade-in screen over time determined by fade_time
            {
                Color alpha;                                                                                            // Color variable to adjust the alpha transparency of the screens for fading
                alpha = main_menu.color;                                                                            // Get current color value of Ebica Studios Splash
                alpha.a += 1 / 255f;                                                                                      // Add 1/255 to the alpha transparency (255 discreet steps)
                main_menu.color = alpha;                                                                            // Assign new alpha channel to Ebica Studios Splash
                                                                                                                    //Debug.Log("Fade Loop Running with alpha value: " + ebica_studios.color.a.ToString());
                yield return new WaitForSecondsRealtime((float)(fade_time / 255.0f - 0.2f));                                   // Wait for the amount of time determined by fade_time divided by 51 steps
            }

            yield return new WaitForSeconds(0.5f);

            while (new_game.color.a < 1)                                                                           // Fade-in screen over time determined by fade_time
            {
                Color[] colors = new Color[6];
                colors[0] = new_game.color;
                colors[1] = load_game.color;
                colors[2] = settings.color;
                colors[3] = credits.color;
                colors[4] = exit.color;
                colors[5] = cursor.color;

                for (int i = 0; i < colors.Length; i++)
                {
                    colors[i].a += 1 / 255f;
                }

                new_game.color = colors[0];
                load_game.color = colors[1];
                settings.color = colors[2];
                credits.color = colors[3];
                exit.color = colors[4];
                cursor.color = colors[5];

                yield return new WaitForSecondsRealtime((float)(fade_time / 255.0f - 0.2f));                                   // Wait for the amount of time determined by fade_time divided by 51 steps
            }
        }
        GameObject.Find("Functions").GetComponent<Main_Menu>().enabled = true;
        Destroy(this);

    }
}
