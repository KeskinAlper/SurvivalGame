using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    public Inventory playerinventory;
    public PlayerEquipment equipment;
    public PlayerLimbsHealth limbs;
    public GameObject invuiobject;
    public GameObject equipmentyiobject;
    public int skipobjects;
    public List<GameObject> slots;
    public GameObject[] equipmentslots = new GameObject[11];
    public GameObject weigthdisplay;
    void Awake()
    {
        for(int i = skipobjects; i < playerinventory.inventory.Length; i++)
        {
            var slot = invuiobject.transform.GetChild(i).gameObject;
            slots.Add(slot);
            var item = slot.GetComponent<uiitem>();
            item.index = i - skipobjects;
            item.ui = this;
        }
        refreshequipment();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.anyKeyDown)
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
                invuiobject.SetActive(!invuiobject.activeSelf);
                equipmentyiobject.SetActive(!equipmentyiobject.activeSelf);
            }
        }

    }
    public void refresh(int index)
    {
        var itemininv = playerinventory.inventory[index];
        if (itemininv != null)
        {
            Instantiate(itemininv.invuiitem, slots[index].transform);
            RectTransform rect = slots[index].GetComponent<RectTransform>();
            RectTransform itemrect = itemininv.invuiitem.GetComponent<RectTransform>();
            rect.rect.Set(rect.rect.x,rect.rect.y,itemrect.rect.width, itemrect.rect.height);
            slots[index].SetActive(true);
        }
        else
        {
            Destroy( slots[index].transform.GetChild(0).gameObject);
            slots[index].SetActive(false);
        }
        weigthdisplay.GetComponent<TextMeshProUGUI>().text = playerinventory.totalweight + "/" + playerinventory.maxweight;
    }
    public void refreshequipment()
    {
        if (equipment.head == null)
        {
            equipmentslots[0].GetComponent<Image>().sprite = null;
        }
        else
        {
            equipmentslots[0].GetComponent<Image>().sprite = equipment.head.invuiitem.GetComponent<Image>().sprite;
        }
        if (equipment.torso == null)
        {
            equipmentslots[1].GetComponent<Image>().sprite = null;
        }
        else
        {
            equipmentslots[1].GetComponent<Image>().sprite = equipment.torso.invuiitem.GetComponent<Image>().sprite;
        }
        if (equipment.jacket == null)
        {
            equipmentslots[2].GetComponent<Image>().sprite = null;
        }
        else
        {
            equipmentslots[2].GetComponent<Image>().sprite = equipment.jacket.invuiitem.GetComponent<Image>().sprite;
        }
        if (equipment.legs == null)
        {
            equipmentslots[3].GetComponent<Image>().sprite = null;
        }
        else
        {
            equipmentslots[3].GetComponent<Image>().sprite = equipment.legs.invuiitem.GetComponent<Image>().sprite;
        }
        if (equipment.boots == null)
        {
            equipmentslots[4].GetComponent<Image>().sprite = null;
        }
        else
        {
            equipmentslots[4].GetComponent<Image>().sprite = equipment.boots.invuiitem.GetComponent<Image>().sprite;
        }
        if (equipment.hands == null)
        {
            equipmentslots[5].GetComponent<Image>().sprite = null;
        }
        else
        {
            equipmentslots[5].GetComponent<Image>().sprite = equipment.hands.invuiitem.GetComponent<Image>().sprite;
        }
        if (equipment.backpack == null)
        {
            equipmentslots[6].GetComponent<Image>().sprite = null;
        }
        else
        {
            equipmentslots[6].GetComponent<Image>().sprite = equipment.backpack.invuiitem.GetComponent<Image>().sprite;
        }
        if (equipment.melee == null)
        {
            equipmentslots[7].GetComponent<Image>().sprite = null;
        }
        else
        {
            equipmentslots[7].GetComponent<Image>().sprite = equipment.melee.invuiitem.GetComponent<Image>().sprite;
        }
        if (equipment.weapon == null)
        {
            equipmentslots[8].GetComponent<Image>().sprite = null;
        }
        else
        {
            equipmentslots[8].GetComponent<Image>().sprite = equipment.weapon.invuiitem.GetComponent<Image>().sprite;
        }
        if (equipment.sidearm == null)
        {
            equipmentslots[9].GetComponent<Image>().sprite = null;
        }
        else
        {
            equipmentslots[9].GetComponent<Image>().sprite = equipment.sidearm.invuiitem.GetComponent<Image>().sprite;
        }
        if (equipment.binocs == null)
        {
            equipmentslots[10].GetComponent<Image>().sprite = null;
        }
        else
        {
            equipmentslots[10].GetComponent<Image>().sprite = equipment.binocs.invuiitem.GetComponent<Image>().sprite;
        }
    }
}
