/* Show_Credits.cs
 * Description:     Shows the credits and returns control to the main menu.
 *                  Called by:
 *                      Main_Menu.cs
 *                  Calls:
 *                      Main_Menu.cs
 *                  
 * Created by:      Brandon Bush (ebicastudios@gmail.com)
 * Last Modified:   12/18/2016
 * ExceptionSafety: Undetermined
 * License:         Ebica Studios Closed Source
 */

using UnityEngine;
using System.Collections;

public class Show_Credits : MonoBehaviour {

    Camera_Controller cam;                              // Gives access to special camera functions

    SpriteRenderer[] screens;                                     // Holds SpriteRenderer of credit screens for fading

    public bool debug = false;

    // Acquire GameObjects and initialize some variables
    void Awake()
    {
        cam = GameObject.Find("Camera").GetComponent<Camera_Controller>();  // Acquire Camera_Controller access
        screens = new SpriteRenderer[6];                        // Initialize screens list to size of $HOW_MANY_SCREENS

        screens[0] = GameObject.Find("credits_1").GetComponent<SpriteRenderer>();        // Acquire SpriteRenderer Components of the credit screens.
        screens[1] = GameObject.Find("credits_2").GetComponent<SpriteRenderer>();
        screens[2] = GameObject.Find("credits_3").GetComponent<SpriteRenderer>();
        screens[3] = GameObject.Find("credits_4").GetComponent<SpriteRenderer>();
        screens[4] = GameObject.Find("credits_5").GetComponent<SpriteRenderer>();
        screens[5] = GameObject.Find("credits_6").GetComponent<SpriteRenderer>();

        Color[] alpha = new Color[6];                                               // Initialize a new color array used to control the initial alpha channels of the screens

        for(int i = 0; i < alpha.Length; i++)                                       // Loop through the arrays and make all the credit screens transparent
        {
            alpha[i] = screens[i].color;                // Set i-th component of alpha to the color of the i-th credit screen
            alpha[i].a = 0;                             // Adjust the alpha value to 0 (transparent)
            screens[i].color = alpha[i];                // Assign the new transparent color to the i-th credit screen;
        }



    }

    public void Activate()
    {
        StartCoroutine(run());
    }

    IEnumerator run()
    {
        if (!debug)
        {
            cam.move("credits_1");
            while (screens[0].color.a < 1)                                                                           // Fade-in screen
            {
                Color alpha;                                                                                            // Color variable to adjust the alpha transparency of the screens for fading
                alpha = screens[0].color;                                                                            // Get current color value of fade_what
                alpha.a += 1 / 255f;                                                                                      // Adds 1/255 to the alpha transparency (255 discreet steps)
                screens[0].color = alpha;                                                                            // Assign new alpha channel to fade_what
                yield return new WaitForSecondsRealtime((float)(2.0 / 255.0f - 0.2f));                                   // Wait
            }

            yield return new WaitForSeconds(2.0f);

            while (screens[0].color.a > 0)                                                                           // Fade-in screen
            {
                Color alpha;                                                                                            // Color variable to adjust the alpha transparency of the screens for fading
                alpha = screens[0].color;                                                                            // Get current color value of fade_what
                alpha.a -= 1 / 255f;                                                                                      // Adds 1/255 to the alpha transparency (255 discreet steps)
                screens[0].color = alpha;                                                                            // Assign new alpha channel to fade_what
                yield return new WaitForSecondsRealtime((float)(2.0 / 255.0f - 0.2f));                                   // Wait
            }

            cam.move("credits_2");
            while (screens[1].color.a < 1)                                                                          // Second credits screen
            {
                Color alpha;
                alpha = screens[1].color;
                alpha.a += 1 / 255f;
                screens[1].color = alpha;

                yield return new WaitForSecondsRealtime((float)(2.0 / 255.0f - 0.2f));

            }
            yield return new WaitForSeconds(2.0f);

            while (screens[1].color.a > 0)
            {
                Color alpha;
                alpha = screens[1].color;
                alpha.a -= 1 / 255f;
                screens[1].color = alpha;
                yield return new WaitForSecondsRealtime((float)(2.0 / 255.0f - 0.2f));
            }

            cam.move("credits_3");
            while (screens[2].color.a < 1)                                                                          // Second credits screen
            {
                Color alpha;
                alpha = screens[2].color;
                alpha.a += 1 / 255f;
                screens[2].color = alpha;

                yield return new WaitForSecondsRealtime((float)(2.0 / 255.0f - 0.2f));

            }
            yield return new WaitForSeconds(2.0f);

            while (screens[2].color.a > 0)
            {
                Color alpha;
                alpha = screens[2].color;
                alpha.a -= 1 / 255f;
                screens[2].color = alpha;
                yield return new WaitForSecondsRealtime((float)(2.0 / 255.0f - 0.2f));
            }

            cam.move("credits_4");
            while (screens[3].color.a < 1)                                                                          // Second credits screen
            {
                Color alpha;
                alpha = screens[3].color;
                alpha.a += 1 / 255f;
                screens[3].color = alpha;

                yield return new WaitForSecondsRealtime((float)(2.0 / 255.0f - 0.2f));

            }
            yield return new WaitForSeconds(2.0f);

            while (screens[3].color.a > 0)
            {
                Color alpha;
                alpha = screens[3].color;
                alpha.a -= 1 / 255f;
                screens[3].color = alpha;
                yield return new WaitForSecondsRealtime((float)(2.0 / 255.0f - 0.2f));
            }

            cam.move("credits_5");
            while (screens[4].color.a < 1)                                                                          // Second credits screen
            {
                Color alpha;
                alpha = screens[4].color;
                alpha.a += 1 / 255f;
                screens[4].color = alpha;

                yield return new WaitForSecondsRealtime((float)(2.0 / 255.0f - 0.2f));

            }
            yield return new WaitForSeconds(2.0f);

            while (screens[4].color.a > 0)
            {
                Color alpha;
                alpha = screens[4].color;
                alpha.a -= 1 / 255f;
                screens[4].color = alpha;
                yield return new WaitForSecondsRealtime((float)(2.0 / 255.0f - 0.2f));
            }

            cam.move("credits_6");
            while (screens[5].color.a < 1)                                                                          // Second credits screen
            {
                Color alpha;
                alpha = screens[5].color;
                alpha.a += 1 / 255f;
                screens[5].color = alpha;

                yield return new WaitForSecondsRealtime((float)(2.0 / 255.0f - 0.2f));

            }
            yield return new WaitForSeconds(2.0f);

            while (screens[5].color.a > 0)
            {
                Color alpha;
                alpha = screens[5].color;
                alpha.a -= 1 / 255f;
                screens[5].color = alpha;
                yield return new WaitForSecondsRealtime((float)(2.0 / 255.0f - 0.2f));
            }
        }

        cam.move("background_main_menu");
        SpriteRenderer[] colors = new SpriteRenderer[7];                                            // Acquire SpriteRenderer components of the main menu and all options
        colors[0] = GameObject.Find("background_main_menu").GetComponent<SpriteRenderer>();
        colors[1] = GameObject.Find("main_cursor").GetComponent<SpriteRenderer>();
        colors[2] = GameObject.Find("new_game").GetComponent<SpriteRenderer>();
        colors[3] = GameObject.Find("load_game").GetComponent<SpriteRenderer>();
        colors[4] = GameObject.Find("settings").GetComponent<SpriteRenderer>();
        colors[5] = GameObject.Find("credits").GetComponent<SpriteRenderer>();
        colors[6] = GameObject.Find("exit").GetComponent<SpriteRenderer>();

        while (GameObject.Find("background_main_menu").GetComponent<SpriteRenderer>().color.a < 1)                                                                           // Fade-out screen
        {
            Color[] mod_color = new Color[7];
            for (int i = 0; i < colors.Length; i++)         // Fade main menu and all selection objects out
            {
                mod_color[i] = colors[i].color;
                mod_color[i].a += 1 / 51f;
                colors[i].color = mod_color[i];
            }
            yield return new WaitForSeconds((2.0f / 255f) * 0.25f);
            Debug.Log("Test");
        }

        Debug.Log("Test");
        GameObject.Find("Functions").GetComponent<Main_Menu>().enabled = true;      // Turn over control back to the Main Menu
        Debug.Log("Test");

    }


}
