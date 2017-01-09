using UnityEngine;
using System.Collections;

public class Instantiable : MonoBehaviour {

    public GameObject[] clockworkSoldiers;

    void Awake()
    {

    }

    public GameObject Create(string which)
    {
        #region CLOCKWORK
        if(which == "ClockworkPrivate")
        {
            return clockworkSoldiers[0];
        }
        else if (which == "ClockworkCorporal")
        {
            return clockworkSoldiers[0];
        }
        else if (which == "ClockworkSergeant")
        {
            return clockworkSoldiers[0];
        }
        else if (which == "GeneralMullius")
        {
            return clockworkSoldiers[0];
        }
        else if (which == "GeneralTor")
        {
            return clockworkSoldiers[0];
        }
        else
        {
            return null;
        }
        #endregion
    }
}
