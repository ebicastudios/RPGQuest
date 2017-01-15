using UnityEngine;
using System.Collections;

public enum SCREENS
{
    logoEbica = 0,
    logoTools = 1,
    ShopUI = 2
};

public class IScreens : MonoBehaviour {


    public GameObject[] screens;                    // Holds screens for Instantiation

    public void create(SCREENS which)
    {
        Instantiate(screens[(int)which], GameObject.Find("Camera").GetComponent<Transform>().position, Quaternion.identity);
    }
}
