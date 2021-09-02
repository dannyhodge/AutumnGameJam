using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class villagerInfo : MonoBehaviour
{
    public GameObject Scripts;

    public bool isSelected = false;
    public GameObject active;

    void Start()
    {
        Scripts = GameObject.Find("_Scripts");
    }

    void Update()
    {
        if (isSelected)
        {
            active.SetActive(true);
        }
        else
        {
            active.SetActive(false);
        }
    }
}
