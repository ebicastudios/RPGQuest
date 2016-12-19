/* Camera_Controller.cs
 * Description:     Stores special functions that the camera can utilize
 * Created by:      Brandon Bush (ebicastudios@gmail.com)
 * Last Modified:   12/18/2016
 * ExceptionSafety: Undetermined
 * License:         Ebica Studios Closed Source
 */

using UnityEngine;
using System.Collections;

public class Camera_Controller : MonoBehaviour {

    // Move the camera to center on a GameObject indicated by the name "where", but pulled out to avoid clipping
    public void move(string where)
    {
        Debug.Log("Finding position of: " + where);
        Vector3 pos = new Vector3(0, 0, 0);                                                                     // Vector3 to hold location to move to
        pos = GameObject.Find(where).GetComponent<Transform>().position;                                        // Get the position of the object we're moving to
        pos.z = -100f;                                                                                          // Pull the camera back
        this.GetComponent<Transform>().position = pos;                                                          // Update the camera's transform function
    }
    /* Work on this implementation later
    // Fade in or out an asset with a SpriteRenderer
    public void fadeIn(string what, string what_object_next, string next_func)                                                           // Regular function to call the coroutine
    {
        StartCoroutine(fade_in(what, what_object_next, next_func));                                                               // Call the associated coroutine
    }

    IEnumerator fade_in(string what, string what_object_next, string next_func)
    {
        SpriteRenderer fade_what = GameObject.Find(what).GetComponent<SpriteRenderer>();                        // Acquire the SpriteRenderer
        while (fade_what.color.a < 0)                                                                           // Fade-in screen
        {
            Color alpha;                                                                                            // Color variable to adjust the alpha transparency of the screens for fading
            alpha = fade_what.color;                                                                            // Get current color value of fade_what
            alpha.a += 1 / 255f;                                                                                      // Adds 1/255 to the alpha transparency (255 discreet steps)
            fade_what.color = alpha;                                                                            // Assign new alpha channel to fade_what
            yield return new WaitForSecondsRealtime((float)(2.0 / 255.0f - 0.2f));                                   // Wait
        }

    }
*/
}
