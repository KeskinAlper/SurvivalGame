using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DescboxFunctionality : MonoBehaviour
{
    public GameObject itemname;
    public GameObject description;
    public GameObject drop;
    public GameObject use;
    public PlayerEquipment equipment;
    public PlayerLimbsHealth limbs;
    public InventoryUI ui;
    public Item item;
    public uiitem slot;
    public int equipmentindex;
    public float limbmendamount;
    public void useup()
    {
        Debug.Log("used");
        ui.playerinventory.removeItem(slot.index);
    }
    private void Start()
    {
        itemname.GetComponent<TextMeshProUGUI>().text = item.name;
        description.GetComponent<TextMeshProUGUI>().text = item.description;
       
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Destroy(gameObject);
        }
    }
    public void addFunctiontoUse()
    {
        if(item.isequipment == true)
        {
            addtoEquipment();
        }
        else if(item.ismedkit == true)
        {
            mendLimbs();
        }
    }
    public void addtoEquipment()
    {
        switch (equipmentindex)
        {
            case 0:
                if (equipment.head == null)
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
        Destroy(gameObject);
    }
    public void Drop()
    {
        Debug.Log("Droped");
    }
    
   public void mendLimbs()
    {
        limbs.head += limbmendamount;
        limbs.head = Mathf.Clamp(limbs.head, 0, 100);
        limbs.torso += limbmendamount;
        limbs.torso = Mathf.Clamp(limbs.torso, 0, 100);
        limbs.rightarm += limbmendamount;
        limbs.rightarm = Mathf.Clamp(limbs.rightarm, 0, 100);
        limbs.righthand += limbmendamount;
        limbs.righthand = Mathf.Clamp(limbs.righthand, 0, 100);
        limbs.leftarm += limbmendamount;
        limbs.leftarm = Mathf.Clamp(limbs.leftarm, 0, 100);
        limbs.lefthand += limbmendamount;
        limbs.lefthand = Mathf.Clamp(limbs.lefthand, 0, 100);
        limbs.rightleg += limbmendamount;
        limbs.rightleg = Mathf.Clamp(limbs.rightleg, 0, 100);
        limbs.rightfoot += limbmendamount;
        limbs.rightfoot = Mathf.Clamp(limbs.rightfoot, 0, 100);
        limbs.leftleg += limbmendamount;
        limbs.leftleg = Mathf.Clamp(limbs.leftleg, 0, 100);
        limbs.leftfoot += limbmendamount;
        limbs.leftfoot = Mathf.Clamp(limbs.leftfoot, 0, 100);
        limbs.limbsui.updateLimbs();
        useup();
    }
}
