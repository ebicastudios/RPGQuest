using UnityEngine;
using System.Collections;

public class Disable_UI : MonoBehaviour {

    public bool enabled = false;                        // Enables or disables script execution on load

	void Start () {
        if (enabled)
        {
            this.GetComponent<Canvas>().enabled = false;
        }	
	}
	
}
