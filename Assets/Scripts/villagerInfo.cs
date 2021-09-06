using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class villagerInfo : MonoBehaviour
{
    public GameObject Scripts;

    public string villagerName;
    public int health = 10;
    public bool isSelected = false;
    public GameObject active;
    public State currentState = State.Idle;
    public GameObject currentTarget;

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


public enum State
{
    Idle = 0,
    Chopping = 1,
    Mining = 2,
    Defending = 3,
    Farming = 4,
    Travelling = 5
}