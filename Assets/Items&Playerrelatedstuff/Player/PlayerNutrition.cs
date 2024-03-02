using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNutrition : MonoBehaviour
{
    public float thirst;
    public float thrirstrate;
    public float thristmax;
    public float calories;
    public float calorierate;
    public float maxcalories;
    public float minerals;
    public float mineralrate;
    public float maxminerals;
    public float vitamins;
    public float vitaminrate;
    public float maxvitamin;
    public float protein;
    public float proteinrate;
    public float maxprotein;
    PlayerLimbsHealth health;
    Topdownmoevement movement;
    float speedmax;
    float regenmax;
    public bool isbacterial = false;
    public bool isviral = false;
    private void Start()
    {
        health = gameObject.GetComponent<PlayerLimbsHealth>();
        movement = gameObject.GetComponent<Topdownmoevement>();
        speedmax = movement.speedconfig;
        regenmax = health.regenrate;
        StartCoroutine(pulse());
    }
    private void FixedUpdate()
    {
        
        
    }

    IEnumerator pulse()
    {
        while (true)
        {
            float curcalrate = calorierate;
            float curvitrate = vitaminrate;
            if(isbacterial)
            {
                curcalrate = curcalrate * 1.4f;
                curvitrate = curvitrate * 1.2f;
            }
            if(isviral)
            {
                curcalrate = curcalrate * 1.5f;
                curvitrate = curvitrate * 1.3f;
            }

            calories -= curcalrate;
            minerals -= mineralrate;
            vitamins -= curvitrate;
            protein -= proteinrate;
            thirst -= thrirstrate;

            calories = Mathf.Clamp(calories, 0, maxcalories);
            minerals = Mathf.Clamp(minerals, 0, maxminerals);
            vitamins = Mathf.Clamp(vitamins, 0, maxvitamin);
            protein = Mathf.Clamp(protein, 0, maxprotein);
            thirst = Mathf.Clamp(thirst, 0, thristmax);

            float speedaffect = (calories / maxcalories) / 4 + (minerals / maxminerals) / 4 + (thirst / thristmax) / 2;
            float speedaffecthp = (health.leftleg + health.rightleg) / 200;
            movement.speedconfig = speedmax * speedaffect * speedaffecthp;
            float regenaffect = (protein / maxprotein) * 2 / 3 + (vitamins / maxvitamin) / 3;
            health.regenrate = regenaffect * regenmax;


            yield return new WaitForSeconds(10);
        }
        
    }
}
