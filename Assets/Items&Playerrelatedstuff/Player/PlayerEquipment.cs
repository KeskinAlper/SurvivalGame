using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public Transform weaponspot;
    public Transform sidearmspot;
    public Transform meleespot;
    public Transform binocsspot;
    public Topdownmoevement movement;
    public Item head;
    public Item torso;
    public Item jacket;
    public Item legs;
    public Item boots;
    public Item hands;
    public Item backpack;
    public Item melee;
    public Item weapon;
    public Item sidearm;
    public Item binocs;
    public int selectedgear;
    bool weaponondhand = false;
    public void spawnGear()
    {
        if(weapon != null && weaponspot.childCount == 0)
            Instantiate(weapon.ingameobj, weaponspot.transform.position + weapon.ingameobj.transform.position, weaponspot.transform.rotation, weaponspot.transform);
        if (melee != null && meleespot.childCount == 0)
            Instantiate(melee.ingameobj, meleespot.transform.position + melee.ingameobj.transform.position, meleespot.transform.rotation, meleespot.transform);
        if (sidearm != null && sidearmspot.childCount == 0)
            Instantiate(sidearm.ingameobj,sidearmspot.transform.position + sidearm.ingameobj.transform.position, sidearmspot.transform.rotation, sidearmspot.transform);
        if (binocs != null && binocsspot.childCount == 0)
            Instantiate(binocs.ingameobj, binocsspot.transform.position + binocs.ingameobj.transform.position, binocsspot.transform.rotation, binocsspot.transform);

        if (meleespot.childCount > 0)
            meleespot.GetChild(0).gameObject.SetActive(false);
        if (weaponspot.childCount > 0)
            weaponspot.GetChild(0).gameObject.SetActive(false);
        if (sidearmspot.childCount > 0)
            sidearmspot.GetChild(0).gameObject.SetActive(false);
        if (binocsspot.childCount > 0)
            binocsspot.GetChild(0).gameObject.SetActive(false);
    }
    public void deleteGear()
    {
        if (weapon == null && weaponspot.childCount > 0)
        {
            Destroy(weaponspot.GetChild(0).gameObject);
        }
        if (sidearm == null && sidearmspot.childCount > 0)
        {
            Destroy(sidearmspot.GetChild(0).gameObject);
        }
        if (melee == null && meleespot.childCount > 0)
        {
            Destroy(meleespot.GetChild(0).gameObject);
        }
        if (binocs == null && binocsspot.childCount > 0)
        {
            Destroy(binocsspot.GetChild(0).gameObject);
        }
    }
    private void Start()
    {
        movement = gameObject.GetComponent<Topdownmoevement>();
    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                selectedgear = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                selectedgear = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                selectedgear = 3;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                selectedgear = 4;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
            if(weaponondhand)
        {
                weaponondhand = !weaponondhand;

            if(meleespot.childCount > 0)
                meleespot.GetChild(0).gameObject.SetActive(false);
            if (weaponspot.childCount > 0)
                weaponspot.GetChild(0).gameObject.SetActive(false);
            if (sidearmspot.childCount > 0)
                sidearmspot.GetChild(0).gameObject.SetActive(false);
            if (binocsspot.childCount > 0)
                binocsspot.GetChild(0).gameObject.SetActive(false);

            
        }
            else
        {
                weaponondhand = !weaponondhand;
            if (selectedgear == 1 && meleespot.childCount > 0)
            {
                meleespot.GetChild(0).gameObject.SetActive(true);

            }
            else if (selectedgear == 2 && weaponspot.childCount > 0)
            {
                weaponspot.GetChild(0).gameObject.SetActive(true);
            }
            else if (selectedgear == 3 && sidearmspot.childCount > 0 )
            {
                sidearmspot.GetChild(0).gameObject.SetActive(true);
            }
            else if (selectedgear == 4 && binocsspot.childCount > 0)
            {
                binocsspot.GetChild(0).gameObject.SetActive(true);
            }
            
        }

        if (weaponondhand)
            movement.runstate = 0; 
    }

}
