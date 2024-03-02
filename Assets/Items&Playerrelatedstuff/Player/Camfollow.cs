using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camfollow : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x,player.transform.position.y,transform.position.z);
    }
}
