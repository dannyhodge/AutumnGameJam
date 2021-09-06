
using UnityEngine;

public class villagerActions : MonoBehaviour
{

    public float actionSpeed = 2f;
    public float actionTimer = 0f;

    public int gatherStrength = 2;

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<villagerInfo>().currentState == State.Chopping || GetComponent<villagerInfo>().currentState == State.Mining)
        {
            if(actionTimer <= actionSpeed)
            {
                actionTimer += Time.deltaTime;
            }
            else
            {
                GetComponent<villagerInfo>().currentTarget.GetComponent<resourceInfo>().health -= gatherStrength;

                actionTimer = 0f;
            }
        }
    }
}
