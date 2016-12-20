/* Global.cs
 * Description:     Contains global functions that can be called
 *                  scripts. These functions might be needed more
 *                  than once, so they are established here.
 *                  
 * Created by:      Brandon Bush (ebicastudios@gmail.com)
 * Last Modified:   12/19/2016
 * ExceptionSafety: Undetermined
 * License:         Ebica Studios Closed Source
 */


using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

    public bool logging = false;                                                                            // If true, debug messages will be sent to the console
    public bool running_process = false;                                                                    // Used by other scripts to determine if a procecss is running

    #region FADE_FUNCTIONS
    public void FadeIn(string fade_what, float how_long)                                                    // Sets running_process flag to true, and starts associated CoRoutine
    {
        running_process = true;
        StartCoroutine(CoFadeIn(fade_what, how_long));
    }
    public void FadeIn(string[] fade_what, float how_long)                                                  // Overload for FadeIn to accept multiple fades at a time. Sets running_flag to true and starts CoRoutine
    {
        running_process = true;
        StartCoroutine(CoFadeIn(fade_what, how_long));
    }
    public void FadeOut(string fade_what, float how_long)                                                   // Sets running_process flag to true, and starts associateed CoRoutine
    {
        running_process = true;
        StartCoroutine(CoFadeOut(fade_what, how_long));
        
    }
    public void FadeOut(string[] fade_what, float how_long)                                                 // Overload for FadeOut to accept multiple fades at a time. Sets running_flag to true and starts CoRoutine
    {
        running_process = true;
        StartCoroutine(CoFadeOut(fade_what, how_long));
    }
    IEnumerator CoFadeIn(string fade_what, float how_long)                                                  // Fades a screen in determined by fade_what in by a factor determined by how_long
    {
        float step_size = (how_long / 0.1f);
        step_size = (1.0f / step_size);
        if (logging) { Debug.Log("In Global::CoFadeIn => Step Size set to: " + step_size.ToString()); }

        while(GameObject.Find(fade_what).GetComponent<SpriteRenderer>().color.a < 1)
        {
            Color alpha_color = GameObject.Find(fade_what).GetComponent<SpriteRenderer>().color;
            alpha_color.a += step_size;
            GameObject.Find(fade_what).GetComponent<SpriteRenderer>().color = alpha_color;
            yield return new WaitForSeconds(.1f);
        }
        running_process = false;
        yield return null;
    }
    IEnumerator CoFadeIn(string[] fade_what, float how_long)                                                // Fades multiple objects in determined by fade_what array and how_long factor
    {
        float step_size = (how_long / 0.1f);
        step_size = (1.0f / step_size);
        if (logging) { Debug.Log("In Global::CoFadeIn Array => Step Size set to: " + step_size.ToString()); }

        while(GameObject.Find(fade_what[0]).GetComponent<SpriteRenderer>().color.a < 1)
        {
            for(int i = 0; i < fade_what.Length; i++)
            {
                Color alpha_color = GameObject.Find(fade_what[i]).GetComponent<SpriteRenderer>().color;
                alpha_color.a += step_size;
                GameObject.Find(fade_what[i]).GetComponent<SpriteRenderer>().color = alpha_color;
            }
            yield return new WaitForSeconds(.1f);
        }
        running_process = false;
        yield return null;
    }
    IEnumerator CoFadeOut(string fade_what, float how_long)                                                 // Fades a screen out determined by fade_what out by a factor determined by how_long
    {
        float step_size = (how_long / 0.1f);
        step_size = (1.0f / step_size);
        if (logging) { Debug.Log("In Global::CoFadeOut => Step Size set to: " + step_size.ToString()); }

        while (GameObject.Find(fade_what).GetComponent<SpriteRenderer>().color.a > 0)
        {
            Color alpha_color = GameObject.Find(fade_what).GetComponent<SpriteRenderer>().color;
            alpha_color.a -= step_size;
            GameObject.Find(fade_what).GetComponent<SpriteRenderer>().color = alpha_color;
            yield return new WaitForSeconds(.1f);
        }
        running_process = false;
        yield return null;

    }
    IEnumerator CoFadeOut(string[] fade_what, float how_long)                                               // Fades multiple objects out determined by fade_what array and how_long factor
    {
        float step_size = (how_long / 0.1f);
        step_size = (1.0f / step_size);
        if (logging) { Debug.Log("In Global::CoFadeOut Array => Step Size set to: " + step_size.ToString()); }

        while (GameObject.Find(fade_what[0]).GetComponent<SpriteRenderer>().color.a > 0)
        {
            for (int i = 0; i < fade_what.Length; i++)
            {
                Color alpha_color = GameObject.Find(fade_what[i]).GetComponent<SpriteRenderer>().color;
                alpha_color.a += step_size;
                GameObject.Find(fade_what[i]).GetComponent<SpriteRenderer>().color = alpha_color;
            }
            yield return new WaitForSeconds(.1f);
        }
        running_process = false;
        yield return null;
    }
    #endregion

}
