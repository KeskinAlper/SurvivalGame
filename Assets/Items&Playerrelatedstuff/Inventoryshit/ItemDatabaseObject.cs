using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/database", order = 2)]

public class ItemDatabaseObject : ScriptableObject
{
    public List<Item> database;
}
