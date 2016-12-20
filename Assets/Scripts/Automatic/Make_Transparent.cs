/* Make_Transparent.cs
 * Description:     Makes an asset with a SpriteRenderer component transparent
 *                  upon awakening.
 *                  
 * Created by:      Brandon Bush (ebicastudios@gmail.com)
 * Last Modified:   12/18/2016
 * ExceptionSafety: Undetermined
 * License:         Ebica Studios Closed Source
 */

using UnityEngine;
using System.Collections;

public class Make_Transparent : MonoBehaviour {

    public bool enabled = true;                                                        // Bool to enable transparency upon awakening

    void Awake()
    {
        if (enabled)
        {
            Color alpha_color;                                                          // Temp variable to store this SpriteRenderer component
            alpha_color = this.GetComponent<SpriteRenderer>().color;                    // Get the color
            alpha_color.a = 0;                                                          // Set the alpha to 0 (Transparent)
            this.GetComponent<SpriteRenderer>().color = alpha_color;                    // Assign the new color with alpha channel 0 to this
        }
        return;                                                                         // End function
    }
}
