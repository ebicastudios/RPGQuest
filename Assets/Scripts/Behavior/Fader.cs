using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {

    public bool faded = false;
    public float fadeFactor = 0;

    public void onFadeOut()
    {
        StartCoroutine(fadeOut());
    }
    private IEnumerator fadeOut()
    {
        yield return null;
    }
}
