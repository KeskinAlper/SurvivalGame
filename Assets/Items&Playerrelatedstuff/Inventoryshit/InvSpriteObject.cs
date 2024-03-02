using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvSpriteObject : MonoBehaviour
{
    public Item item;
    public InventoryUI ui;
    PlayerEquipment equipment;
    PlayerLimbsHealth limbs;
    public uiitem slot;
    public EventTrigger eventTrigger;
    public int equipmentidindex;
    public float limbmendamount;
    public GameObject descbox;
    GameObject desc;
    public  void useup()
    {
        Debug.Log("used");
        ui.playerinventory.removeItem(slot.index);
    }

    private void Awake()
    {
        slot = transform.parent.gameObject.GetComponent<uiitem>();
        ui = slot.ui;
        equipment = ui.equipment;
        eventTrigger = transform.parent.gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventData) => { spawnDescBox(); });
        eventTrigger.triggers.Add(entry);
    }
    public void spawnDescBox()
    {
        if (transform.childCount == 0)
        {
            desc = Instantiate(descbox, Input.mousePosition, descbox.transform.rotation, transform);
            DescboxFunctionality descfunc = desc.GetComponent<DescboxFunctionality>();
            descfunc.equipment = equipment;
            descfunc.ui = ui;
            descfunc.item = item;
            descfunc.slot = slot;
            descfunc.equipmentindex = equipmentidindex;
            descfunc.limbmendamount = limbmendamount;
            descfunc.limbs = ui.limbs;
        }
    }
    public void addtoEquipment(int indis)
    {
        switch (indis)
        {
            case 0:
                if(equipment.head == null)
                {
                    equipment.head = item;
                    ui.refreshequipment();
                    useup();
                }              
                break;
            case 1:
                if (equipment.torso == null)
                {
                    equipment.torso = item;
                    ui.refreshequipment();
                    useup();
                }
                break;
            case 2:
                if (equipment.jacket == null)
                {
                    equipment.jacket = item;
                    ui.refreshequipment();
                    useup();
                }
                break;
            case 3:
                if (equipment.legs == null)
                {
                    equipment.legs = item;
                    ui.refreshequipment();
                    useup();
                }
                break;
            case 4:
                if (equipment.boots == null)
                {
                    equipment.boots = item;
                    ui.refreshequipment();
                    useup();
                }
                break;
            case 5:
                if (equipment.hands == null)
                {
                    equipment.hands = item;
                    ui.refreshequipment();
                    useup();
                }
                break;
            case 6:
                if (equipment.backpack == null)
                {
                    equipment.backpack = item;
                    ui.refreshequipment();
                    useup();
                }
                break;
            case 7:
                if (equipment.melee == null)
                {
                    equipment.melee = item;
                    ui.refreshequipment();
                    equipment.spawnGear();
                    useup();
                }
                break;
            case 8:
                if (equipment.weapon == null)
                {
                    equipment.weapon = item;
                    ui.refreshequipment();
                    equipment.spawnGear();
                    useup();
                }
                break;
            case 9:
                if (equipment.sidearm == null)
                {
                    equipment.sidearm = item;
                    ui.refreshequipment();
                    equipment.spawnGear();
                    useup();
                }
                break;
            case 10:
                if (equipment.binocs == null)
                {
                    equipment.binocs = item;
                    ui.refreshequipment();
                    equipment.spawnGear();
                    useup();
                }
                break;
        }
        
    }
    
}
