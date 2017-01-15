using UnityEngine;
using System.Collections;

public enum FACING
{
    Default,
    Up,
    Left,
    Right,
    Down
};                                                         // Enumerator for Facing Position

public class Facing : MonoBehaviour {

    public FACING facingDirection;
    public BoxCollider2D colliderTrigger;

    public bool isFacing(GameObject go)
    {
        FACING objectFacing = go.GetComponent<Facing>().facingDirection;
        if(objectFacing == null)
        {
            throw new System.Exception("ERROR: Facing script not attached to " + go.name.ToString());
        }
        if (facingDirection == FACING.Up && objectFacing == FACING.Down) { return true; }
        else if (facingDirection == FACING.Down && objectFacing == FACING.Up) { return true; }
        else if (facingDirection == FACING.Left && objectFacing == FACING.Right) { return true; }
        else if (facingDirection == FACING.Right && objectFacing == FACING.Left) { return true; }
        else { return false; }
    }                                   // Returns true if the GameObject go and this GameObject are facing each other
    public void faceObject(GameObject go)
    {
        FACING newDirection = FACING.Default;
        Facing facing = go.GetComponent<Facing>();
        switch (facing.facingDirection)
        {
            case FACING.Right:
                newDirection = FACING.Left;
                break;
            case FACING.Left:
                newDirection = FACING.Right;
                break;
            case FACING.Up:
                newDirection = FACING.Down;
                break;
            case FACING.Down:
                newDirection = FACING.Up;
                break;
        }
        facingDirection = newDirection;
        return;
    }
    public void changeFacingTrigger(FACING which)
    {
        Vector2 offset = new Vector2(0, 0);
        Vector2 size = new Vector2(0, 0);
        switch (which)
        {
            case FACING.Down:
                offset = new Vector2(0f, -48f);
                size = new Vector2(32f, 32f);
                break;
            case FACING.Up:
                offset = new Vector2(0f, 16f);
                size = new Vector2(32f, 32f);
                break;
            case FACING.Left:
                offset = new Vector2(-32f, -16f);
                size = new Vector2(32f, 32f);
                break;
            case FACING.Right:
                offset = new Vector2(32f, -16f);
                size = new Vector2(32f, 32f);
                break;
        }

        colliderTrigger.offset = offset;
        colliderTrigger.size = size;
        return;
    }
}
