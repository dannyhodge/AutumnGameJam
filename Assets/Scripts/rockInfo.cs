using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockInfo : MonoBehaviour
{
    public int health = 10;
    public bool isSelected = false;
    public GameObject active;

    void Start()
    {

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
