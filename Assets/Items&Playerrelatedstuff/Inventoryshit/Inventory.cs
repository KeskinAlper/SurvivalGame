using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item[]  inventory = new Item[100];
    float initialspeed;
    public float currentspeedmod;
    Topdownmoevement movement;
    public float maxweight;
    public float totalweight;
    public InventoryUI ui;
    private void Awake()
    {
        movement = gameObject.GetComponent<Topdownmoevement>();
        initialspeed = movement.speedconfig;
    }
    public bool addItem(Item item)
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                totalweight += item.weight;
                changeSpeedMod();
                ui.refresh(i);
                return true;
            }                        
        }
        return false;
    }
    public void removeItem(int index)
    {
        totalweight -= inventory[index].weight;
        changeSpeedMod();
        inventory[index] = null;
        ui.refresh(index);
    }
    public void changeSpeedMod()
    {
        currentspeedmod = initialspeed * (1 - (totalweight / maxweight) / 2);
        movement.speedconfig = currentspeedmod;
    }
}
