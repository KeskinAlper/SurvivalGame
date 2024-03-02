using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class Item : ScriptableObject
{
    public string itemname;
    public string description;
    public bool isequipment;
    public bool ismedkit;
    public int id;
    public float weight;
    public GameObject invuiitem;
    public GameObject ingameobj;
}
