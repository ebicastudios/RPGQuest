/* Variables.cs
 * Description:     Stores any and all non-local function variables and
 *                  associated enumerators. Accessed by all objects.
 *                  
 * Created by:      Brandon Bush (ebicastudios@gmail.com)
 * Last Modified:   12/26/2016
 * ExceptionSafety: Undetermined
 * License:         Ebica Studios Closed Source
 */


using UnityEngine;
using System;
using System.Collections;
using System.IO;


#region ENUMERATORS
public enum DIFFICULTY                                                                      // Enumerator storing difficulty values
{
    EASY = 0,
    NORMAL = 1,
    HARD = 2
}

#endregion


public class Variables : MonoBehaviour {

    #region DEBUGGER_FLAGS
    [Header("Debug Flags")]
    public bool loggingDirectoryCheck = true;                                                          // If true, debug messages when checking the filestructure will be sent to the console
    #endregion

    #region INTEGRITY_FLAGS
    [Header("Integrity Flags")]
    public bool sav1IsCorrupted = false;
    public bool sav2IsCorrupted = false;
    public bool sav3IsCorrupted = false;
    public bool BackupSav1IsCorrupted = false;
    public bool BackupSav2IsCorrupted = false;
    public bool BackupSav3IsCorrupted = false;
    #endregion

    #region ENUMERATED_VALUES
    [Header("Game Difficulty")]
    public DIFFICULTY game_difficulty;                                                          // Stores the game difficulty
    #endregion

    #region KEYCODE_VALUES
    [Header("Key Values")]                                                                      
    public string leftArrow;                                                                    // Key Value for the left input ("left" by default)
    public string rightArrow;                                                                   // Key Value for the right input ("right" by default)
    public string upArrow;                                                                      // Key Value for the up input ("up" by default)
    public string downArrow;                                                                    // Key Value for the down input ("down" by default)
    public string enter;                                                                        // Key Value for the select input ("return" by default)
    public string back;                                                                         // Key Value for the back input ("esc" by default)
    #endregion

    #region PATHS
    [Header("Filepaths")]
    public string path_base;
    public string path_dat;
    public string path_sav1;
    public string path_sav2;
    public string path_sav3;
    public string path_sav1_backup;
    public string path_sav2_backup;
    public string path_sav3_backup;
    public string path_corrupt;

    public string path_settings;
    #endregion

    void Awake()                                                                                // Initialization
    {
        // Check the directories and make sure they exist
        #region DIRECTORY_CHECK
        if (!Directory.Exists(path_dat))
        {
            Directory.CreateDirectory(path_dat);
            if (loggingDirectoryCheck) { Debug.Log("Filepath " + path_dat + " not found. Creating directory"); }
        }
        if (!Directory.Exists(path_sav1))
        {
            Directory.CreateDirectory(path_sav1);
            if (loggingDirectoryCheck) { Debug.Log("Filepath " + path_sav1 + " not found. Creating directory"); }
        }
        if (!Directory.Exists(path_sav2))
        {
            Directory.CreateDirectory(path_sav2);
            if (loggingDirectoryCheck) { Debug.Log("Filepath " + path_sav2 + " not found. Creating directory"); }
        }
        if (!Directory.Exists(path_sav3))
        {
            Directory.CreateDirectory(path_sav3);
            if (loggingDirectoryCheck) { Debug.Log("Filepath " + path_sav3 + " not found. Creating directory"); }
        }
        if (!Directory.Exists(path_sav1_backup))
        {
            Directory.CreateDirectory(path_sav1_backup);
            if (loggingDirectoryCheck) { Debug.Log("Filepath " + path_sav1_backup + " not found. Creating directory"); }
        }
        if (!Directory.Exists(path_sav2_backup))
        {
            Directory.CreateDirectory(path_sav2_backup);
            if (loggingDirectoryCheck) { Debug.Log("Filepath " + path_sav2_backup + " not found. Creating directory"); }
        }
        if (!Directory.Exists(path_sav3_backup))
        {
            Directory.CreateDirectory(path_sav3_backup);
            if (loggingDirectoryCheck) { Debug.Log("Filepath " + path_sav3_backup + " not found. Creating directory"); }
        }
        #endregion

        // Check the files and make sure they exist
        #region FILE_CHECK
        if (!File.Exists(path_settings))
        {
            if (loggingDirectoryCheck) { Debug.Log("File " + path_settings + " not found. Creating File"); }
            createSettings();
        }

        // Check if Sav files exists or have been corrupted
        if (!File.Exists(path_sav1 + "toc.dat"))                                                                     // sav1
        {
            sav1IsCorrupted = true;
            if (loggingDirectoryCheck) { Debug.Log("File " + path_sav1 + "toc.dat not found."); }
        }
        else if (!File.Exists(path_sav1 + "c1.dat"))
        {
            sav1IsCorrupted = true;
            if (loggingDirectoryCheck) { Debug.Log("File " + path_sav1 + "c1.dat not found."); }
        }
        else if (!File.Exists(path_sav1 + "c2.dat"))
        {
            sav1IsCorrupted = true;
            if (loggingDirectoryCheck) { Debug.Log("File " + path_sav1 + "c2.dat not found."); }
        }
        else if (!File.Exists(path_sav1 + "c3.dat"))
        {
            sav1IsCorrupted = true;
            if (loggingDirectoryCheck) { Debug.Log("File " + path_sav1 + "c3.dat not found."); }
        }
        else if (!File.Exists(path_sav1 + "c4.dat"))
        {
            sav1IsCorrupted = true;
            if (loggingDirectoryCheck) { Debug.Log("File " + path_sav1 + "c4.dat not found."); }
        }
        else if (!File.Exists(path_sav1 + "c5.dat"))
        {
            sav1IsCorrupted = true;
            if (loggingDirectoryCheck) { Debug.Log("File " + path_sav1 + "c5.dat not found."); }
        }

        if (!File.Exists(path_sav2 + "toc.dat"))                                                                            // sav2
        {
            sav2IsCorrupted = true;
            if (loggingDirectoryCheck) { Debug.Log("File " + path_sav1 + "toc.dat not found."); }
        }
        else if (!File.Exists(path_sav2 + "c1.dat"))
        {
            sav2IsCorrupted = true;
            if (loggingDirectoryCheck) { Debug.Log("File " + path_sav1 + "c1.dat not found."); }
        }
        else if (!File.Exists(path_sav2 + "c2.dat"))
        {
            sav2IsCorrupted = true;
            if (loggingDirectoryCheck) { Debug.Log("File " + path_sav1 + "c2.dat not found."); }
        }
        else if (!File.Exists(path_sav2 + "c3.dat"))
        {
            sav2IsCorrupted = true;
            if (loggingDirectoryCheck) { Debug.Log("File " + path_sav1 + "c3.dat not found."); }
        }
        else if (!File.Exists(path_sav2 + "c4.dat"))
        {
            sav2IsCorrupted = true;
            if (loggingDirectoryCheck) { Debug.Log("File " + path_sav1 + "c4.dat not found."); }
        }
        else if (!File.Exists(path_sav2 + "c5.dat"))
        {
            sav2IsCorrupted = true;
            if (loggingDirectoryCheck) { Debug.Log("File " + path_sav1 + "c5.dat not found."); }
        }

        if (!File.Exists(path_sav3 + "toc.dat"))                                                                // sav3
        {
            sav3IsCorrupted = true;
            if (loggingDirectoryCheck) { Debug.Log("File " + path_sav1 + "toc.dat not found."); }
        }
        else if (!File.Exists(path_sav3 + "c1.dat"))
        {
            sav3IsCorrupted = true;
            if (loggingDirectoryCheck) { Debug.Log("File " + path_sav1 + "c1.dat not found."); }
        }
        else if (!File.Exists(path_sav3 + "c2.dat"))
        {
            sav3IsCorrupted = true;
            if (loggingDirectoryCheck) { Debug.Log("File " + path_sav1 + "c2.dat not found."); }
        }
        else if (!File.Exists(path_sav3 + "c3.dat"))
        {
            sav3IsCorrupted = true;
            if (loggingDirectoryCheck) { Debug.Log("File " + path_sav1 + "c3.dat not found."); }
        }
        else if (!File.Exists(path_sav3 + "c4.dat"))
        {
            sav3IsCorrupted = true;
            if (loggingDirectoryCheck) { Debug.Log("File " + path_sav1 + "c4.dat not found."); }
        }
        else if (!File.Exists(path_sav3 + "c5.dat"))
        {
            sav3IsCorrupted = true;
            if (loggingDirectoryCheck) { Debug.Log("File " + path_sav1 + "c5.dat not found."); }
        }

        // Construct the files if they are missing/corrupted
        if (sav1IsCorrupted)
        {
            constructSave(1);
        }
        if (sav2IsCorrupted)
        {
            constructSave(2);
        }
        if (sav3IsCorrupted)
        {
            constructSave(3);
        }
    }

    void createSettings()                                                           // If the settings file is missing, create a default one
    {
        if (loggingDirectoryCheck) { Debug.Log("Creating settings file"); }

        string writeOut;

        writeOut = "<LEFTARROW><" + leftArrow + ">" + Environment.NewLine;
        writeOut += "<RIGHTARROW><" + rightArrow + ">" + Environment.NewLine;
        writeOut += "<UPARROW><" + upArrow + ">" + Environment.NewLine;
        writeOut += "<DOWNARROW><" + downArrow + ">" + Environment.NewLine;
        writeOut += "<ENTER><" + enter + ">" + Environment.NewLine;
        writeOut += "<BACK><" + back + ">" + Environment.NewLine;
        
        using(StreamWriter sw = new StreamWriter(path_settings))
        {
            sw.Write(writeOut);
            if (loggingDirectoryCheck) { Debug.Log("Settings File Written"); }
        }
    }
    void constructSave(int which)
    {
        string basePath;
        switch (which)
        {
            case 1:
                basePath = path_sav1;
                break;
            case 2:
                basePath = path_sav2;
                break;
            case 3:
                basePath = path_sav3;
                break;
        }

        // Move any files that currently exist in the directory to a special folder
        if (!Directory.Exists(path_corrupt))
        {
            if (loggingDirectoryCheck) { Debug.Log("Path " + path_sav1 + " corrupted. Constructing files"); }
            Directory.CreateDirectory(path_corrupt);
        }
    }
        #endregion

        // Saving Functions
        #region SAVE_LOAD

    public void Save(int which)
    {
        string path = "";
        string bpath = "";
        switch (which)
        {
            case 0:
                path = path_sav1;
                bpath = path_sav1_backup;
                break;
            case 1:
                path = path_sav2;
                bpath = path_sav2_backup;
                break;
            case 2:
                path = path_sav3;
                bpath = path_sav3_backup;
                break;
            default:
                throw new System.Exception("Invalid save file selected. In Variables.cs saveGame(int which)");
        }
        // Backup current toc file
        path += "toc.dat";
        bpath += "toc.dat";

        if (File.Exists(bpath))
        {
            File.Delete(bpath);
        }
        if (File.Exists(path))
        {
            File.Copy(path, bpath);
        }

        // Serialize the data
        string write_out = "";
        write_out += "<DIFFICULTY><" + game_difficulty.ToString() + "><END>" + Environment.NewLine;

        using(StreamWriter sw = new StreamWriter(path))
        {
            sw.Write(write_out);
        }


    }
        #endregion
    
}
