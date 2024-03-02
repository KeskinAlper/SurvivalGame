using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaver : MonoBehaviour
{
    public ItemDatabaseObject database;
    public GameStateObject gamestate;
    Inventory inv;
    InventoryUI ui;
    PlayerEquipment equipment;
    PlayerLimbsHealth limbs;
    PlayerNutrition nutrition;
    private IDataService DataService = new JsonDataService();
    private void Start()
    {
        inv = gameObject.GetComponent<Inventory>();
        ui = inv.ui;
        equipment = gameObject.GetComponent<PlayerEquipment>();
        limbs = gameObject.GetComponent<PlayerLimbsHealth>();
        nutrition = gameObject.GetComponent<PlayerNutrition>();

        

        if (gamestate.isnewgame == false)
        {
            PlayerDataForSaving newsave = DataService.LoadData<PlayerDataForSaving>("/player.json", false);

            Debug.Log(newsave.pos[0]);
            gameObject.transform.position += new Vector3(newsave.pos[0], newsave.pos[1], newsave.pos[2]);
            
            limbs.torso = newsave.limbs[0];
            limbs.head = newsave.limbs[1];
            limbs.rightarm = newsave.limbs[2];
            limbs.righthand = newsave.limbs[3];
            limbs.leftarm = newsave.limbs[4];
            limbs.lefthand = newsave.limbs[5];
            limbs.rightleg = newsave.limbs[6];
            limbs.rightfoot = newsave.limbs[7];
            limbs.leftleg = newsave.limbs[8];
            limbs.leftfoot = newsave.limbs[9];

            nutrition.thirst = newsave.nutrition[0];
            nutrition.calories = newsave.nutrition[1];
            nutrition.minerals = newsave.nutrition[2];
            nutrition.vitamins = newsave.nutrition[3];
            nutrition.protein = newsave.nutrition[4];

            for (int i = 0; i < 100; i++)
            {
                if (newsave.invids[i] != 0)
                    inv.addItem(database.database[newsave.invids[i]]);
            }

            if (newsave.equipmentids[0] != 0)
            {
                equipment.head = database.database[newsave.equipmentids[0]];
                ui.refreshequipment();
            }
            if (newsave.equipmentids[1] != 0)
            {
                equipment.torso = database.database[newsave.equipmentids[1]];
                ui.refreshequipment();
            }
            if (newsave.equipmentids[2] != 0)
            {
                equipment.jacket = database.database[newsave.equipmentids[2]];
                ui.refreshequipment();
            }
            if (newsave.equipmentids[3] != 0)
            {
                equipment.legs = database.database[newsave.equipmentids[3]];
                ui.refreshequipment();
            }
            if (newsave.equipmentids[4] != 0)
            {
                equipment.boots = database.database[newsave.equipmentids[4]];
                ui.refreshequipment();
            }
            if (newsave.equipmentids[5] != 0)
            {
                equipment.hands = database.database[newsave.equipmentids[5]];
                ui.refreshequipment();
            }
            if (newsave.equipmentids[6] != 0)
            {
                equipment.backpack = database.database[newsave.equipmentids[6]];
                ui.refreshequipment();
            }
            if (newsave.equipmentids[7] != 0)
            {
                equipment.melee = database.database[newsave.equipmentids[7]];
                ui.refreshequipment();
            }
            if (newsave.equipmentids[8] != 0)
            {
                equipment.weapon = database.database[newsave.equipmentids[8]];
                ui.refreshequipment();
            }
            if (newsave.equipmentids[9] != 0)
            {
                equipment.sidearm = database.database[newsave.equipmentids[9]];
                ui.refreshequipment();
            }
            if (newsave.equipmentids[10] != 0)
            {
                equipment.binocs = database.database[newsave.equipmentids[10]];
                ui.refreshequipment();
            }
            equipment.spawnGear();
            limbs.torso = newsave.limbs[0];
            limbs.head = newsave.limbs[1];
            limbs.rightarm = newsave.limbs[2];
            limbs.righthand = newsave.limbs[3];
            limbs.leftarm = newsave.limbs[4];
            limbs.lefthand = newsave.limbs[5];
            limbs.rightleg = newsave.limbs[6];
            limbs.rightfoot = newsave.limbs[7];
            limbs.leftleg = newsave.limbs[8];
            limbs.leftfoot = newsave.limbs[9];
        }
    }
    public void Save()
    {
        PlayerDataForSaving newsave = new PlayerDataForSaving();

        newsave.pos[0] = gameObject.transform.position.x;
        newsave.pos[1] = gameObject.transform.position.y;
        newsave.pos[2] = gameObject.transform.position.z;
        Debug.Log(newsave.pos[0]);

        newsave.limbs[0] = limbs.torso;
        newsave.limbs[1] = limbs.head;
        newsave.limbs[2] = limbs.rightarm;
        newsave.limbs[3] = limbs.righthand;
        newsave.limbs[4] = limbs.leftarm;
        newsave.limbs[5] = limbs.lefthand;
        newsave.limbs[6] = limbs.rightleg;
        newsave.limbs[7] = limbs.rightfoot;
        newsave.limbs[8] = limbs.leftleg;
        newsave.limbs[9] = limbs.leftfoot;

        newsave.nutrition[0] = nutrition.thirst;
        newsave.nutrition[1] = nutrition.calories;
        newsave.nutrition[2] = nutrition.minerals;
        newsave.nutrition[3] = nutrition.vitamins;
        newsave.nutrition[4] = nutrition.protein;

        for(int i = 0; i < 100; i++)
        {
            if (inv.inventory[i] != null)
            newsave.invids[i] = inv.inventory[i].id;
        }

        if(equipment.head != null)
            newsave.equipmentids[0] = equipment.head.id;
        if (equipment.torso != null)
            newsave.equipmentids[1] = equipment.torso.id;
        if (equipment.jacket != null)
            newsave.equipmentids[2] = equipment.jacket.id;
        if (equipment.legs != null)
            newsave.equipmentids[3] = equipment.legs.id;
        if (equipment.boots != null)
            newsave.equipmentids[4] = equipment.boots.id;
        if (equipment.hands != null)
            newsave.equipmentids[5] = equipment.hands.id;
        if (equipment.backpack != null)
            newsave.equipmentids[6] = equipment.backpack.id;
        if (equipment.melee != null)
            newsave.equipmentids[7] = equipment.melee.id;
        if (equipment.weapon != null)
            newsave.equipmentids[8] = equipment.weapon.id;
        if (equipment.sidearm != null)
            newsave.equipmentids[9] = equipment.sidearm.id;
        if (equipment.binocs != null)
            newsave.equipmentids[10] = equipment.binocs.id;

        DataService.SaveData<PlayerDataForSaving>("/player.json", newsave, false);
    }
}
