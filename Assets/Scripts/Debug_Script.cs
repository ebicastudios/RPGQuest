using UnityEngine;
using System.Collections;

public class Debug_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(test());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator test()
    {
        GameObject.Find("Functions").GetComponent<Global>().FadeIn("test", 4.0f);
        while (GameObject.Find("Functions").GetComponent<Global>().running_process)
        {
            yield return null;
        }
        GameObject.Find("Functions").GetComponent<Global>().FadeOut("test", 4.0f);
        while (GameObject.Find("Functions").GetComponent<Global>().running_process)
        {
            yield return null;
        }
        Debug.Log("Finished");
    }
}
