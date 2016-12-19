/* Main_Menu.cs
 * Description:     Gives logic to control the main menu screen. Calls
 *                  other scripts to do their specific functions. Always
 *                  running. Control determined by bool enabled (modified
 *                  in this script and by any scripts that can be called
 *                  directly from this one). Can call:
 *                      Show_Credits.cs
 *                  
 * Created by:      Brandon Bush (ebicastudios@gmail.com)
 * Last Modified:   12/18/2016
 * ExceptionSafety: Undetermined
 * License:         Ebica Studios Closed Source
 */

using UnityEngine;
using System.Collections;

public class Main_Menu : MonoBehaviour {

    public bool enabled = false;                                                        // If false, this script will ignore Input. If true, it will allow input

    private Vector3[] cursor_positions;                                                 // List of possible cursor positions used for transforming cursor position
    public int selection;                                                              // Indexer for transform of the cursor

    Transform cursor;                                                                   // Transform component for the cursor

    AudioSource changed_selection;                                                      // AudioSource component for the audio played when user changes cursor position
    AudioSource selection_made;                                                         // AudioSource component for the audio played when the user makes a selection

    Camera_Controller camera;                                                           // Camera_Controller component for special control of the camera

    // Find GameObjects and associated scripts, initialize some variables
    void Awake()
    {
        cursor_positions = new Vector3[5];                                              // Set possible cursor positions
        cursor_positions[0] = new Vector3(3f, 2f, -1f);
        cursor_positions[1] = new Vector3(3f, 1f, -1f);
        cursor_positions[2] = new Vector3(3f, 0f, -1f);
        cursor_positions[3] = new Vector3(3f, -1f, -1f);
        cursor_positions[4] = new Vector3(3f, -2f, -1f);

        selection = 0;                                                                  // Set selection to 0, the default location (new game)

        cursor = GameObject.Find("main_cursor").GetComponent<Transform>();              // Acquire transform component of the cursor for moving it around in the game space

        changed_selection = GameObject.Find("audio_main_menu_change_selection").GetComponent<AudioSource>();    // Acquire the audio asset for changing selection
        selection_made = GameObject.Find("audio_main_menu_selection_made").GetComponent<AudioSource>();         // Acquire the audio asset for making a selection
        camera = GameObject.Find("Camera").GetComponent<Camera_Controller>();                                   // Acquire the camera_controller script for moving the camera around
    }

    void Update()
    {
        if (enabled)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && selection > 0)                                   // User pushed the up arrow key, with bounds checking
            {
                selection--;                                                                     // Decrement the selection variable
                cursor.position = cursor_positions[selection];                                   // Move the cursor to the new location provided by the selection index and cursor_positions
                changed_selection.Play();                                                        // Play the selection change SFX
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && selection < 4)                        // User pushed the down arrow key, with bounds checking
            {
                selection++;                                                                      // Increment the selection variable
                cursor.position = cursor_positions[selection];                                    // Move the cursor to the new location provided by the selection index and cursor_positions
                changed_selection.Play();                                                         // Play the selection change SFX
            }
            else if (Input.GetKeyDown(KeyCode.Return))                                            // User pushed the enter/return key
            {
                StartCoroutine(selectionMade());

            }
        }
    }

    IEnumerator selectionMade()
    {
        enabled = false;                                                                    // Take away control from the main menu
        selection_made.Play();                                                           // Play the section made SFX        
        SpriteRenderer[] colors = new SpriteRenderer[7];                                            // Acquire SpriteRenderer components of the main menu and all options
        colors[0] = GameObject.Find("background_main_menu").GetComponent<SpriteRenderer>();
        colors[1] = GameObject.Find("main_cursor").GetComponent<SpriteRenderer>();
        colors[2] = GameObject.Find("new_game").GetComponent<SpriteRenderer>();
        colors[3] = GameObject.Find("load_game").GetComponent<SpriteRenderer>();
        colors[4] = GameObject.Find("settings").GetComponent<SpriteRenderer>();
        colors[5] = GameObject.Find("credits").GetComponent<SpriteRenderer>();
        colors[6] = GameObject.Find("exit").GetComponent<SpriteRenderer>();

        while (GameObject.Find("background_main_menu").GetComponent<SpriteRenderer>().color.a > 0)                                                                           // Fade-out screen
        {
            if (selection != 4)                                 // User did not select exits
            {
                Color[] mod_color = new Color[7];
                for (int i = 0; i < colors.Length; i++)         // Fade main menu and all selection objects out
                {
                    mod_color[i] = colors[i].color;
                    mod_color[i].a -= 1 / 51f;
                    colors[i].color = mod_color[i];
                }
                yield return new WaitForSeconds((2.0f / 255f) * 0.25f);
            }
        }
        switch (selection)                                                                 // Switch statement to figure out what script to call next
        {
            case 3:                                                                         // Credits
                yield return new WaitForSeconds(1.0f);                                      // Wait for a second before calling the Show_Credits script
                GameObject.Find("Functions").GetComponent<Show_Credits>().Activate();      // Activate the show_credits script
                break;                                                                      // Break out of this case
        }
    }
}
