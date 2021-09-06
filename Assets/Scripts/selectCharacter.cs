using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectCharacter : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit[] hitInfos;
            hitInfos = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));

            if (hitInfos.Length > 0)
            {
                foreach (RaycastHit hit in hitInfos)
                {
                    //Debug.Log("Hit " + hit.transform.gameObject.name);
                    if (hit.transform.gameObject.tag == "Villager")
                    {
                        foreach(GameObject villager in GetComponent<gameInfo>().allVillagers)
                        {
                            villager.GetComponent<villagerInfo>().isSelected = false;
                        }
                        foreach (GameObject tree in GetComponent<gameInfo>().allTargets)
                        {
                            tree.GetComponent<resourceInfo>().isSelected = false;
                        }
        
                        hit.transform.gameObject.GetComponent<villagerInfo>().isSelected = true;
                        GetComponent<gameInfo>().activeVillager = hit.transform.gameObject;
                        break;
                    }
                    else
                    {
                        if (GetComponent<gameInfo>().activeVillager != null)
                        {
                            GetComponent<gameInfo>().activeVillager.GetComponent<villagerInfo>().isSelected = false;
                            GetComponent<gameInfo>().activeVillager = null;
                        }
                    }
                }
            }
            
        }
    }
}
