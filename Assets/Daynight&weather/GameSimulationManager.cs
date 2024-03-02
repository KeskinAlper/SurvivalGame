using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class GameSimulationManager : MonoBehaviour
{
    public GameStateObject gamestate;
    float currenttimebetweenticks;
    public float timebetweenticks;
    public float currenthour;
    public int currentday;
    public Light2D globallight;
    public float currenttemp;
    public int currentseason;
    public int currentweather;
    private IDataService DataService = new JsonDataService();
    private void Start()
    {
        if(gamestate.isnewgame == true)
        {
            currenthour = 12f;
            currentday = 1;
            currentweather = 0;
            currentseason = 1;
        }
        else
        {
            currenthour = DataService.LoadData<float>("/ingamehour.json", false);
            currentday = DataService.LoadData<int>("/ingameday.json", false);
            currentweather = DataService.LoadData<int>("/ingameweather.json", false);
            currentseason = DataService.LoadData<int>("/ingameseason.json", false);
        }
    }
    public void Save()
    {
         DataService.SaveData<float>("/ingamehour.json", currenthour, false);
         DataService.SaveData<int>("/ingameday.json", currentday, false);
         DataService.SaveData<int>("/ingameweather.json", currentweather, false);
        DataService.SaveData<int>("/ingameseason.json", currentseason, false);
    }
    void Update()
    {
        currenttimebetweenticks += Time.deltaTime;
        if(currenttimebetweenticks >= timebetweenticks)
        {
            currenttimebetweenticks = 0;
            tick();
        }
    }

    void tick()
    {
        currenthour += 0.01f;
        if(currenthour >= 24f)
        {
            currenthour = 0f;
            currentday++;

            //calculating the corresponding season : changes every 10 days
            int num = currentday % 40;
            if (num < 10)
                currentseason = 1;
            else if (num < 20)
                currentseason = 2;
            else if (num < 30)
                currentseason = 3;
            else if (num < 40)
                currentseason = 4;
            changetemp();
            changeweather();
        }
        if(currenthour >= 12f)
        {
            globallight.intensity = 0.55f - (currenthour - 12f) / 24f;
        }
        else
        {
            globallight.intensity = 0.55f - (12f - currenthour) / 24f;
        }
    }
    void changetemp()
    {
        if(currentseason == 1)
        {
            currenttemp = Random.Range(8, 20);
        }
        else if(currentseason == 2)
        {
            currenttemp = Random.Range(-10, 10);
        }
        else if(currentseason == 3)
        {
            currenttemp = Random.Range(12, 25);
        }
        else if(currentseason == 4)
        {
            currenttemp = Random.Range(20, 35);
        }
    }
    //0 sunny , 1 rainy , 2 snowy
    void changeweather()
    {
        if (currentseason == 1)
        {
            if (Random.Range(1, 3) > 1)            
                currentweather = 0;           
            else            
                currentweather = 1;           
        }
        else if (currenthour == 2)
        {
            if (Random.Range(1, 2) == 1)
                currentweather = 2;
            else
                currentweather = 0;
        }
        else if (currentseason == 3)
        {
            if (Random.Range(1, 4) > 1)
                currentweather = 1;
            else
                currentweather = 0;
        }
        else if (currentseason == 4)
            currentweather = 0;
    }
}
