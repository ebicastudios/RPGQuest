using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopMenu : MonoBehaviour {

    public enum MODE
    {
        Master = 0,
        Buy,
        Sell,
        Exit
    }

    [Header("GameObject References")]
    public GameObject global;

    [Header("Debug Flags")]
    public bool isEnabled = false;
    public bool logging = false;
    public bool processing = false;
    public MODE mode;

    [Header("Modifiers")]
    public float fadeFactor;

    private UIVars fields;
    private UIShopItemField items;
    private int sellableSize = 0;

    [Header("Current Inventory")]
    public Item[] sellable;

    void Awake()
    {
        fields = this.GetComponent<UIVars>();
        items = this.GetComponent<UIShopItemField>();
        if(fields == null)
        {
            throw new System.Exception("ERROR: UIVars script not attached to " + this.name.ToString());
        }
        if(items == null)
        {
            throw new System.Exception("ERROR: UIShopItemField script not attached to " + this.name.ToString());
        }
    }

    #region MODES
    public void Buy()
    {
        mode = MODE.Buy;
        onCreateItemField();
    }
    public void Sell()
    {
        mode = MODE.Sell;
    }
    public void Exit()
    {
        mode = MODE.Master;
        onFade();
    }
    public void Master()
    {
        mode = MODE.Master;
    }

    #endregion
    #region CREATION_FUNCTIONS
    public void initialize(GameObject go)
    {
        if (logging) { Debug.Log("Called initialize() in " + this.gameObject.name.ToString()); }
        VendorInventory vendorInventory = go.GetComponent<VendorInventory>();
        if(vendorInventory == null)
        {
            throw new System.Exception("ERROR: VendorInventory Script not attached to " + go.name.ToString());
        }
        if(sellable == null)
        {
            throw new System.Exception("ERROR: Vendor inventory on " + go.name.ToString() + " has not been initialized");
        }
        sellable = vendorInventory.vendorInventory;
        if (sellable.Length == 0)
        {
            if (logging) { Debug.Log("ERROR: Vendor inventory on " + go.name.ToString() + " has no items!"); }
        }

        global.GetComponent<GlobalVars>().processing += 1;
        for(int i = 0; i < items.items.Length; i++)
        {
            items.items[i].GetComponent<Text>().text = "";
        }
        populate();
        onCreateMain();
    }
    private void populate()
    {
        sellableSize = sellable.Length;
        if (logging) { Debug.Log("Sellable Size in " + this.gameObject.name.ToString() + ": " + sellableSize.ToString()); }
        if (logging) { Debug.Log("Size of items array is: " + items.items.Length.ToString()); }
        for (int i = 0; i < sellableSize; i++)
        {
            items.items[i].GetComponent<Text>().text = sellable[i].name;
        }
    }
    public void onCreateMain()
    {
        isEnabled = true;
        if (logging) { Debug.Log("UICreation called in " + this.name.ToString()); }
        StartCoroutine(create());
    }
    IEnumerator create()
    {
        yield return new WaitForSeconds(1.0f);
        if(fadeFactor <= 0) { throw new System.Exception("ERROR: FadeFactor set to <= 0! Infinite Loop Condition"); }
        Color newColor = new Color(0, 0, 0, 0);
        for (float f = 0; f < .75; f += fadeFactor)
        {
            foreach (GameObject go in fields.fields)
            {
                if (go.GetComponent<Image>() != null)
                {
                    newColor = go.GetComponent<Image>().color;
                }
                else if (go.GetComponent<Text>() != null)
                {
                    newColor = go.GetComponent<Text>().color;
                }
                else
                {
                    throw new System.Exception("ERROR: No Image or Text component attached to " + go.name.ToString());
                }

                newColor.a += fadeFactor;
                if (go.GetComponent<Image>() != null)
                {
                    go.GetComponent<Image>().color = newColor;
                }
                else if (go.GetComponent<Text>() != null)
                {
                    go.GetComponent<Text>().color = newColor;
                }
            }
            yield return new WaitForSeconds(0.05f);
        }
        yield return null;
    }
    public void onCreateItemField()
    {
        if(items.items[0].GetComponent<Text>().color.a == 0)
        {
            StartCoroutine(createItemField());
        }
    }
    IEnumerator createItemField()
    {

        Color newColor = new Color(0, 0, 0, 0);
        for (float f = 0; f < .75; f += fadeFactor)
        {
            for (int i = 0; i < sellableSize; i++)
            {
                newColor = items.items[i].GetComponent<Text>().color;
                newColor.a += fadeFactor;
                items.items[i].GetComponent<Text>().color = newColor;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void onFade()
    {
        StartCoroutine(fade());
    }
    IEnumerator fade()
    {
        processing = true;
        Color newColor = new Color(0, 0, 0, 0);
        for (float f = 0.75f; f > 0; f -= fadeFactor)
        {
            foreach (GameObject go in fields.fields)
            {
                if (go.GetComponent<Image>() != null)
                {
                    newColor = go.GetComponent<Image>().color;
                }
                else if (go.GetComponent<Text>() != null)
                {
                    newColor = go.GetComponent<Text>().color;
                }
                else
                {
                    throw new System.Exception("ERROR: No Image or Text component attached to " + go.name.ToString());
                }

                newColor.a -= fadeFactor;
                if (go.GetComponent<Image>() != null)
                {
                    go.GetComponent<Image>().color = newColor;
                }
                else if (go.GetComponent<Text>() != null)
                {
                    go.GetComponent<Text>().color = newColor;
                }
            }
            foreach(GameObject go in items.items)
            {
                newColor = go.GetComponent<Text>().color;
                newColor.a -= fadeFactor;
                go.GetComponent<Text>().color = newColor;
            }
            yield return new WaitForSeconds(0.05f);
        }

        // Completely set alpha transparency for item field to 0, for control code purposes
        foreach(GameObject go in items.items)
        {
            newColor = go.GetComponent<Text>().color;
            newColor.a = 0;
            go.GetComponent<Text>().color = newColor;
        }
        processing = false;
        global.GetComponent<GlobalVars>().processing -= 1;
    }
    #endregion
}
