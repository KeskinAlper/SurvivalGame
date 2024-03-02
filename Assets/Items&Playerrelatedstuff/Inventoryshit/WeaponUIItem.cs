using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUIItem : itemtemplate
{
    public Item item;
    public override void useup()
    {
        if (ui.equipment.weapon == null)
        {
            ui.equipment.weapon = item;
            ui.refreshequipment();
            base.useup();
        }      
    }
    
    
        
    
}
