using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour {

    public DialoguerDialogues which;
    public bool processing = false;

    public void beginDialogue()
    {
        processing = true;
        Dialoguer.events.onStarted += startDialogue;
        Dialoguer.events.onEnded += endDialogue;
        Dialoguer.StartDialogue(which);
    }

    private void startDialogue()
    {
        Debug.Log("Starting dialogue with " + this.name.ToString());
    }

    public void endDialogue()
    {
        processing = false;
    }
}
