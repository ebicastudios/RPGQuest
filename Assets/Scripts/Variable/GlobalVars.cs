using UnityEngine;
using System.Collections;

public enum IO_SETTINGS
{
    LEFT = 0,
    RIGHT = 1,
    DOWN = 2,
    UP = 3,
    ACCEPT = 4,
    CANCEL = 5,
    RUN = 6
};


public class GlobalVars : MonoBehaviour {

    [Header("Debug Flags")]
    public bool initialized = false;
    public int processing = 0;                                                             // Used by FieldController to determine whether or not to accept input

    [Header("KeyMaps")]
    public string[] ioSettings;

    void Awake()
    {
        ioSettings = new string[7];
        // Place loading of settings here
        {
            // Eventually replace this with code that checks an initialization file for settings
            ioSettings[(int)IO_SETTINGS.LEFT] = "left";
            ioSettings[(int)IO_SETTINGS.RIGHT] = "right";
            ioSettings[(int)IO_SETTINGS.DOWN] = "down";
            ioSettings[(int)IO_SETTINGS.UP] = "up";
            ioSettings[(int)IO_SETTINGS.ACCEPT] = "return";
            ioSettings[(int)IO_SETTINGS.CANCEL] = "backspace";
            ioSettings[(int)IO_SETTINGS.RUN] = "left shift";
        }
    }

    void Start()
    {
    }
}
