using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFunctionality : MonoBehaviour
{
    public float damage;
    public float magazinecap;
    public float currentmagazine;
    public float timebetweenshots;
    public float reloadtime;
    public bool isreloading;
    public float lasttime;
    public float lasttimereload;
    public bool issemi = true;
    public GameObject bullet;
    public Transform barrel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lasttime <= timebetweenshots)
        lasttime += Time.deltaTime;
        if (issemi)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && lasttime > timebetweenshots && currentmagazine > 0 && !isreloading)
            {
                lasttime = 0;
                Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
                currentmagazine--;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0) && lasttime > timebetweenshots && currentmagazine > 0 && !isreloading)
            {
                lasttime = 0;
                Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
                currentmagazine--;
            }
        }
        if(isreloading)
        {
            lasttimereload -= Time.deltaTime;
        }
        if(lasttimereload <= 0)
        {
            currentmagazine = magazinecap;
            isreloading = false;
            lasttimereload = reloadtime;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            isreloading = true;
        }
    }
    private void OnDisable()
    {
        if (isreloading)
            lasttimereload = reloadtime;
    }
}
