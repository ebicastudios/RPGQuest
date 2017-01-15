using UnityEngine;
using System.Collections;

public enum ITEM_REF
{
    Potion = 0,
    HiPotion,
    Aetherstone
}

public class Item : MonoBehaviour {

    public string name;
    public int cost;
    public ITEM_REF itemRef;

    public void applyEffect(GameObject go)
    {
        switch (itemRef)
        {

        }
    }

    private void potion(GameObject go)
    {

    }
}
