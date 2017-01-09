using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Explore : MonoBehaviour {

    Vector3 stagingArea;
    Instantiable instantiable;
    public List<List<GameObject>> encounterFormations;
    int formationIndex;
    public int nextEncounter;

    void Awake()
    {
        stagingArea = GameObject.Find("Staging").GetComponent<Transform>().position;
        instantiable = GameObject.Find("Variables").GetComponent<Instantiable>();
        encounterFormations = new List<List<GameObject>>();
        //Debug
        loadArea("debug");
        GameObject.Find("Battle").GetComponent<Battle>().initializeRegular();
    }

    public void loadArea(string which)
    {
        if(which == "debug")
        {
            encounterFormations.Clear();
            List<GameObject> push = new List<GameObject>();

            push.Add(instantiable.Create("ClockworkPrivate"));
            push.Add(instantiable.Create("ClockworkPrivate"));
            push.Add(instantiable.Create("ClockworkPrivate"));

            encounterFormations.Add(push);
            push.Clear();

            push.Add(instantiable.Create("ClockworkPrivate"));
            push.Add(instantiable.Create("ClockworkCorporal"));
            push.Add(instantiable.Create("ClockworkPrivate"));

            encounterFormations.Add(push);
            push.Clear();

            push.Add(instantiable.Create("ClockworkSergeant"));
            push.Add(instantiable.Create("ClockworkCorporal"));
            push.Add(instantiable.Create("ClockworkPrivate"));

            encounterFormations.Add(push);
            push.Clear();

            push.Add(instantiable.Create("GeneralMullius"));
            push.Add(instantiable.Create("GeneralTor"));

            encounterFormations.Add(push);
            push.Clear();

            formationIndex = 2;
        }

    }
    public void determineNextEncounter()
    {
        System.Random rand = new System.Random();
        nextEncounter = rand.Next(0, encounterFormations.Count);
    }
}
