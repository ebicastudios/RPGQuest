using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {
    public enum TYPE
    {
        Null,
        Roof,
        ExitTrigger
    };
    public enum TELEPORT_LIST
    {
        DEBUG_TOWN = 0,
        DEBUG_DUNGEON
    }
    public bool logging = false;
    public bool isInside = false;
    public GameObject player;
    public GameObject global;
    public GameObject camera;

    [Header("Parameters")]
    public TYPE type;
    public TELEPORT_LIST teleportWhere;


    void Update()
    {
        if(type == TYPE.Roof)
        {
            if (isInside)
            {
                this.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (!isInside)
            {
                this.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
//        if (logging) { Debug.Log("Triggered GameObject " + this.name.ToString() + "Collider"); }
        if(coll.tag == "Player" && type == TYPE.Roof)
        {
            isInside = true;
        }
        else if(coll.tag == "Player" && type == TYPE.ExitTrigger)
        {
            if (logging) { Debug.Log("Exit trigger encountered. Transporting player to " + teleportWhere.ToString()); }
            teleport(teleportWhere);
        }
    }
    public void OnTriggerExit2D(Collider2D coll)
    {
        if (logging) { Debug.Log("Leaving Triggered GameObject " + this.name.ToString() + "Collider"); }
        if(coll.tag == "Player" && type == TYPE.Roof)
        {
            isInside = false;
        }
    }

    private void teleport(TELEPORT_LIST where)
    {
        global.GetComponent<GlobalVars>().processing++;
        if (logging) { Debug.Log("teleport() called"); }
        Vector3 transformWhere = new Vector3(0, 0, 0);
        switch (where)
        {
            case TELEPORT_LIST.DEBUG_DUNGEON:
                transformWhere = new Vector3(-489, 878, -1);
                break;
            case TELEPORT_LIST.DEBUG_TOWN:
                transformWhere = new Vector3(-203, -410, -1);
                break;
        }
        player.transform.position = transformWhere;
    }
}
