using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour {

    public GameObject global;
    public GameObject player;

    [Header("Debug Flags")]
    public bool processing = false;
    public bool logging = false;

    [Header("Parameters")]
    public DialoguerDialogues which;
    public float waitAfterDialogue = 0;
    public delegate void startDialogue();

    void Awake()
    {
        Dialoguer.Initialize();
        Dialoguer.events.onMessageEvent += messageEvent;
        Dialoguer.events.onEnded += endDialogue;
    }
    #region DIALOGUER_EVENTS
    public void beginDialogue()
    {
        global.GetComponent<GlobalVars>().processing += 1;
        Dialoguer.StartDialogue(which);
    }
    private void endDialogue()
    {
        StartCoroutine(wait());         // Make sure to wait for some time before updating GlobalVars.processing variable
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(waitAfterDialogue);
        global.GetComponent<GlobalVars>().processing -= 1;
        yield return null;
    }
    #endregion

    #region DIALOGUER_MESSAGE_EVENTS
    private void messageEvent(string type, string meta) {
        #region VENDOR_SCRIPTS
        if(type == "shop")
        {
            if (logging) { Debug.Log("Message Event Recieved in " + this.name.ToString() + "\nShop event."); }
            if(this.gameObject.GetComponent<Vendor>() == null)
            {
                string error = "ERROR: Vendor script not attached to NPC " + this.name.ToString();
                throw new System.Exception(error);
            }
            else
            {
                this.gameObject.GetComponent<Vendor>().shopUI.GetComponent<ShopMenu>().initialize(this.gameObject);
            }
        }
        #endregion
    }
    #endregion
}
