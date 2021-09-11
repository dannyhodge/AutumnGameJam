
using UnityEngine;

public class giveVillagerOrder : MonoBehaviour
{
    public GameObject activeTarget;

    void Start()
    {

    }

    void Update()
    {
        if (GetComponent<gameInfo>().activeVillager != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hitInfo = new RaycastHit();
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

                foreach (GameObject resource in GetComponent<gameInfo>().allTargets)
                {
                    if (resource.tag == "Farm")
                    {
                        resource.GetComponent<farmInfo>().isSelected = false;
                    }
                    else
                    {
                        resource.GetComponent<resourceInfo>().isSelected = false;
                    }
                }

                if (hit)
                {
                    if (hitInfo.transform.gameObject.tag == "Tree")
                    {
                        GetComponent<gameInfo>().activeVillager.GetComponent<villagerMove>().nextAction = State.Chopping;
                        hitInfo.transform.gameObject.GetComponent<resourceInfo>().isSelected = true;
                        SetNextTarget(hitInfo);
                    }

                    if (hitInfo.transform.gameObject.tag == "Stone")
                    {
                        GetComponent<gameInfo>().activeVillager.GetComponent<villagerMove>().nextAction = State.Mining;
                        hitInfo.transform.gameObject.GetComponent<resourceInfo>().isSelected = true;
                        SetNextTarget(hitInfo);
                    }

                    if (hitInfo.transform.gameObject.tag == "Farm")
                    {
                        if (hitInfo.transform.gameObject.GetComponent<farmInfo>().canBeWatered)
                        {
                            GetComponent<gameInfo>().activeVillager.GetComponent<villagerMove>().nextAction = State.Farming;
                            hitInfo.transform.gameObject.GetComponent<farmInfo>().isSelected = true;
                            SetNextTarget(hitInfo);
                        }
                    }
                }
            }
        }
    }

    void SetNextTarget(RaycastHit hitInfo)
    {
        Debug.Log("huh");
        Debug.Log("hitinfo: " + hitInfo.transform.name);

        activeTarget = hitInfo.transform.gameObject;
        GetComponent<gameInfo>().activeVillager.GetComponent<villagerMove>().nextPosition = hitInfo.transform;
        GetComponent<gameInfo>().activeVillager.GetComponent<villagerInfo>().currentTarget = hitInfo.transform.gameObject;
    }
}
