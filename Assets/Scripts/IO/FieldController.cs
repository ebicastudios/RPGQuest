using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldController : MonoBehaviour {

    private Rigidbody2D physics;
    public List<GameObject> collidingWith;

    [Header("Modifiers")]
    public bool enabled = false;
    public bool logging = false;

    [Header("Keymaps")]
    public string up;
    public string down;
    public string left;
    public string right;
    public string run;
    public string accept;
    public string cancel;

    [Header("Parameters")]
    public bool isColliding = false;
    public float walkSpeed = 1;

    [Header("Debug Info")]
    public int colliderIndex = 0;

    void Awake()
    {
        physics = this.GetComponent<Rigidbody2D>();
        if(physics == null)
        {
            throw new System.Exception("Error: " + this.name.ToString() + " does not have an attached Rigidbody2D component");
        }
        collidingWith = new List<GameObject>();
        Dialoguer.Initialize();
    }
    void Start()
    {
        changeIO();
    }
    void FixedUpdate()
    {
        Vector2 newVelocity = physics.velocity;

        #region COLLISION_CHECKING
        if (colliderIndex > 0)
        {
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }
        #endregion

        if (enabled)
        {
            #region DOWN_EVENS
            if (Input.GetKey(down))
            {
                if (Input.GetKey(left))
                {
                    newVelocity.x -= walkSpeed;
                }
                else if (Input.GetKey(right))
                {
                    newVelocity.x += walkSpeed;
                }
                newVelocity.y -= walkSpeed;
            }
            #endregion
            #region UP_EVENTS
            else if (Input.GetKey(up))
            {
                if (Input.GetKey(left))
                {
                    newVelocity.x -= walkSpeed;
                }
                else if (Input.GetKey(right))
                {
                    newVelocity.x += walkSpeed;
                }
                newVelocity.y += walkSpeed;
            }
            #endregion
            #region LEFT_EVENTS
            else if (Input.GetKey(left))
            {
                if (Input.GetKey(up))
                {
                    newVelocity.y += walkSpeed;
                }
                else if (Input.GetKey(down))
                {
                    newVelocity.y -= walkSpeed;
                }
                newVelocity.x -= walkSpeed;
            }
            #endregion
            #region RIGHT_EVENTS
            else if (Input.GetKey(right))
            {
                if (Input.GetKey(up))
                {
                    newVelocity.y += walkSpeed;
                }
                else if (Input.GetKey(down))
                {
                    newVelocity.y -= walkSpeed;
                }
                newVelocity.x += walkSpeed;
            }
            #endregion
            #region PHYSICS_UPDATE
            // Update the rigidbody
            physics.velocity = newVelocity;
            #endregion
        }
    }

    void Update()
    {
        #region ACCEPT_EVENTS
        if (enabled)
        {
            if (Input.GetKeyDown(accept))
            {
                foreach(GameObject go in collidingWith)
                {
                    if(go.tag == "NPC")
                    {
                        if (logging) { Debug.Log("Accept Event triggered with " + this.name.ToString() + " and " + go.name.ToString()); }
                        StartCoroutine(Dialogue(go));
                    }
                }
            }
        }
        #endregion

    }

    void changeIO()
    {
        try
        {
            accept = GameObject.Find("Variables").GetComponent<GlobalVars>().ioSettings[(int)IO_SETTINGS.ACCEPT];
            cancel = GameObject.Find("Variables").GetComponent<GlobalVars>().ioSettings[(int)IO_SETTINGS.CANCEL];
            up = GameObject.Find("Variables").GetComponent<GlobalVars>().ioSettings[(int)IO_SETTINGS.UP];
            down = GameObject.Find("Variables").GetComponent<GlobalVars>().ioSettings[(int)IO_SETTINGS.DOWN];
            right = GameObject.Find("Variables").GetComponent<GlobalVars>().ioSettings[(int)IO_SETTINGS.RIGHT];
            left = GameObject.Find("Variables").GetComponent<GlobalVars>().ioSettings[(int)IO_SETTINGS.LEFT];
            run = GameObject.Find("Variables").GetComponent<GlobalVars>().ioSettings[(int)IO_SETTINGS.RUN];
        }
        catch
        {
            Debug.Log("Error in setting new IO in Field.cs");
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        collidingWith.Add(coll.gameObject);
        colliderIndex++;
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        collidingWith.Remove(coll.gameObject);
        colliderIndex--;
    }
    
    IEnumerator Dialogue(GameObject whichObject)
    {
        enabled = false;
        whichObject.GetComponent<Dialogue>().beginDialogue();
        while(whichObject.GetComponent<Dialogue>().processing == true)
        {
            yield return null;
        }
        enabled = true;
        yield return null;
    }
}
