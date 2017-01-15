using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum CHARACTER
{
    // Enumerates characters
    WARRIOR = 0,
    MAGE,
    THIEF,
    ARCHER,
    BARD
};

public class Stats : MonoBehaviour {

    [Header("Non-Battle Stats")]
    public string displayName;
    public int currentExperience;
    public int level;

    [Header("Battle Stats")]
    public int physicalAttack;
    public int magicalAttack;
    public int physicalDefense;
    public int magicalDefense;
    public int dodge;
    public int concentration;
    public int critChance;
}
