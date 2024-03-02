using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class itemtemplate : MonoBehaviour
{
    public InventoryUI ui;
    public uiitem slot;
    public EventTrigger eventTrigger;

    public virtual void useup()
    {
        Debug.Log("used");
        ui.playerinventory.removeItem(slot.index);
    }

    private void Awake()
    {
        slot = transform.parent.gameObject.GetComponent<uiitem>();
        ui = slot.ui;
        eventTrigger = transform.parent.gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventData) => { useup(); });
        eventTrigger.triggers.Add(entry);
    }
    
    
}
