
using UnityEngine;
using UnityEngine.AI;

public class resourceInfo : MonoBehaviour
{
    public int health = 10;
    public int value = 10;
    public ResourceType resourceType;

    public bool isSelected = false;
    public GameObject active;
    public GameObject scripts;

    void Start()
    {
        scripts = GameObject.Find("_Scripts");
    }

    void Update()
    {
        if(isSelected)
        {
            active.SetActive(true);
        }
        else
        {
            active.SetActive(false);
        }
        
        if(health <= 0)
        {

            switch(resourceType)
            {
                case ResourceType.Tree:
                    scripts.GetComponent<gameInfo>().currentWood += value;
                    scripts.GetComponent<gameInfo>().allTrees.Remove(gameObject);
                    break;

                case ResourceType.Stone:
                    scripts.GetComponent<gameInfo>().currentStone += value;
                    scripts.GetComponent<gameInfo>().allStone.Remove(gameObject);
                    break;
                    
            }
      

            scripts.GetComponent<gameInfo>().allTargets.Remove(gameObject);
            foreach (GameObject villager in scripts.GetComponent<gameInfo>().allVillagers)
            {
                if (villager.GetComponent<villagerInfo>().currentTarget == gameObject)
                {
                    villager.GetComponent<villagerInfo>().currentTarget = null;
                    villager.GetComponent<villagerInfo>().currentState = State.Idle;
                }
            }
            scripts.GetComponent<gameInfo>().ground.GetComponent<NavMeshSurface>().BuildNavMesh();
            Destroy(gameObject);
        }
    }
}

public enum ResourceType
{
    Tree = 0,
    Stone = 1,
    Iron = 2
}