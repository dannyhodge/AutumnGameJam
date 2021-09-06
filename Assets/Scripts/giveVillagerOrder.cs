using System.Collections;
using System.Collections.Generic;
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
                if (hit)
                {
                    Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                    if (hitInfo.transform.gameObject.tag == "Tree")
                    {

                        foreach (GameObject resource in GetComponent<gameInfo>().allTargets)
                        {
                            resource.GetComponent<resourceInfo>().isSelected = false;
                        }

                        hitInfo.transform.gameObject.GetComponent<resourceInfo>().isSelected = true;

                        activeTarget = hitInfo.transform.gameObject;
                        GetComponent<gameInfo>().activeVillager.GetComponent<villagerMove>().nextPosition = hitInfo.transform.gameObject.transform;
                        GetComponent<gameInfo>().activeVillager.GetComponent<villagerMove>().nextAction = State.Chopping;
                        GetComponent<gameInfo>().activeVillager.GetComponent<villagerInfo>().currentTarget = hitInfo.transform.gameObject;
                    }

                    if (hitInfo.transform.gameObject.tag == "Stone")
                    {

                        foreach (GameObject resource in GetComponent<gameInfo>().allTargets)
                        {
                            resource.GetComponent<resourceInfo>().isSelected = false;
                        }

                        hitInfo.transform.gameObject.GetComponent<resourceInfo>().isSelected = true;

                        activeTarget = hitInfo.transform.gameObject;
                        GetComponent<gameInfo>().activeVillager.GetComponent<villagerMove>().nextPosition = hitInfo.transform.gameObject.transform;
                        GetComponent<gameInfo>().activeVillager.GetComponent<villagerMove>().nextAction = State.Mining;
                        GetComponent<gameInfo>().activeVillager.GetComponent<villagerInfo>().currentTarget = hitInfo.transform.gameObject;
                    }
      
                }
       
            }
        }
    }
}