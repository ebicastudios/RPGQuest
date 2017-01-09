using UnityEngine;
using System;
using System.Collections;
using System.IO;

public class Character : MonoBehaviour {

    public string characterName;

    [Header("Derived Statistics")]
    [Tooltip("Physical Potency:\nRepresents characters aptitude at inflicting physical damage")]
    public int ppot;
    [Tooltip("Magical Potency:\nRepresents characters aptitude at inflicting magical damage")]
    public int mpot;
    [Tooltip("Physical Defense:\nRepresents characters ability to mitigate physical damage")]
    public int pdef;
    [Tooltip("Magical Defense:\nRepresents characters ability to mitigate magical damage")]
    public int mdef;
    [Tooltip("Dodge:\nRepresents characters percentage chance to completely dodge an incoming physical attack")]
    public float dodge;
    [Tooltip("Concentration:\nRepresents characters percentage chance to completely dodge an incoming magical attack")]
    public float concentration;

    // Should only be called by the Variable script
    public void Save(int which)
    {
        // Set the directory
        string path;
        switch (which)
        {
            case 0:
                path = GameObject.Find("Variables").GetComponent<Variables>().path_sav1;
                break;
            case 1:
                path = GameObject.Find("Variables").GetComponent<Variables>().path_sav2;
                break;
            case 2:
                path = GameObject.Find("Variables").GetComponent<Variables>().path_sav2;
                break;
            default:
                throw new System.Exception("Invalid case for save path");
        }

        // Backup Path
        string bpath = path + "\\bup";

        if(this.name == "Warrior")
        {
            path += "c1.dat";
            bpath += "\\c1.dat";
        }
        else if (this.name == "Mage")
        {
            path += "c2.dat";
            bpath += "\\c2.dat";
        }
        else if (this.name == "Thief")
        {
            path += "c3.dat";
            bpath += "\\c3.dat";
        }
        else if (this.name == "Archer")
        {
            path += "c4.dat";
            bpath += "\\c4.dat";
        }
        else if (this.name == "Bard")
        {
            path += "c5.dat";
            bpath += "\\c5.dat";
        }
        else
        {
            throw new System.Exception("Invalid name on GameObject. Object is not Warrior, Mage, Thief, Archer, or Bard");
        }
        Debug.Log(path + Environment.NewLine + bpath);
        // Backup the last save into /bup
        if (File.Exists(bpath))
        {
            File.Delete(bpath);
        }
        File.Copy(path, bpath);

        // Serialize the information
        string write_out = "";

        write_out += "<NAME><" + characterName + "><END_NAME>" + Environment.NewLine;
        write_out += "<PPOT><" + ppot.ToString() + "><END_PPOT>" + Environment.NewLine;
        write_out += "<MPOT><" + mpot.ToString() + "><END_MPOT>" + Environment.NewLine;
        write_out += "<PDEF><" + pdef.ToString() + "><END_PDEF>" + Environment.NewLine;
        write_out += "<MDEF><" + pdef.ToString() + "><END_MDEF>" + Environment.NewLine;
        write_out += "<DODGE><" + dodge.ToString() + "><END_DODGE>" + Environment.NewLine;
        write_out += "<CONCENTRATION><" + concentration.ToString() + "><END_CONCENTRATION>" + Environment.NewLine;
        Debug.Log(write_out);

        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.Write(write_out);
        }
    }
}
