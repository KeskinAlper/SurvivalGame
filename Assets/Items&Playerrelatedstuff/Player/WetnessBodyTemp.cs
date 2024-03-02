using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetnessBodyTemp : MonoBehaviour
{
    public float bodytemp;
    public float bodytempconstant;
    public float insulationforcold;
    public float insulationforhot;
    public float wetness;
    public GameSimulationManager manager;
    float currenttimebetweenticks;
    public float timebetweenticks;
    private void Update()
    {
        currenttimebetweenticks += Time.deltaTime;
        if (currenttimebetweenticks >= timebetweenticks)
        {
            currenttimebetweenticks = 0;
            float bodytemppchange;
            bodytemppchange = (manager.currenttemp - bodytemp) * bodytempconstant;
            bodytemp += bodytemppchange;
        }
    }
}
