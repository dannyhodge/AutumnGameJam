
using UnityEngine;

public class villagerHunger : MonoBehaviour
{
    public villagerInfo VillagerInfo;
    public GameObject Scripts;

    public float hungerTimer = 0f;
    public float hungerTimerMax = 6f;

    public int amountEaten = 5;

    void Start()
    {
        Scripts = GameObject.Find("_Scripts");
        VillagerInfo = GetComponent<villagerInfo>();
    }

    void Update()
    {
        hungerTimer += Time.deltaTime;

        if(hungerTimer >= hungerTimerMax)
        {
            VillagerInfo.hunger--;
            hungerTimer = 0f;
        }

        if(VillagerInfo.hunger <= 2)
        {
            Scripts.GetComponent<gameInfo>().currentFood -= amountEaten;
            VillagerInfo.hunger = 10;
        }
    }
}
