using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEmptyobject : MonoBehaviour
{
    public float timetodestroy;
    void Start()
    {
        Destroy(gameObject, timetodestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
