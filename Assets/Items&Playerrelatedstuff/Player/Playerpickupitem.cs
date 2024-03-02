using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerpickupitem : MonoBehaviour
{
    Inventory inv;
    public Transform face;
    // Start is called before the first frame update
    void Start()
    {
        inv = gameObject.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            pickup();
        }
    }
    void pickup()
    {
        Item item;
        RaycastHit2D result = Physics2D.Raycast(face.position,face.right,2f);
        if(result.collider != null && result.collider.gameObject.tag == "Pickup")
        {
           item  = result.collider.gameObject.GetComponent<ItemObject>().item;
            if(inv.addItem(item))
            {
                Destroy(result.collider.gameObject);
            }
        }
        
    }
}
