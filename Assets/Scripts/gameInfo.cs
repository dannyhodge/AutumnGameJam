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
    public List<GameObject> allVillagers;

    public List<GameObject> allTrees;
    public List<GameObject> allStone;

    public List<GameObject> allTargets;

    public GameObject ground;

    void Start()
    {
        allVillagers = GameObject.FindGameObjectsWithTag("Villager").ToList();
        allTrees = GameObject.FindGameObjectsWithTag("Tree").ToList();
        allStone = GameObject.FindGameObjectsWithTag("Stone").ToList();
        allTargets = allTrees.Concat(allStone).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
