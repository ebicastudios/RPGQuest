using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum KEY_EVENT
{
    LEFT = 0,
    RIGHT,
    DOWN,
    UP,
    ACCEPT,
    CANCEL,
    RUN,
    NO_KEY
}

public class FieldController : MonoBehaviour {

    // Non-Inspector Variables

    // Inspector Elements
    [Header("Variables")]
    public GameObject global;
    public Rigidbody2D physics;
    public BoxCollider2D facingTrigger;
    public Facing facing;
    public Animator animator;
    public float animationSpeed = 0.0f;

    [Header("Debug Flags")]
    public bool enabled = false;
    public bool logging = false;
    public int colliderIndex = 0;
    public int triggeringIndex = 0;

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
    public List<GameObject> collidingWith;
    public List<GameObject> triggeringWith;
    public float walkSpeed = 1;

    void Awake()
    {
        collidingWith = new List<GameObject>();
        triggeringWith = new List<GameObject>();
        Dialoguer.Initialize();
    }
    void Start()
    {
        facing.facingDirection = FACING.Down;
        changeIO();
    }
    void FixedUpdate()
    {
        Vector2 newVelocity = physics.velocity;
        #region ENABLE_UPDATE
        if (global.GetComponent<GlobalVars>().processing == 0)
        {
            enabled = true;
        }
        else
        {
            enabled = false;
        }
        #endregion
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
        #region KEY_EVENTS
        if (enabled)
        {
            #region DOWN_EVENTS
            if (Input.GetKey(down))
            {
                animator.speed = animationSpeed;
                facing.facingDirection = FACING.Down;
                animator.SetInteger("Direction", 2);
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
                animator.speed = animationSpeed;
                facing.facingDirection = FACING.Up;
                animator.SetInteger("Direction", 0);
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
                animator.speed = animationSpeed;
                facing.facingDirection = FACING.Left;
                animator.SetInteger("Direction", 3);
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
                animator.speed = animationSpeed;
                facing.facingDirection = FACING.Right;
                animator.SetInteger("Direction", 1);
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
            #region NO_KEY_EVENTS
            else
            {
                animator.speed = 0.0f;
                newVelocity.x = 0;
                newVelocity.y = 0;
            }
            #endregion
            #region FACING_TRIGGER_UPDATE
            facing.changeFacingTrigger(facing.facingDirection);
            #endregion
            #region PHYSICS_UPDATE
            // Update the rigidbody
            physics.velocity = newVelocity;
            #endregion
        }
        #endregion
    }                                               // Physics Updates (Movement, L-R-U-D Key Events, Collision Detections, Calls to FacingTrigger Methods, etc...
    void Update()                                                       // Other Key Events (Accept)
    {
        #region ACCEPT_EVENTS
        if (enabled)
        {
            if (Input.GetKeyDown(accept))
            {
                foreach (GameObject go in triggeringWith)
                {
                    if (go.tag == "NPC")
                    {
                        if (logging) { Debug.Log("Entering Accept event with " + go.name.ToString()); }
                        go.GetComponent<Facing>().faceObject(this.gameObject);
                        go.GetComponent<Dialogue>().beginDialogue();
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
            accept = global.GetComponent<GlobalVars>().ioSettings[(int)IO_SETTINGS.ACCEPT];
            cancel = global.GetComponent<GlobalVars>().ioSettings[(int)IO_SETTINGS.CANCEL];
            up = global.GetComponent<GlobalVars>().ioSettings[(int)IO_SETTINGS.UP];
            down = global.GetComponent<GlobalVars>().ioSettings[(int)IO_SETTINGS.DOWN];
            right = global.GetComponent<GlobalVars>().ioSettings[(int)IO_SETTINGS.RIGHT];
            left = global.GetComponent<GlobalVars>().ioSettings[(int)IO_SETTINGS.LEFT];
            run = global.GetComponent<GlobalVars>().ioSettings[(int)IO_SETTINGS.RUN];
        }
        catch
        {
            Debug.Log("Error in setting new IO in Field.cs");
        }
    }                                                   // Query Global Vars for Keymap. 
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
    void OnTriggerEnter2D(Collider2D coll)
    {
        triggeringWith.Add(coll.gameObject);
        triggeringIndex++;
        if (logging) { Debug.Log("Entering Trigger Between " + this.name.ToString() + " and " + coll.gameObject.name.ToString()); }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        triggeringWith.Remove(coll.gameObject);
        triggeringIndex--;
        if (logging) { Debug.Log("Exiting Trigger Between " + this.name.ToString() + " and " + coll.gameObject.name.ToString()); }
    }
    void Dialogue(GameObject whichObject)
    {
        whichObject.GetComponent<Dialogue>().beginDialogue();
        return;
    }
}
