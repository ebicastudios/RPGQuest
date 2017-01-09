using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Battle : MonoBehaviour {

    GameObject[] playerCharacters;                      // Holds player characters present in battle
    GameObject[] enemyCharacters;                       // Holds enemies present in the battle

    int whichFormation;                                 // Holds integer index for which formation found in Explore
    
    public void initializeRegular()
    {
        whichFormation = GameObject.Find("Functions").GetComponent<Explore>().nextEncounter;
        List<GameObject> tempEnemies = GameObject.Find("Functions").GetComponent<Explore>().encounterFormations[whichFormation];
        enemyCharacters = new GameObject[tempEnemies.Count];
        foreach(GameObject enemy in tempEnemies)
        {
            Instantiate(enemy, GameObject.Find("Staging").GetComponent<Transform>().position, Quaternion.identity);
        }
    }
}
