
using UnityEngine;

public class villagerActions : MonoBehaviour
{

    public float actionSpeed = 2f;
    public float actionTimer = 0f;

    public float wateringSpeed = 5f;
    public float wateringTimer = 0f;

    public int gatherStrength = 2;

    public bool hasArrived = false;

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
                if (wateringTimer <= wateringSpeed)
                {
                    wateringTimer += Time.deltaTime;
                }
                else
                {
                    GetComponent<villagerInfo>().currentTarget.GetComponent<farmInfo>().currentWater += GetComponent<villagerInfo>().currentTarget.GetComponent<farmInfo>().waterGain;

                    wateringTimer = 0f;
                    GetComponent<villagerInfo>().currentState = State.Idle;
                    GetComponent<villagerActions>().hasArrived = false;
                }
            }
        }
    }
}
