using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerLimbsUI : MonoBehaviour
{
    public PlayerLimbsHealth limbsHealth;
    public GameObject healthpanel;
    public GameObject head;
    public GameObject torso;
    public GameObject rightarm;
    public GameObject righthand;
    public GameObject leftarm;
    public GameObject lefthand;
    public GameObject rightleg;
    public GameObject rightfoot;
    public GameObject leftleg;
    public GameObject leftfoot;

    private void Start()
    {
        updateLimbs();
    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                healthpanel.SetActive(!healthpanel.activeSelf);
            }
        }
    }
    public void updateLimbs()
    {
        head.GetComponent<TextMeshProUGUI>().text = limbsHealth.head + "/100";
        torso.GetComponent<TextMeshProUGUI>().text = limbsHealth.torso + "/100";
        rightarm.GetComponent<TextMeshProUGUI>().text = limbsHealth.rightarm + "/100";
        righthand.GetComponent<TextMeshProUGUI>().text = limbsHealth.righthand + "/100";
        leftarm.GetComponent<TextMeshProUGUI>().text = limbsHealth.leftarm + "/100";
        lefthand.GetComponent<TextMeshProUGUI>().text = limbsHealth.lefthand + "/100";
        rightleg.GetComponent<TextMeshProUGUI>().text = limbsHealth.rightleg + "/100";
        rightfoot.GetComponent<TextMeshProUGUI>().text = limbsHealth.rightfoot + "/100";
        leftleg.GetComponent<TextMeshProUGUI>().text = limbsHealth.leftleg + "/100";
        leftfoot.GetComponent<TextMeshProUGUI>().text = limbsHealth.leftfoot + "/100";
    }
}
