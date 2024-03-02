using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipmentslot : MonoBehaviour
{
    InventoryUI ui;
    PlayerEquipment equipment;
    Inventory inv;
    // Start is called before the first frame update
    void Start()
    {
        ui = GetComponentInParent<InventoryUI>();
        equipment = ui.equipment;
        inv = ui.playerinventory;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void sendBacktoInv(int indis)
    {
        switch (indis)
        {
            case 0:
                if (equipment.head != null)
                {
                    inv.addItem(equipment.head);
                    equipment.head = null;
                    ui.refreshequipment();
                }
                break;
            case 1:
                if (equipment.torso != null)
                {
                    inv.addItem(equipment.torso);
                    equipment.torso = null;
                    ui.refreshequipment();
                }
                break;
            case 2:
                if (equipment.jacket != null)
                {
                    inv.addItem(equipment.jacket);
                    equipment.jacket = null;
                    ui.refreshequipment();
                }
                break;
            case 3:
                if (equipment.legs != null)
                {
                    inv.addItem(equipment.legs);
                    equipment.legs = null;
                    ui.refreshequipment();
                }
                break;
            case 4:
                if (equipment.boots != null)
                {
                    inv.addItem(equipment.boots);
                    equipment.boots = null;
                    ui.refreshequipment();
                }
                break;
            case 5:
                if (equipment.hands != null)
                {
                    inv.addItem(equipment.hands);
                    equipment.hands = null;
                    ui.refreshequipment();
                }
                break;
            case 6:
                if (equipment.backpack != null)
                {
                    inv.addItem(equipment.backpack);
                    equipment.backpack = null;
                    ui.refreshequipment();
                }
                break;
            case 7:
                if (equipment.melee != null)
                {
                    inv.addItem(equipment.melee);
                    equipment.melee = null;
                    ui.refreshequipment();
                    equipment.deleteGear();
                }
                break;
            case 8:
                if (equipment.weapon != null)
                {
                    inv.addItem(equipment.weapon);
                    equipment.weapon = null;
                    ui.refreshequipment();
                    equipment.deleteGear();
                }
                break;
            case 9:
                if (equipment.sidearm != null)
                {
                    inv.addItem(equipment.sidearm);
                    equipment.sidearm = null;
                    ui.refreshequipment();
                    equipment.deleteGear();
                }
                break;
            case 10:
                if (equipment.binocs != null)
                {
                    inv.addItem(equipment.binocs);
                    equipment.binocs = null;
                    ui.refreshequipment();
                    equipment.deleteGear();
                }
                break;
        }
    }
}
