using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class farmInfo : MonoBehaviour
{
    //create farm at 100 watered
    //can right click to water
    //can see status of farm by different color wheat/dirt
    //water drops faster in summer, slower in winter

    //when autumn comes, wheat is ready. right click to harvest

    public int health = 100;
    public int maxHealth = 10;
    public int maxWater = 10;
    public int currentWater = 1;

    public int waterLoss = 1;

    public float waterLossTimer = 0f;
    public float waterLossTimerMax = 1f;

    public bool isSelected = false;
    public GameObject active;

    public bool canBeWatered = false;

    public GameObject scripts;

    public int waterGain = 5;

    private int foodGainInitial = 20;
    public int foodGain = 20;
    public int foodGainIncrease = 20;

    public int timesWatered = 0;

    public float deathTimer = 0f;
    public bool dead = false;

    void Start()
    {
        scripts = GameObject.Find("_Scripts");
        currentWater = maxWater;
        foodGainInitial = foodGain;
    }

    void FixedUpdate()
    {
        if (isSelected)
        {
            active.SetActive(true);
        }
        else
        {
            active.SetActive(false);
        }

        waterLossTimer += Time.deltaTime;

        if(waterLossTimer >= waterLossTimerMax)
        {
            currentWater--;
            waterLossTimer = 0f;
        }

        if(currentWater <= 0)
        {
            //RemoveFarm();
        }

        if(health <= 0)
        {
            scripts.GetComponent<gameInfo>().currentFood += foodGain;

            ResetFarm();
            health = maxHealth;
        }

        if(currentWater + waterGain < maxWater)
        {
            canBeWatered = true;
        }
        else
        {
            canBeWatered = false;
        }

        if (timesWatered >= 3)
        {
            canBeWatered = false;
        }

        if(scripts.GetComponent<seasonManager>().currentSeason == Season.Winter && timesWatered >= 3)
        {
            ResetFarm();
        }

    }

    void ResetFarm()
    {
        foreach (GameObject villager in scripts.GetComponent<gameInfo>().allVillagers)
        {
            if (villager.GetComponent<villagerInfo>().currentTarget == gameObject)
            {
                villager.GetComponent<villagerInfo>().currentTarget = null;
                villager.GetComponent<villagerInfo>().currentState = State.Idle;
            }
        }

        var allWheat = GetComponentsInChildren<wheatGrow>();

        foreach(wheatGrow wheat in allWheat)
        {
            wheat.currentWheatSizeId = -1;
            wheat.GrowWheat();
        }

        foodGain = foodGainInitial;
        timesWatered = 0;
        currentWater = maxWater;

    }
}
