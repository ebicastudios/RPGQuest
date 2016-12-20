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
}
