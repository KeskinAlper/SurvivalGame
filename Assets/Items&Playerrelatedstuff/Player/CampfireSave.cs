using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireSave : MonoBehaviour
{
    public GameSimulationManager manager;
    public Transform face;
    PlayerSaver saver;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Save();
        }
    }
    private void Start()
    {
        saver = gameObject.GetComponent<PlayerSaver>();
    }
    void Save()
    {
        RaycastHit2D result = Physics2D.Raycast(face.position, face.right, 2f);
        if (result.collider != null && result.collider.gameObject.tag == "Campfire")
        {
            saver.Save();
            manager.Save();
        }
    }
}
