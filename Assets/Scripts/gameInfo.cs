using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class gameInfo : MonoBehaviour
{
    public int currentFood= 0;
    public int currentWood = 0;
    public int currentStone = 0;
    public int currentIron = 0;

    public GameObject activeVillager;
    public GameObject[] allVillagers;

    public GameObject[] allTrees;
    public GameObject[] allStone;

    public GameObject[] allTargets;

    void Start()
    {
        allVillagers = GameObject.FindGameObjectsWithTag("Villager");
        allTrees = GameObject.FindGameObjectsWithTag("Tree");
        allStone= GameObject.FindGameObjectsWithTag("Stone");
        allTargets = allTrees.Concat(allStone).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
