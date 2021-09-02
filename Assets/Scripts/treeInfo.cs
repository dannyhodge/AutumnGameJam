using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeInfo : MonoBehaviour
{
    public bool isSelected = false;
    public GameObject active;

    void Start()
    {
        
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
        
    }
}
