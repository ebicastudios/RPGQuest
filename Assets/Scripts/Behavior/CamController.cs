using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour {

    public GameObject fader;

    public bool isFollowingPlayer = false;

    void Update()
    {
        if (isFollowingPlayer)
        {
            Vector3 newPosition = GameObject.Find("PlayerField").GetComponent<Transform>().position;
            newPosition.z -= 100;
            this.GetComponent<Transform>().position = newPosition;
        }
    }
}
