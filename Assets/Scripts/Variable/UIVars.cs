using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIVars : MonoBehaviour {

    public GameObject[] fields;

    void Awake()
    {
        // Make all Objects transparent
        foreach(GameObject go in fields)
        {
            Color newColor = new Color(0, 0, 0, 0);
            if(go.GetComponent<Image>() != null)
            {
                newColor = go.GetComponent<Image>().color;
                newColor.a = 0;
                go.GetComponent<Image>().color = newColor;
            }
            else if(go.GetComponent<Text>() != null)
            {
                newColor = go.GetComponent<Text>().color;
                newColor.a = 0;
                go.GetComponent<Text>().color = newColor;
            }
        }
    }
}
