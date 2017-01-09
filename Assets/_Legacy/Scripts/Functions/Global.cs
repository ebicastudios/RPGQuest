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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

public class LoadScreenData
{
    public string location;
    public string gold;
    public string time;
    public string chapter;
    public string warriorLvl;
    public string mageLvl;
    public string thiefLvl;
    public string archerLvl;
    public string bardLvl;

    // Called to load the data in rather than setting everything up individually. Parses a list, constructs appropriate strings, and sets
    public void Initialize(List<string> what)
    {

    }
}

public class Global : MonoBehaviour {

    public bool logging = false;                                                                            // If true, debug messages will be sent to the console
    public bool running_process = false;                                                                    // Used by other scripts to determine if a procecss is running
    Variables variables;                                                                                    // Holds some global variables (namely file directories)
    LoadScreenData Lsave1, Lsave2, Lsave3;                                                                  // Holds data for the load game screen
    public List<string>[] save1, save2, save3;                                                                     // Holds lists for each of the saves for loading in stuff

    void Awake()
    {
        variables = GameObject.Find("Variables").GetComponent<Variables>();                                 // Acquire access to global variables
        save1 = new List<string>[6];                                                                        // In order: toc.dat, c0.dat, c1.dat, c2.dat, c3.dat, c4.dat
        save2 = new List<string>[6];                                                                        // See above
        save3 = new List<string>[6];                                                                        // See above, above :D
    }

    void Start()
    {
        loadGame();
    }

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

    #region SAVE_LOAD
    public void saveGame(int which)
    {
        // Call save methods for each individual character file (c1.dat, c2.dat, etc...)
        GameObject.Find("Warrior").GetComponent<Character>().Save(which);
        GameObject.Find("Mage").GetComponent<Character>().Save(which);
        GameObject.Find("Thief").GetComponent<Character>().Save(which);
        GameObject.Find("Archer").GetComponent<Character>().Save(which);
        GameObject.Find("Bard").GetComponent<Character>().Save(which);

        // Call save method for global data (gold, plot flags, etc...)
        GameObject.Find("Variables").GetComponent<Variables>().Save(which);
    }

    public void loadGame()
    {
        string path1 = variables.path_sav1;
        string path2 = variables.path_sav2;
        string path3 = variables.path_sav3;

        // Store toc.dat
        using (StreamReader sr = new StreamReader(path1 + "toc.dat"))
        {
            string parse = "";
            parse = sr.ReadToEnd();
            List<string> parsed = new List<string>();
            parsed = parse.Split(new char[] { '<', '>' }).ToList();
            save1[0] = parsed;
        }
        using (StreamReader sr = new StreamReader(path2 + "toc.dat"))
        {
            string parse = "";
            parse = sr.ReadToEnd();
            List<string> parsed = new List<string>();
            parsed = parse.Split(new char[] { '<', '>' }).ToList();
            save2[0] = parsed;
        }
        using (StreamReader sr = new StreamReader(path3 + "toc.dat"))
        {
            string parse = "";
            parse = sr.ReadToEnd();
            List<string> parsed = new List<string>();
            parsed = parse.Split(new char[] { '<', '>' }).ToList();
            save3[0] = parsed;
        }

        // Store c1.dat
        using (StreamReader sr = new StreamReader(path1 + "c1.dat"))
        {
            string parse = "";
            parse = sr.ReadToEnd();
            List<string> parsed = new List<string>();
            parsed = parse.Split(new char[] { '<', '>' }).ToList();
            save1[1] = parsed;
        }
        using (StreamReader sr = new StreamReader(path2 + "c1.dat"))
        {
            string parse = "";
            parse = sr.ReadToEnd();
            List<string> parsed = new List<string>();
            parsed = parse.Split(new char[] { '<', '>' }).ToList();
            save2[1] = parsed;
        }
        using (StreamReader sr = new StreamReader(path3 + "c1.dat"))
        {
            string parse = "";
            parse = sr.ReadToEnd();
            List<string> parsed = new List<string>();
            parsed = parse.Split(new char[] { '<', '>' }).ToList();
            save3[1] = parsed;
        }

        // Store c2.dat
        using (StreamReader sr = new StreamReader(path1 + "c2.dat"))
        {
            string parse = "";
            parse = sr.ReadToEnd();
            List<string> parsed = new List<string>();
            parsed = parse.Split(new char[] { '<', '>' }).ToList();
            save1[2] = parsed;
        }
        using (StreamReader sr = new StreamReader(path2 + "c2.dat"))
        {
            string parse = "";
            parse = sr.ReadToEnd();
            List<string> parsed = new List<string>();
            parsed = parse.Split(new char[] { '<', '>' }).ToList();
            save2[2] = parsed;
        }
        using (StreamReader sr = new StreamReader(path3 + "c2.dat"))
        {
            string parse = "";
            parse = sr.ReadToEnd();
            List<string> parsed = new List<string>();
            parsed = parse.Split(new char[] { '<', '>' }).ToList();
            save3[2] = parsed;
        }

        // Store c3.dat
        using (StreamReader sr = new StreamReader(path1 + "c3.dat"))
        {
            string parse = "";
            parse = sr.ReadToEnd();
            List<string> parsed = new List<string>();
            parsed = parse.Split(new char[] { '<', '>' }).ToList();
            save1[3] = parsed;
        }
        using (StreamReader sr = new StreamReader(path2 + "c3.dat"))
        {
            string parse = "";
            parse = sr.ReadToEnd();
            List<string> parsed = new List<string>();
            parsed = parse.Split(new char[] { '<', '>' }).ToList();
            save2[3] = parsed;
        }
        using (StreamReader sr = new StreamReader(path3 + "c3.dat"))
        {
            string parse = "";
            parse = sr.ReadToEnd();
            List<string> parsed = new List<string>();
            parsed = parse.Split(new char[] { '<', '>' }).ToList();
            save3[3] = parsed;
        }

        // Store c4.dat
        using (StreamReader sr = new StreamReader(path1 + "c4.dat"))
        {
            string parse = "";
            parse = sr.ReadToEnd();
            List<string> parsed = new List<string>();
            parsed = parse.Split(new char[] { '<', '>' }).ToList();
            save1[4] = parsed;
        }
        using (StreamReader sr = new StreamReader(path2 + "c4.dat"))
        {
            string parse = "";
            parse = sr.ReadToEnd();
            List<string> parsed = new List<string>();
            parsed = parse.Split(new char[] { '<', '>' }).ToList();
            save2[4] = parsed;
        }
        using (StreamReader sr = new StreamReader(path3 + "c4.dat"))
        {
            string parse = "";
            parse = sr.ReadToEnd();
            List<string> parsed = new List<string>();
            parsed = parse.Split(new char[] { '<', '>' }).ToList();
            save3[4] = parsed;
        }

        // Store c5.dat
        using (StreamReader sr = new StreamReader(path1 + "c5.dat"))
        {
            string parse = "";
            parse = sr.ReadToEnd();
            List<string> parsed = new List<string>();
            parsed = parse.Split(new char[] { '<', '>' }).ToList();
            save1[5] = parsed;
        }
        using (StreamReader sr = new StreamReader(path2 + "c5.dat"))
        {
            string parse = "";
            parse = sr.ReadToEnd();
            List<string> parsed = new List<string>();
            parsed = parse.Split(new char[] { '<', '>' }).ToList();
            save2[5] = parsed;
        }
        using (StreamReader sr = new StreamReader(path3 + "c5.dat"))
        {
            string parse = "";
            parse = sr.ReadToEnd();
            List<string> parsed = new List<string>();
            parsed = parse.Split(new char[] { '<', '>' }).ToList();
            save3[5] = parsed;
        }

        // Initialize the load game screen data


    }


    #endregion

}
