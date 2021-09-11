using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farmInfo : MonoBehaviour
{
    //create farm at 100 watered
    //can right click to water
    //can see status of farm by different color wheat/dirt
    //water drops faster in summer, slower in winter

    //when autumn comes, wheat is ready. right click to harvest

    public int health = 100;
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

    void Start()
    {
        scripts = GameObject.Find("_Scripts");
        currentWater = maxWater;
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
            health = 0;
        }

        if(health <= 0)
        {
            scripts.GetComponent<gameInfo>().allFarms.Remove(gameObject);
            scripts.GetComponent<gameInfo>().allTargets.Remove(gameObject);
            Destroy(gameObject);
        }

        if(currentWater + waterGain < maxWater)
        {
            canBeWatered = true;
        }


    }
}
