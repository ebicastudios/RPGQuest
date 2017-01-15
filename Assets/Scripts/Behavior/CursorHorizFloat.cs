using UnityEngine;
using System.Collections;

public class CursorHorizFloat : MonoBehaviour {

    public enum DIRECTION
    {
        LEFT = 0,
        RIGHT
    }

    public bool enabled = false;
    public DIRECTION currentDirection;
    public float factor = 0;

    void Update()
    {
        if (enabled)
        {
            Vector3 startPosition = this.GetComponent<RectTransform>().position;
            if (currentDirection == DIRECTION.RIGHT)
            {
                startPosition.x += factor;
            }
            else if (currentDirection == DIRECTION.LEFT)
            {
                startPosition.x -= factor;
            }
        }
    }
}
