using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimbsHealth : MonoBehaviour
{
    public float torso;
    public float head;
    public float rightarm;
    public float righthand;
    public float leftarm;
    public float lefthand;
    public float rightleg;
    public float rightfoot;
    public float leftleg;
    public float leftfoot;
    public PlayerLimbsUI limbsui;
    public float regenrate;

    private void Start()
    {
        StartCoroutine(pulse());
    }
    IEnumerator pulse()
    {
        while(true)
        {
            torso += regenrate;
            head += regenrate;
            rightarm += regenrate;
            righthand += regenrate;
            leftarm += regenrate;
            lefthand += regenrate;
            rightleg += regenrate;
            rightfoot += regenrate;
            leftleg += regenrate;
            leftfoot += regenrate;

            yield return new WaitForSeconds(5);
        }
    }
}

