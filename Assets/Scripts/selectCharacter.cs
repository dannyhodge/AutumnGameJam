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
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                //Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "Villager")
                {
                    hitInfo.transform.gameObject.GetComponent<villagerInfo>().isSelected = true;
                    GetComponent<gameInfo>().activeVillager = hitInfo.transform.gameObject;
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
            else
            {
                //Debug.Log("No hit");
            }
        }
    }
}
