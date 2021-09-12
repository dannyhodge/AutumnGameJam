
using UnityEngine;

public class villagerActions : MonoBehaviour
{
    private GameObject Scripts;

    public float actionSpeed = 2f;
    public float actionTimer = 0f;

    public float wateringSpeed = 5f;
    public float wateringTimer = 0f;

    public int gatherStrength = 2;

    public bool hasArrived = false;

    void Start()
    {
        Scripts = GameObject.Find("_Scripts");
    }

    void Update()
    {
        if (hasArrived)
        {
            if (GetComponent<villagerInfo>().currentState == State.Chopping || GetComponent<villagerInfo>().currentState == State.Mining)
            {
                if (actionTimer <= actionSpeed)
                {
                    actionTimer += Time.deltaTime;
                }
                else
                {
                    GetComponent<villagerInfo>().currentTarget.GetComponent<resourceInfo>().health -= gatherStrength;

                    actionTimer = 0f;
                }
            }
            else if (GetComponent<villagerInfo>().currentState == State.Farming)
            {
                if (Scripts.GetComponent<seasonManager>().currentSeason != Season.Autumn)
                {
                    
                    if (wateringTimer <= wateringSpeed)
                    {
                        wateringTimer += Time.deltaTime;
                    }
                    else
                    {
                        GetComponent<villagerInfo>().currentTarget.GetComponent<farmInfo>().currentWater += GetComponent<villagerInfo>().currentTarget.GetComponent<farmInfo>().waterGain;
                        GetComponent<villagerInfo>().currentTarget.GetComponent<farmInfo>().foodGain += GetComponent<villagerInfo>().currentTarget.GetComponent<farmInfo>().foodGainIncrease;
                        GetComponent<villagerInfo>().currentTarget.GetComponent<farmInfo>().timesWatered++;
                        var allWheat = GetComponent<villagerInfo>().currentTarget.GetComponentsInChildren<wheatGrow>();

                        foreach(wheatGrow wheat in allWheat)
                        {
                            wheat.GrowWheat();
                        }

                        wateringTimer = 0f;
                        GetComponent<villagerInfo>().currentState = State.Idle;
                        Debug.Log("villageraction");
                        GetComponent<villagerActions>().hasArrived = false;
                    }
                }
                else  //if it is autumn, harvest
                {
                    if (actionTimer <= actionSpeed)
                    {
                        actionTimer += Time.deltaTime;
                    }
                    else
                    {
                        GetComponent<villagerInfo>().currentTarget.GetComponent<farmInfo>().health -= gatherStrength;

                        actionTimer = 0f;
                    }
                }
            }
        }
    }
}
